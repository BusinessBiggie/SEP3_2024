using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Application.UseCases.LocationUsecases;
using UserMicroservice.Interface_adapters.REST.DTOs;

namespace UserMicroservice.Interface_adapters.REST;

[ApiController]
[Route("api/locations")]
public class LocationController : ControllerBase
{
    private readonly CreateLocationForUserUseCase _createLocationForUserUseCase;
    private readonly GetLocationByIdUseCase _getLocationByIdUseCase;
    private readonly GetAllLocationsUseCase _getAllLocationsUseCase;
    private readonly UpdateLocationUseCase _updateLocationUseCase;
    private readonly DeleteLocationUseCase _deleteLocationUseCase;

    public LocationController(
        CreateLocationForUserUseCase createLocationForUserUseCase,
        GetLocationByIdUseCase getLocationByIdUseCase,
        GetAllLocationsUseCase getAllLocationsUseCase,
        UpdateLocationUseCase updateLocationUseCase,
        DeleteLocationUseCase deleteLocationUseCase)
    {
        _createLocationForUserUseCase = createLocationForUserUseCase;
        _getLocationByIdUseCase = getLocationByIdUseCase;
        _getAllLocationsUseCase = getAllLocationsUseCase;
        _updateLocationUseCase = updateLocationUseCase;
        _deleteLocationUseCase = deleteLocationUseCase;
    }

    [HttpPost("api/users/{userId}/locations")]
    public async Task<IActionResult> CreateLocationForUser(int userId, [FromBody] LocationDto locationDto)
    {
        try
        {
            var location = await _createLocationForUserUseCase.Execute(userId, locationDto);
            Console.WriteLine($"Location successfully created for user with ID {userId}: {location.LocationID}");
            return CreatedAtAction(nameof(GetLocationById), new { id = location.LocationID }, location);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error creating location for user with ID {userId}: {ex.Message}");
            return NotFound(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error while creating location for user with ID {userId}: {ex.Message}");
            return StatusCode(500, new { error = "An unexpected error occurred." });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocationById(int id)
    {
        try
        {
            var location = await _getLocationByIdUseCase.Execute(id);
            if (location == null)
            {
                Console.WriteLine($"Location with ID {id} not found.");
                return NotFound(new { error = $"Location with ID {id} not found." });
            }
            Console.WriteLine($"Location with ID {id} retrieved successfully.");
            return Ok(location);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error while retrieving location with ID {id}: {ex.Message}");
            return StatusCode(500, new { error = "An unexpected error occurred." });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLocations()
    {
        try
        {
            var locations = await _getAllLocationsUseCase.Execute();
            Console.WriteLine($"Retrieved {locations.Count()} locations successfully.");
            return Ok(locations);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error while retrieving locations: {ex.Message}");
            return StatusCode(500, new { error = "An unexpected error occurred." });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationDto locationDto)
    {
        try
        {
            var updatedLocation = await _updateLocationUseCase.Execute(id, locationDto);
            if (updatedLocation == null)
            {
                Console.WriteLine($"Location with ID {id} not found for update.");
                return NotFound(new { error = $"Location with ID {id} not found." });
            }
            Console.WriteLine($"Location with ID {id} updated successfully.");
            return Ok(updatedLocation);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error while updating location with ID {id}: {ex.Message}");
            return StatusCode(500, new { error = "An unexpected error occurred." });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        try
        {
            var success = await _deleteLocationUseCase.Execute(id);
            if (!success)
            {
                Console.WriteLine($"Location with ID {id} not found for deletion.");
                return NotFound(new { error = $"Location with ID {id} not found." });
            }
            Console.WriteLine($"Location with ID {id} deleted successfully.");
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error while deleting location with ID {id}: {ex.Message}");
            return StatusCode(500, new { error = "An unexpected error occurred." });
        }
    }
}
