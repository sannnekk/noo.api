using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using noo.api.Core.DataAbstraction.Exceptions;
using noo.api.User.DataAbstraction;
using noo.api.User.Services;
using System.Net;

namespace noo.api.User
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly Core.Log.ILogger _logger;
        private readonly IValidator<UserModel> _userValidator;
        private readonly IValidator<CreateUserModelDTO> _createUserValidator;
        private readonly IUserService _userService;

        public UserController(Core.Log.ILogger logger, IValidator<UserModel> validator, IUserService userService, IValidator<CreateUserModelDTO> createUserValidator)
        {
            _logger = logger;
            _userValidator = validator;
            _userService = userService;
            _createUserValidator = createUserValidator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Ulid id)
        {
            try
            {
                var user = await _userService.GetAsync(id);

                if(user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (UnknownException ex)
            {
                _logger.Log(ex.Message);
                return new BadRequestObjectResult("InternalServerError");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAsync();

                if(users == null)
                    return Ok(new List<UserModel>());

                return Ok(users);
            }
            catch(UnknownException ex)
            {
                _logger.Log(ex.Message);
                return new BadRequestObjectResult("InternalServerError");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserModel userModel)
        {
            try
            {
                var validationResult = _userValidator.Validate(userModel);

                if(!validationResult.IsValid)
                    return BadRequest(validationResult.ToString("\n"));

                await _userService.UpdateAsync(userModel);
                return Ok();
            }
            catch(UnknownException ex)
            {
                _logger.Log(ex.Message);
                return new BadRequestObjectResult("InternalServerError");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Ulid id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return Ok();
            }
            catch(NotFoundException ex)
            {
                _logger.Log(ex.Message);
                return NotFound(ex.Message);
            }
            catch(UnknownException ex)
            {
                _logger.Log(ex.Message);
                return new BadRequestObjectResult("InternalServerError");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserModelDTO userDTO)
        {
            try
            {
                var validationResult = _createUserValidator.Validate(userDTO);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToString("\n"));

                await _userService.CreateAsync(userDTO);
                return Ok();
            }
            catch (UnknownException ex)
            {
                _logger.Log(ex.Message);
                return new BadRequestObjectResult("InternalServerError");
            }
        }
    }
}
