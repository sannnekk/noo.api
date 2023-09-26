using api.Models.DB;
using api.Models.Enums;
using api.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/subject")]
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
            catch (Exception ex) 
            {
                return Problem(ex.Message);
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
                                   
                await _subjectService.CreateSubjectAsync(newSubject);
                return Ok();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
