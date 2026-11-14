using System;
using System.Text.Json;
using Cat.FluentWorkflows.Abstractions;
using Cat.Sagas.Abstractions;

namespace Cat.Sagas;

/// <summary>
/// <see cref="ICatSagaSerializer"/> on System.Text.Json with the web defaults.
/// It also gives the loop state of a foreach in a checkpoint its type back, because the checkpoint holds it as an object.
/// </summary>
public sealed class SystemTextJsonSagaSerializer : ICatSagaSerializer
{
    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

    /// <inheritdoc />
    public string Serialize(object value, Type type)
    {
        return JsonSerializer.Serialize(value, type, Options);
    }

    /// <inheritdoc />
    public object Deserialize(string text, Type type)
    {
        var value = JsonSerializer.Deserialize(text, type, Options)
                    ?? throw new InvalidOperationException($"The saved text is empty and cannot become a {type.Name}.");

        if (value is CatWorkflowCheckpoint checkpoint)
        {
            RestoreLoopState(checkpoint.Frame);
        }

        return value;
    }

    private static void RestoreLoopState(CatCheckpointFrame? frame)
    {
        while (frame != null)
        {
            if (frame.LoopState is JsonElement element && frame.LoopStateType != null)
            {
                var loopType = Type.GetType(frame.LoopStateType, throwOnError: true)!;
                frame.LoopState = JsonSerializer.Deserialize(element.GetRawText(), loopType, Options);
            }

            foreach (var branch in frame.Branches)
            {
                RestoreLoopState(branch.Frame);
            }

            frame = frame.Child;
        }
    }
}
