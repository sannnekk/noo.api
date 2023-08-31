using api.Validators;

namespace api.ModelDefinitions;

public interface IModelDefinition
{
    static IValidator? Validator { get; }
    static string? EntityName { get; }
}