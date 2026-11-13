using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Cat.Sql.Cdc.Abstractions;
using Microsoft.Data.SqlClient;

namespace Cat.Sql.Cdc;

/// <summary>
/// The SQL Server side of the reader. It calls the change data capture functions and keeps the position in a table of its own.
/// A capture instance name is part of a function name, so it is checked before it goes into the SQL text.
/// Every other value goes in as a parameter.
/// </summary>
internal sealed class SqlServerCdcDatabase : ICatCdcDatabase
{
    private const int LsnLength = 10;

    private static readonly Regex NamePattern = new(@"^[A-Za-z0-9_]+$", RegexOptions.Compiled);

    private readonly string _connectionString;
    private readonly string _schema;

    public SqlServerCdcDatabase(CatCdcSettings settings)
    {
        if (string.IsNullOrWhiteSpace(settings.ConnectionString))
        {
            throw new InvalidOperationException($"Set {CatCdcSettings.ConfigurationSectionName}:ConnectionString to the connection string of the captured database.");
        }

        if (!NamePattern.IsMatch(settings.Schema))
        {
            throw new InvalidOperationException("The schema of the position table has only letters, digits and underscores.");
        }

        _connectionString = settings.ConnectionString;
        _schema = settings.Schema;
    }

    public async Task EnsureCreatedAsync(string captureInstance, CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken).ConfigureAwait(false);

