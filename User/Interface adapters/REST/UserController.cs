using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Application.UseCases;
using UserMicroservice.Domain.Entities;
using UserMicroservice.Infrastructure.Security;
using UserMicroservice.Interface_adapters.REST.DTOs;

namespace UserMicroservice.Interface_adapters.REST;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly CreateUserUseCase _createUserUseCase;
    private readonly GetUserByIdUseCase _getUserByIdUseCase;
    private readonly GetUserByEmailUseCase _getUserByEmailUseCase;
    private readonly UpdateUserUseCase _updateUserUseCase;
    private readonly DeleteUserUseCase _deleteUserUseCase;
    
    private readonly IConfiguration _configuration;

    public UserController(
        CreateUserUseCase createUserUseCase,
        GetUserByIdUseCase getUserByIdUseCase,
        GetUserByEmailUseCase getUserByEmailUseCase,
        UpdateUserUseCase updateUserUseCase,
        DeleteUserUseCase deleteUserUseCase,
        IConfiguration configuration)
    {
        _createUserUseCase = createUserUseCase;
        _getUserByIdUseCase = getUserByIdUseCase;
        _getUserByEmailUseCase = getUserByEmailUseCase;
        _updateUserUseCase = updateUserUseCase;
        _deleteUserUseCase = deleteUserUseCase;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdUser = await _createUserUseCase.Execute(
            dto.Username, dto.Password, dto.Firstname, dto.Lastname, dto.Email);

        return CreatedAtAction(
            nameof(GetUserById),
            new { id = createdUser.UserID },
            MapToResponseDto(createdUser)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _getUserByIdUseCase.Execute(id);
        return user != null ? Ok(MapToResponseDto(user)) : NotFound();
    }

    [HttpGet("by-email")]
    public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
    {
        var user = await _getUserByEmailUseCase.Execute(email);
        return user != null ? Ok(MapToResponseDto(user)) : NotFound();
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _getUserByEmailUseCase.Execute(dto.Username);
        if (user == null)
            return Unauthorized("Invalid username or password.");

        // Verify the password
        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            return Unauthorized("Invalid username or password.");

        var jwtGenerator = new JwtTokenGenerator(_configuration);
        var token = jwtGenerator.GenerateToken(user.UserID.ToString(), user.Username);

        return Ok(new
        {
            UserID = user.UserID,
            Username = user.Username,
            Token = token
        });
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _getUserByIdUseCase.Execute(id);
        if (user == null)
            return NotFound();

        // Opdater brugerens detaljer
        user.Username = dto.Username;
        user.Password = dto.Password;
        user.Firstname = dto.Firstname;
        user.Lastname = dto.Lastname;
        user.Email = dto.Email;

        await _updateUserUseCase.Execute(
            user.UserID, user.Username, user.Password, user.Firstname, user.Lastname, user.Email);

        return NoContent();
    }
    /*
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var createdUser = await _createUserUseCase.Execute(
                dto.Username, dto.Password, dto.Firstname, dto.Lastname, dto.Email);

            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserID }, new
            {
                createdUser.UserID,
                createdUser.Username,
                createdUser.Email
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Registration error: {ex.Message}");
            return StatusCode(500, "An unexpected error occurred.");
        }
    }*/


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var result = await _deleteUserUseCase.Execute(id);
        return result ? NoContent() : NotFound();
    }

    private UserResponseDto MapToResponseDto(User user)
    {
        // Inkluder lokationer i responsen, hvis nødvendigt
        return new UserResponseDto
        {
            UserID = user.UserID,
            Username = user.Username,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Email = user.Email,
            Locations = user.Locations.Select(l => new LocationResponseDto
            {
                LocationID = l.LocationID,
                StreetName = l.StreetName,
                HouseNumber = l.HouseNumber,
                PostalCode = l.PostalCode,
                City = l.City,
                Country = l.Country,
                Region = l.Region
            }).ToList()
        };
    }
}
