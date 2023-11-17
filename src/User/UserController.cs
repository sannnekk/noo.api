using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using noo.api.User.DataAbstraction;
using noo.api.User.Services;

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

        
    }
}