        await using (var create = connection.CreateCommand())
        {
            create.CommandText = $"""
                IF SCHEMA_ID(N'{_schema}') IS NULL EXEC(N'CREATE SCHEMA [{_schema}]');
                IF OBJECT_ID(N'[{_schema}].[Position]', N'U') IS NULL
                    CREATE TABLE [{_schema}].[Position]
                    (
                        [CaptureInstance] nvarchar(128) NOT NULL PRIMARY KEY,
                        [LastLsn] binary(10) NULL,
                        [LastSequenceValue] binary(10) NULL,
                        [ClaimedBy] nvarchar(200) NULL,
                        [ClaimedUntil] datetime2 NULL,
                        [UpdatedAt] datetime2 NOT NULL
                    );
                """;
            try
            {
                await create.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (SqlException exception) when (exception.Number is 2714 or 2705 or 2759)
            {
                // Another instance created the table at the same moment.
            }
        }

        await using var insert = connection.CreateCommand();
        insert.CommandText = $"""
            INSERT INTO [{_schema}].[Position] ([CaptureInstance], [UpdatedAt])
            SELECT @ci, SYSUTCDATETIME()
            WHERE NOT EXISTS (SELECT 1 FROM [{_schema}].[Position] WITH (UPDLOCK, HOLDLOCK) WHERE [CaptureInstance] = @ci);
            """;
        insert.Parameters.Add(new SqlParameter("@ci", SqlDbType.NVarChar, 128) { Value = captureInstance });
        try
        {
            await insert.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (SqlException exception) when (exception.Number is 2627 or 2601)
        {
            // Another instance added the row at the same moment.
        }
    }

    public async Task<bool> TryClaimAsync(string captureInstance, string owner, TimeSpan lease, CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken).ConfigureAwait(false);
        await using var command = connection.CreateCommand();
        command.CommandText = $"""
            UPDATE [{_schema}].[Position]
            SET [ClaimedBy] = @owner, [ClaimedUntil] = DATEADD(SECOND, @lease, SYSUTCDATETIME())
            WHERE [CaptureInstance] = @ci
              AND ([ClaimedBy] = @owner OR [ClaimedUntil] IS NULL OR [ClaimedUntil] < SYSUTCDATETIME());
            """;
        command.Parameters.Add(new SqlParameter("@ci", SqlDbType.NVarChar, 128) { Value = captureInstance });
        command.Parameters.Add(new SqlParameter("@owner", SqlDbType.NVarChar, 200) { Value = owner });
        command.Parameters.Add(new SqlParameter("@lease", SqlDbType.Int) { Value = (int)Math.Ceiling(lease.TotalSeconds) });

        return await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false) == 1;
    }

    public async Task<CatCdcPosition?> GetPositionAsync(string captureInstance, CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken).ConfigureAwait(false);
        await using var command = connection.CreateCommand();
        command.CommandText = $"SELECT [LastLsn], [LastSequenceValue] FROM [{_schema}].[Position] WHERE [CaptureInstance] = @ci;";
        command.Parameters.Add(new SqlParameter("@ci", SqlDbType.NVarChar, 128) { Value = captureInstance });

        await using var reader = await command.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);
        if (!await reader.ReadAsync(cancellationToken).ConfigureAwait(false) || reader.IsDBNull(0))
        {
            return null;
        }

        return new CatCdcPosition((byte[])reader[0], reader.IsDBNull(1) ? null : (byte[])reader[1]);
    }

    public async Task<bool> SavePositionAsync(string captureInstance, string owner, CatCdcPosition position, CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken).ConfigureAwait(false);
        await using var command = connection.CreateCommand();
        command.CommandText = $"""
            UPDATE [{_schema}].[Position]
            SET [LastLsn] = @lsn, [LastSequenceValue] = @seq, [UpdatedAt] = SYSUTCDATETIME()
            WHERE [CaptureInstance] = @ci AND [ClaimedBy] = @owner;
            """;
        command.Parameters.Add(new SqlParameter("@ci", SqlDbType.NVarChar, 128) { Value = captureInstance });
        command.Parameters.Add(new SqlParameter("@owner", SqlDbType.NVarChar, 200) { Value = owner });
        command.Parameters.Add(BinaryParameter("@lsn", position.Lsn));
        command.Parameters.Add(BinaryParameter("@seq", position.SequenceValue));

        return await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false) == 1;
    }

    public async Task<byte[]?> GetMinLsnAsync(string captureInstance, CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken).ConfigureAwait(false);
        await using var command = connection.CreateCommand();
        command.CommandText = "SELECT sys.fn_cdc_get_min_lsn(@ci);";
        command.Parameters.Add(new SqlParameter("@ci", SqlDbType.NVarChar, 128) { Value = captureInstance });

        return await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false) as byte[];
    }

    public async Task<byte[]?> GetMaxLsnAsync(CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken).ConfigureAwait(false);
        await using var command = connection.CreateCommand();
        command.CommandText = "SELECT sys.fn_cdc_get_max_lsn();";

        return await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false) as byte[];
    }

    public async Task<IReadOnlyList<string>> GetKeyColumnsAsync(string captureInstance, CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken).ConfigureAwait(false);
        await using var command = connection.CreateCommand();
        command.CommandText = """
            SELECT ic.[column_name]
            FROM [cdc].[index_columns] AS ic
            JOIN [cdc].[change_tables] AS ct ON ct.[object_id] = ic.[object_id]
            WHERE ct.[capture_instance] = @ci
            ORDER BY ic.[index_ordinal];
            """;
        command.Parameters.Add(new SqlParameter("@ci", SqlDbType.NVarChar, 128) { Value = captureInstance });

        var columns = new List<string>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);
        while (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
        {
            columns.Add(reader.GetString(0));
        }

        return columns;
    }

    public async Task<IReadOnlyList<CatChange>> ReadChangesAsync(string captureInstance, CatCdcPosition after, byte[] toLsn, int batchSize,
        IReadOnlyList<string> keyColumns, CancellationToken cancellationToken)
    {
        if (!NamePattern.IsMatch(captureInstance))
        {
            throw new ArgumentException("A capture instance has only letters, digits and underscores.", nameof(captureInstance));
        }

        await using var connection = await OpenAsync(cancellationToken).ConfigureAwait(false);
        await using var command = connection.CreateCommand();

        // An update has two rows, so a batch of N changes needs up to 2N rows.
        // The time of the transaction is stored in the local time of the server. It gets the current offset of the server.
        command.CommandText = $"""
            SELECT TOP (@rows) t.*,
                   TODATETIMEOFFSET(m.[tran_end_time], DATEPART(TZOFFSET, SYSDATETIMEOFFSET())) AS [__cat_tran_time],
                   m.[tran_id] AS [__cat_tran_id]
            FROM [cdc].[fn_cdc_get_all_changes_{captureInstance}](@from, @to, N'all update old') AS t
            JOIN [cdc].[lsn_time_mapping] AS m ON m.[start_lsn] = t.[__$start_lsn]
            WHERE t.[__$start_lsn] > @lsn OR (t.[__$start_lsn] = @lsn AND (@seq IS NULL OR t.[__$seqval] > @seq))
            ORDER BY t.[__$start_lsn], t.[__$seqval], t.[__$operation];
            """;
        command.Parameters.Add(new SqlParameter("@rows", SqlDbType.Int) { Value = checked(batchSize * 2) });
        command.Parameters.Add(BinaryParameter("@from", after.Lsn));
        command.Parameters.Add(BinaryParameter("@to", toLsn));
        command.Parameters.Add(BinaryParameter("@lsn", after.Lsn));
        command.Parameters.Add(BinaryParameter("@seq", after.SequenceValue));

        var rows = new List<CatCdcRawRow>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);
        while (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
        {
            var row = new CatCdcRawRow();
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var name = reader.GetName(i);
                switch (name)
                {
                    case "__$start_lsn":
                        row.Lsn = (byte[])reader[i];
                        break;
                    case "__$seqval":
                        row.SequenceValue = (byte[])reader[i];
                        break;
                    case "__$operation":
                        row.Operation = Convert.ToInt32(reader[i]);
                        break;
                    case "__$update_mask":
                        break;
                    case "__cat_tran_time":
                        row.TransactionTime = reader.GetDateTimeOffset(i);
                        break;
                    case "__cat_tran_id":
                        row.TransactionId = reader.IsDBNull(i) ? Array.Empty<byte>() : (byte[])reader[i];
                        break;
                    default:
                        row.Values[name] = reader.IsDBNull(i) ? null : reader[i];
                        break;
                }
            }

            rows.Add(row);
        }

        return CatCdcRowMapper.ToChanges(captureInstance, rows, batchSize, keyColumns);
    }

    private async Task<SqlConnection> OpenAsync(CancellationToken cancellationToken)
    {
        var connection = new SqlConnection(_connectionString);
        try
        {
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
            return connection;
        }
        catch
        {
            await connection.DisposeAsync().ConfigureAwait(false);
            throw;
        }
    }

    private static SqlParameter BinaryParameter(string name, byte[]? value)
    {
        return new SqlParameter(name, SqlDbType.Binary, LsnLength) { Value = value ?? (object)DBNull.Value };
    }
}
