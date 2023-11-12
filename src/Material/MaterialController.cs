using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using noo.api.Material.DataAbstraction;

namespace noo.api.Material;

[ApiController]
[Route("material")]
public class MaterialController : ControllerBase
{
    private readonly Core.Log.ILogger logger;
    private readonly MaterialValidator validator;

    public MaterialController(Core.Log.ILogger logger, MaterialValidator validator)
    {
        this.logger = logger;
        this.validator = validator;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateMaterial(MaterialModel material)
    {
        try
        {
            // TODO: create material
            await Task.Delay(1); // To make the compiler happy
            return Ok();
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

}