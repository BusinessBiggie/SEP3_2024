
using DTOs;


namespace EcoUme.Services
{
    public class HttpUsersService : IUsersService
    {
        private readonly HttpClient _httpClient;

        public HttpUsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDTO?> GetUserByIdAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/users/{userId}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<UserDTO>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching user by ID: {ex.Message}");
                return null;
            }
        }

        public async Task<UserDTO?> GetUserByEmailAsync(string email)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/users/by-email?email={Uri.EscapeDataString(email)}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<UserDTO>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching user by email: {ex.Message}");
                return null;
            }
        }

        public async Task CreateUserAsync(CreateUserDTO createUserDTO)
        {
            if (createUserDTO.Username.Length > 25)
            {
                throw new ArgumentException("Username is too long. Maximum length is 25 characters.");
            }
            
            if (!createUserDTO.Password.Equals(createUserDTO.ConfirmPassword))
            {
                throw new ArgumentException("Passwords do not match.");
            }

            if (!createUserDTO.Email.Equals(createUserDTO.ConfirmEmail))
            {
                throw new ArgumentException("Email and confirmation email do not match.");
            }
            
            
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/users/register", createUserDTO);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                var errorMessage = $"An error occurred while creating the user: {ex.Message}";
                throw new Exception(errorMessage, ex);

            }
        }

        public async Task UpdateUserAsync(int userId, UpdateUserDTO updateUserDTO)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/users/{userId}", updateUserDTO);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/users/{userId}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
            }
        }
        
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/users");
                response.EnsureSuccessStatusCode();

                var users = await response.Content.ReadFromJsonAsync<List<UserDTO>>();
                return users ?? new List<UserDTO>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching users: {ex.Message}");
                throw;
            }
        }


        public async Task<LoginResponseDTO?> LoginAsync(LoginUserDTO loginUserDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/users/login", loginUserDTO);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Login error: {ex.Message}");
                return null;
            }
        }

        public async Task<List<UserDTO>> GetAllUsersByListOfIdsAsync(List<int> userIds)
        {
            try
            {
                string queryString = string.Join("&", userIds.Select(id => $"ids={id}"));

                // Full example for an endpoint
                var response = await _httpClient.GetAsync($"api/users/listOnIds?{queryString}");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Something went wrong when fetching list of users based on IDs");
                    return [];
                }

                var users = await response.Content.ReadFromJsonAsync<List<UserDTO>>();
                return users ?? new List<UserDTO>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
                return [];
            }
        }
    }
}