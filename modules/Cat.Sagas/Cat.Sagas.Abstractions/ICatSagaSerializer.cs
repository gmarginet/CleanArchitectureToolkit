using System;

namespace Cat.Sagas.Abstractions;

/// <summary>
/// Turns the workflow state and the checkpoint into text and back. The default one uses System.Text.Json.
/// Register your own to use another format.
/// </summary>
public interface ICatSagaSerializer
{
    /// <summary>
    /// Turns a value into text.
    /// </summary>
    /// <param name="value">The value to serialize.</param>
    /// <param name="type">The type to serialize it as.</param>
    /// <returns>The text.</returns>
    string Serialize(object value, Type type);

    /// <summary>
    /// Turns text back into a value.
    /// </summary>
    /// <param name="text">The text from <see cref="Serialize"/>.</param>
    /// <param name="type">The type of the value.</param>
    /// <returns>The value.</returns>
    object Deserialize(string text, Type type);
}
