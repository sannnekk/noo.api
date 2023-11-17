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
        private readonly IValidator<UserModel> _validator;
        private readonly IUserService _userService;

        public UserController(Core.Log.ILogger logger, IValidator<UserModel> validator, IUserService userService)
        {
            _logger = logger;
            _validator = validator;
            _userService = userService;
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
                return new ObjectResult(HttpStatusCode.InternalServerError);
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
               return new ObjectResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserModel userModel)
        {
            try
            {
                await _userService.UpdateAsync(userModel);
                return Ok();
            }
            catch(UnknownException ex)
            {
                _logger.Log(ex.Message);
                return new ObjectResult(HttpStatusCode.InternalServerError);
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
                return new ObjectResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}
