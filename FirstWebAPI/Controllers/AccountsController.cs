using FirstWebAPI.Models;
using FirstWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _repository;
        public AccountsController(IAccountRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel signUpModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repository.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                return Ok(new { Message = "User registered successfully" });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel signInModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _repository.SignInAsync(signInModel);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            return Ok(new { Token = token });
        }
    }
}
