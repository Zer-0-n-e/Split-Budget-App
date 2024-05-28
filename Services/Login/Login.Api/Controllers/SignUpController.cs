using Login.Core;
using Login.Core.IRepositories;
using Login.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Login.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {        
        private readonly IUserRepository _userRepository;
        public SignUpController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        public async Task<ActionResult<User>> SignUpUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return Problem(detail: "No user details found! ", statusCode: 400, title: "Bad Request");
                }
                if (string.IsNullOrEmpty(user?.UserName) || string.IsNullOrEmpty(user?.Password))
                {
                    return Problem(detail: "UserName/Password is required", statusCode: 400, title: "Bad Request");
                }
                var _user = await _userRepository.AddAsync(user);
                if (_user != null)
                {
                    return Ok(_user);
                }
            }
            catch (Exception ex) 
            {
                return Problem(detail: "Something went wrong!", statusCode: 400, title: "Internal server error");
            }

            return Problem(detail: "Invalid Login Details", statusCode: 400, title: "Invalid Login");
        }
    }
}
