using Microsoft.AspNetCore.Mvc;
using ZonkeTechAccessControlAPI.Models;
using ZonkeTechAccessControlAPI.Services;
namespace ZonkeTechAccessControlAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserMongoDBService _userService;
    
    public UserController(ILogger<UserController> logger,UserMongoDBService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet()]
    public Task<List<User>> Get()
    {
        return _userService.GetAsync();
    }

    [HttpGet("{id:length(24)}")]
    public Task<User?> Get(string id)
    {
        return _userService.GetAsync(id);
    }
    
    [HttpPost("/create")]
    public async Task<IActionResult> Post(User newUser){
        await _userService.CreateAsync(newUser);
        return CreatedAtAction(nameof(Get),new {id = newUser.Id },newUser);
    }

    [HttpPut("/update/{id:length(24)}")]
    public async Task<IActionResult> Put(string id,User updatedUser){
        var user = await _userService.GetAsync(id);
        if(user is null){
            return NotFound();
        }
        
        updatedUser.Id = id;
        await _userService.UpdateAsync(id,updatedUser);
        return NoContent();
    }

    [HttpPut("/delete/{id:length(24)}")]
    public async Task<IActionResult> Delete(string id){
        await _userService.DeleteAsync(id);
        return null;
    }
}
