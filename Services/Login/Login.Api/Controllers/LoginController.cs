using Login.Core.DTO;
using Login.Core.Entities;
using Login.Core.IRepositories;
using Login.Core.ServiceContracts;
using Login.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Login.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtService _jwtService;
        public LoginController(ApplicationDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }
        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> PostLogin([FromBody] User user)
        {
            User? CurrentUser = await _context.users.FirstOrDefaultAsync(userVal => 
            userVal.UserName == user.UserName && userVal.Password == user.Password);
            if (CurrentUser != null)
            {
                AuthenticationResponse authResponse = _jwtService.CreateJwtToken(CurrentUser);
                return authResponse;
            }

            return Problem(detail: "Invalid Login Details", statusCode: 400, title: "Invalid Login");
        }
    }
}
