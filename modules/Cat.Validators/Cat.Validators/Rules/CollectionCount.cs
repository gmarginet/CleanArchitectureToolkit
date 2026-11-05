using System.Collections;

namespace Cat.Validators.Rules;

/// <summary>Counts the items of a collection without enumerating more than needed.</summary>
internal static class CollectionCount
{
    /// <summary>Gets the number of items. Uses <see cref="ICollection.Count"/> when the collection has it.</summary>
    public static int Of(IEnumerable items)
    {
        if (items is ICollection collection) return collection.Count;

        var count = 0;
        foreach (var _ in items) count++;
        return count;
    }
}
