using api.Models.DB;
using api.Models.Enums;
using api.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("noo/subject")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IValidator<SubjectModel> _validator;

        public SubjectController(ISubjectService subjectService, IValidator<SubjectModel> validator)
        {
            _subjectService = subjectService;
            _validator = validator;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Ulid id)
        {
            try
            {
                var subject = await _subjectService.GetSubjectWithMaterialsAsync(id);

                if(subject == null)                
                    return NotFound();
                
                return Ok(subject);
            }
            catch
            {
                return Problem();
            }            
        }

        [Authorize(Roles = nameof(UserRole.Teacher))]
        [HttpPost]
        public async Task<IActionResult> Post(SubjectModel newSubject)
        {
            try
            {
                var validationResult = _validator.Validate(newSubject);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToString("\n"));
                                   
                await _subjectService.CreateAsync(newSubject);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [Authorize(Roles = nameof(UserRole.Teacher))]
        [HttpDelete]
        public async Task<IActionResult> Delete(SubjectModel newSubject)
        {
            try
            {
                var validationResult = _validator.Validate(newSubject);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToString("\n"));

                await _subjectService.DeleteAsync(newSubject);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [Authorize(Roles = nameof(UserRole.Teacher))]
        [HttpPut]
        public async Task<IActionResult> Put(SubjectModel newSubject)
        {
            try
            {
                var validationResult = _validator.Validate(newSubject);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToString("\n"));

                await _subjectService.UpdateAsync(newSubject);
                return Ok();
            }
            catch(NullReferenceException)
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
