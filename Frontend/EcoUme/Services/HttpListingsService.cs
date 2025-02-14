using System.Net.Http.Headers;
using DTOs;
using HeyRed.Mime;
using Microsoft.AspNetCore.Components.Forms;

namespace EcoUme.Services;

public class HttpListingsService : IListingsService
{
    private readonly HttpClient _httpClient;
    private readonly TokenStorageService _tokenStorage;

    public HttpListingsService(HttpClient httpClient, TokenStorageService tokenStorage)
    {
        _httpClient = httpClient;
        _tokenStorage = tokenStorage;
    }
    
    private async Task AddAuthorizationHeader()
    {
        var token = await _tokenStorage.GetTokenAsync();
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    // Get all listings (paginated)
    public async Task<PagedResult<ListingDto>> GetAllListingsAsync(int page = 1, int pageSize = 10)
    {
        var response = await _httpClient.GetFromJsonAsync<PagedResult<ListingDto>>($"api/listings/all?page={page}&pageSize={pageSize}");
        if (response == null)
        {
            throw new Exception("Failed to fetch listings.");
        }
        return response;
    }

    // Get listings by user (paginated)
    public async Task<PagedResult<ListingDto>> GetListingsByUserAsync(int sellerId, int page = 1, int pageSize = 10)
    {
        await AddAuthorizationHeader();

        var response = await _httpClient.GetFromJsonAsync<PagedResult<ListingDto>>($"api/listings/user?sellerId={sellerId}&page={page}&pageSize={pageSize}");
        if (response == null)
        {
            throw new Exception("Failed to fetch user listings.");
        }
        return response;
    }

    // Get a single listing by ID
    public async Task<ListingDto> GetListingByIdAsync(int id)
    {
        await AddAuthorizationHeader();

        // Step 1: Fetch the listing from Listing Microservice
        var listing = await _httpClient.GetFromJsonAsync<ListingDto>($"api/listings/{id}");
        if (listing == null)
        {
            throw new KeyNotFoundException($"Listing with ID {id} not found.");
        }

        // Step 2: Fetch the seller's name from User Microservice
        var usersService = new HttpUsersService(_httpClient); // You may also inject IUsersService if needed
        var user = await usersService.GetUserByIdAsync(listing.SellerId);

        // Step 3: Update seller name in the DTO
        listing.SellerName = user?.Username ?? "Unknown Seller";

        return listing;
    }

    public async Task CreateListingWithFileAsync(CreateListingRequest request, Stream? fileStream, string fileName)
    {
        await AddAuthorizationHeader();
        using var content = new MultipartFormDataContent();

        // Add form fields
        content.Add(new StringContent(request.ProductName), "ProductName");
        content.Add(new StringContent(request.SellerId.ToString()), "SellerId");
        content.Add(new StringContent(request.SellerName), "SellerName");
        content.Add(new StringContent(request.Price.ToString()), "Price");
        content.Add(new StringContent(request.Quantity.ToString()), "Quantity");
        content.Add(new StringContent(request.Description), "Description");
        content.Add(new StringContent(request.Condition), "Condition");
        content.Add(new StringContent(request.Category), "Category");

        // Add the file with MIME type detection
        if (fileStream != null)
        {
            string mimeType = MimeTypesMap.GetMimeType(fileName); // Detect MIME type
            if (string.IsNullOrEmpty(mimeType))
            {
                mimeType = "application/octet-stream"; // Default fallback
            }

            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mimeType);
            content.Add(fileContent, "file", fileName);
        }

        // Send the POST request
        var response = await _httpClient.PostAsync("api/listings/create", content);
        response.EnsureSuccessStatusCode();
    }



    // Update a listing with or without a file
    public async Task UpdateListingAsync(int id, UpdateListingRequest request, IFormFile? file = null)
    {
        await AddAuthorizationHeader();
        using var content = new MultipartFormDataContent();

        // Add form data fields
        content.Add(new StringContent(request.ProductName), "ProductName");
        content.Add(new StringContent(request.Price.ToString()), "Price");
        content.Add(new StringContent(request.Quantity.ToString()), "Quantity");
        content.Add(new StringContent(request.Description), "Description");
        content.Add(new StringContent(request.Category), "Category");
        content.Add(new StringContent(request.Condition), "Condition");
        if(!string.IsNullOrEmpty(request.ImageUrl))
        {
            content.Add(new StringContent(request.ImageUrl), "ImageUrl");
        }

        // Add file if provided
        if (file != null)
        {
            var fileStream = file.OpenReadStream();
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            content.Add(fileContent, "file", file.FileName);
        }

        // Send PUT request to backend
        var response = await _httpClient.PutAsync($"api/listings/{id}", content);

        // Ensure the request succeeded
        response.EnsureSuccessStatusCode();
    }

    // Delete a listing
    public async Task DeleteListingAsync(int id)
    {
        await AddAuthorizationHeader();
        var response = await _httpClient.DeleteAsync($"api/listings/{id}");
        response.EnsureSuccessStatusCode();
    }

    // Upload a file (optional if handled within CreateListingWithFileAsync)
    public async Task<string> UploadFileAsync(IBrowserFile file)
    {
        using var content = new MultipartFormDataContent();

        // Add file data
        var fileStream = file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024); // Adjust max size if necessary
        var streamContent = new StreamContent(fileStream);
        streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

        content.Add(streamContent, "file", file.Name);

        // Send POST request to upload file
        var response = await _httpClient.PostAsync("api/listings/upload", content);

        // Ensure the request succeeded
        response.EnsureSuccessStatusCode();

        // Return the uploaded file URL
        var result = await response.Content.ReadFromJsonAsync<UploadResponse>();
        return result?.FileUrl ?? string.Empty;
    }

    // Get a file by filename
    public async Task<Stream> GetFileAsync(string filename)
    {
        await AddAuthorizationHeader();
        var response = await _httpClient.GetAsync($"api/listings/files/{filename}", HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStreamAsync();
    }

}

public class UploadResponse
{
    public string? FileUrl { get; set; }
}