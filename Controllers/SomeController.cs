using Microsoft.AspNetCore.Mvc;
using api.Validators;
using api.Services;

namespace api.Controllers;

[ApiController]
[Route("/some")]
public class SomeController : ControllerBase
{
    protected readonly IValidator validator;
    protected readonly SomeService service;

    public SomeController()
    {
        // TODO: inject these
        this.validator = new SomeValidator();
        this.service = new SomeService();
    }

    [HttpGet(Name = "GetSome", Order = 1)]
    public IEnumerable<String> Get()
    {
        return new List<String>();
    }
}
