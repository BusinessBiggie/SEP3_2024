using System.IdentityModel.Tokens.Jwt;
using DTOs;
using Microsoft.JSInterop;

namespace EcoUme.Services;

public class TokenStorageService
{
    
    private readonly IJSRuntime _jsRuntime;
    private const string TokenKey = "jwtToken";
    private const string UserKey = "jwtUser";

    public TokenStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task SaveTokenAsync(string token)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, token);
    }

    public async Task<string?> GetTokenAsync()
    {
        return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", TokenKey);
    }

    public async Task ClearTokenAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", UserKey);
    }
    
    public async Task SaveCurrentUserAsync(LoginResponseDTO user)
    {
        var userJson = System.Text.Json.JsonSerializer.Serialize(user);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", UserKey, userJson);
    }

    public async Task<LoginResponseDTO> GetCurrentUserAsync()
    {
        // Retrieve the JSON string from localStorage
        var userJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", UserKey);
    
        // Check if the userJson is null or empty
        if (string.IsNullOrEmpty(userJson))
        {
            return null;
        }

        // Deserialize the JSON string back into a LoginResponseDTO object
        return System.Text.Json.JsonSerializer.Deserialize<LoginResponseDTO>(userJson);
    }

    public async Task<int> GetCurrentSellerIdAsync()
    {
        // Extract claims from the token
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(await this.GetTokenAsync());

        return int.Parse(jwtToken.Claims.First(c => c.Type == "sub").Value);
        //_sellerName = jwtToken.Claims.First(c => c.Type == "unique_name").Value;
    }
}
