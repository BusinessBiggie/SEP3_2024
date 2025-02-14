using DTOs;
using Microsoft.AspNetCore.Components.Forms;

namespace EcoUme.Services
{
    public interface IListingsService
    {
        // Listing retrieval methods
        Task<PagedResult<ListingDto>> GetAllListingsAsync(int page = 1, int pageSize = 10);

        Task<PagedResult<ListingDto>> GetListingsByUserAsync(int sellerId, int page = 1, int pageSize = 10);
        Task<ListingDto> GetListingByIdAsync(int id); // Get a single listing by ID

        // Listing modification methods
        Task CreateListingWithFileAsync(CreateListingRequest request, Stream? fileStream, string fileName); // Create listing with file
        Task UpdateListingAsync(int id, UpdateListingRequest request, IFormFile? file = null); // Update listing
        Task DeleteListingAsync(int id); // Delete listing

        // File management methods
        Task<string> UploadFileAsync(IBrowserFile file); // Upload a file
        Task<Stream> GetFileAsync(string filename); // Get a file by filename
    }
}