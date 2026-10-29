namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
// Deliberately has no ICatValidator<T> implementation registered - used to test
// ICatValidatorProcessor's validatorRequired behavior.
public record TestModelFor_NoValidatorRegistered(string Name);
