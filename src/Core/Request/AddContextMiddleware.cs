namespace noo.api.Core.Request;

public class AddContextMiddleware
{
    private readonly RequestDelegate next;

    public AddContextMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, IRequestContext requestContext)
    {
        var request = context.Request;

        try
        {
            var claims = request.HttpContext.User.Claims;
            requestContext.ApplyClaims(claims);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        await next(context);
    }
}

public static class AddContextMiddlewareExtensions
{
    public static IApplicationBuilder UseAddContextMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AddContextMiddleware>();
    }
}