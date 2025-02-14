
using DTOs;
namespace EcoUme.Services;

public class HttpChatService : IChatService
{
    private readonly HttpClient _httpClient;

    public HttpChatService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Send a message to the backend API
    public async Task SendMessage(MessageDto message)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("chat/send", message);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            // Log or handle the exception if needed
            Console.WriteLine($"Error sending message: {ex.Message}");
            throw;
        }
    }

    // Get chat history for a specific user
    public async Task<List<MessageDto>> GetChatHistory(string userId1, string userId2)
    {
        try
        {
            var response = await _httpClient.GetAsync($"chat/history?userId1={userId1}&userId2={userId2}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                var mappedResponse = await response.Content.ReadFromJsonAsync<ChatHistoryResponse>() ?? new ChatHistoryResponse();
                return (mappedResponse.Data is not null) ? mappedResponse.Data : [];
            }

            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Failed to fetch chat history. Status Code: {response.StatusCode}, Error: {error}");
            return new List<MessageDto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching chat history: {ex.Message}");
            return new List<MessageDto>();
        }
    }

    // Receive new messages for a specific receiver (real-time support)
    public async Task<List<MessageDto>> ReceiveMessages(string receiverId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<MessageDto>>($"chat/receive?receiverId={receiverId}");
            return response ?? new List<MessageDto>();
        }
        catch (Exception ex)
        {
            // Log or handle the exception if needed
            Console.WriteLine($"Error receiving messages: {ex.Message}");
            return new List<MessageDto>();
        }
    }

    // Get full conversation between two users (useful for large chats or backups)
    public async Task<List<MessageDto>> GetConversation(string userId1, string userId2)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<MessageDto>>($"chat/conversation?userId1={userId1}&userId2={userId2}");
            return response ?? new List<MessageDto>();
        }
        catch (Exception ex)
        {
            // Log or handle the exception if needed
            Console.WriteLine($"Error fetching conversation: {ex.Message}");
            return new List<MessageDto>();
        }
    }
    
    public async Task<int> GetUnreadMessagesCount(string receiverId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<UnreadMessagesResponse>($"chat/unreadMessages?receiverId={receiverId}");
        
            if (response != null && response.Success)
            {
                return response.UnreadCount;
            }

            // If no response or failure, return 0
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching unread messages: {ex.Message}");
            return 0;
        }
    }

    public async Task<List<int>> GetChatHistoryUserIds(string receiverId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<int>>($"chat/chattedWith?receiverId={receiverId}");

            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching unread messages: {ex.Message}");
            return [];
        }
    }

    // Define response model
    private class UnreadMessagesResponse
    {
        public bool Success { get; set; }
        public int UnreadCount { get; set; }
    }
}