using api.ModelDefinitions;

namespace api.Validators;

public class SomeValidator : IValidator
{
    public bool Validate(object obj)
    {
        // some checks

        return true;
    }
}
