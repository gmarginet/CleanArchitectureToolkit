using System;
using System.Collections.Generic;
using System.Linq;

namespace Cat.Sagas;

/// <summary>
/// Finds the registered sagas by workflow type or by name.
/// </summary>
internal sealed class CatSagaRegistry
{
    private readonly ICatSagaDefinition[] _definitions;

    public CatSagaRegistry(IEnumerable<ICatSagaDefinition> definitions)
    {
        _definitions = definitions.ToArray();
    }

    public ICatSagaDefinition? Find(Type workflowType) => _definitions.FirstOrDefault(d => d.WorkflowType == workflowType);

    public ICatSagaDefinition? Find(string name) => _definitions.FirstOrDefault(d => d.Name == name);
}
