using Login.Core;
using Login.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 

namespace Login.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Login.Core.User>> GetLogin([FromBody] Login.Core.User user)
        {
            Login.Core.User? CurrentUser = await _context.users.FirstOrDefaultAsync(userVal => 
            userVal.UserName == user.UserName && userVal.Password == user.Password);

            if (CurrentUser != null)
            {
                return CurrentUser;
            }

            return Problem(detail: "Invalid Login Details", statusCode: 400, title: "Invalid Login");
        }
    }
}
