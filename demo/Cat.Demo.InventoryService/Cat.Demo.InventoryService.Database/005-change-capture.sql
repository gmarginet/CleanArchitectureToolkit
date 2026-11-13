-- Switches change data capture on for the database and for the stock table. Cat.Sql.Cdc reads the change table that this creates
-- and Inventory sends every change as a StockChanged message. The capture needs the SQL Server Agent, which the AppHost starts
-- with MSSQL_AGENT_ENABLED=true. The script can run again: it only switches on what is still off.
-- The capture instance is called dbo_StockItem. Inventory:ChangeCapture must be true for Inventory to read it.

-- The Agent can start a little after SQL Server accepts connections, and the capture job needs it. Wait up to a minute.
DECLARE @agentTries int = 0;
WHILE @agentTries < 60 AND NOT EXISTS (SELECT 1 FROM sys.dm_server_services WHERE servicename LIKE N'SQL Server Agent%' AND status_desc = N'Running')
BEGIN
    WAITFOR DELAY '00:00:01';
    SET @agentTries += 1;
END;
GO

IF EXISTS (SELECT 1 FROM sys.databases WHERE name = DB_NAME() AND is_cdc_enabled = 0)
BEGIN
    EXEC sys.sp_cdc_enable_db;
END;
GO

-- The Agent can say it runs before it can create the capture job. Then the enable fails and rolls back, so try again for up to a minute.
-- When it still fails, the error of the last try goes up, so the AppHost shows it.
DECLARE @enableTries int = 0;
WHILE @enableTries < 30 AND NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'dbo_StockItem_CT' AND schema_id = SCHEMA_ID(N'cdc'))
BEGIN
    BEGIN TRY
        EXEC sys.sp_cdc_enable_table
            @source_schema = N'dbo',
            @source_name = N'StockItem',
            @role_name = NULL,
            @supports_net_changes = 0;
    END TRY
    BEGIN CATCH
        IF @enableTries >= 29 THROW;
        WAITFOR DELAY '00:00:02';
    END CATCH;
    SET @enableTries += 1;
END;
GO
