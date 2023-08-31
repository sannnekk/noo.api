namespace api.Validators;

public class ValidationException : Exception
{
    public ValidationException(String message) : base(message) { }
}