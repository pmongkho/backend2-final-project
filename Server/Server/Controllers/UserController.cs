using Microsoft.AspNetCore.Mvc;
using DotNetServer.Models;
using DotNetServer.Services;
using Stripe;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IConfiguration _configuration;


    public UserController(UserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAllUsersAsync());
    }

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> Get(string id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();

        return Ok(user);
    }

    // create
[HttpPost]
    public async Task<IActionResult> CreateOrUpdateUser([FromBody] User user)
    {

        StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

        // Create Stripe customer if it doesn't exist
        if (string.IsNullOrEmpty(user.StripeCustomerId))
        {
            var customerService = new CustomerService();
            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email = user.Email
            });
            user.StripeCustomerId = customer.Id;
        }

        // Check if user exists and create or update accordingly
        var existingUser = await _userService.GetUserByIdAsync(user.Id!);
        if (existingUser == null)
        {
            await _userService.CreateAsync(user);
        }
        else
        {
            await _userService.UpdateAsync(user.Id!, user);
        }

        return Ok(new { UserId = user.Id, user.StripeCustomerId });
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, User user)
    {
        await _userService.UpdateAsync(id, user);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _userService.RemoveAsync(id);
        return NoContent();
    }
}
