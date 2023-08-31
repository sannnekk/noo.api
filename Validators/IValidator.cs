using api.ModelDefinitions;

namespace api.Validators;

public interface IValidator
{
    /// <summary>
    /// Validate an object
    /// </summary>
    /// <param name="obj">Object to validate</param>
    /// <typeparam name="T">Type of object to validate</typeparam>
    /// <returns>True if valid, false if not</returns>
    /// <exception cref="ValidationException">Thrown if object validation is failed</exception>
    public Boolean Validate(object data);
}