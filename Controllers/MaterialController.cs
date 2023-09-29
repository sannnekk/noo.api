using api.Models.DB;
using api.Models.Enums;
using api.Services.Implementations;
using api.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("noo/material")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;
        private readonly IValidator<MaterialModel> _validator;

        public MaterialController(IMaterialService materialService, IValidator<MaterialModel> validator)
        {
            _materialService = materialService;
            _validator = validator;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Ulid id)
        {
            try
            {
                var response = await _materialService.GetMaterialWithWorksAsync(id);

                if(response == null)
                    return NotFound();

                return Ok(response);
            }
            catch
            {
                return Problem();
            }
        }

        [Authorize(Roles = nameof(UserRole.Teacher))]
        [HttpPost]
        public async Task<IActionResult> Post(MaterialModel newMaterial)
        {
            try
            {
                var validationResult = _validator.Validate(newMaterial);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToString("\n"));

                await _materialService.CreateAsync(newMaterial);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [Authorize(Roles = nameof(UserRole.Teacher))]
        [HttpDelete]
        public async Task<IActionResult> Delete(MaterialModel newMaterial)
        {
            try
            {
                var validationResult = _validator.Validate(newMaterial);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToString("\n"));

                await _materialService.DeleteAsync(newMaterial);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [Authorize(Roles = nameof(UserRole.Teacher))]
        [HttpPut]
        public async Task<IActionResult> Put(MaterialModel newMaterial)
        {
            try
            {
                var validationResult = _validator.Validate(newMaterial);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToString("\n"));

                await _materialService.UpdateAsync(newMaterial);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
