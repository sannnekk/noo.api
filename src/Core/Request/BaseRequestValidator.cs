using FluentValidation;

namespace noo.api.Core.Request;

public abstract class BaseRequestValidator<T> : AbstractValidator<T>
{
    public BaseRequestValidator() : base()
    { }
}