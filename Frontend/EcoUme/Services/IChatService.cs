
using DTOs;
using Smart.Blazor;

namespace EcoUme.Services;

public interface IChatService
{
    Task SendMessage(MessageDto message);
    Task<List<MessageDto>> GetChatHistory(string userId, string userId2);
    Task<List<MessageDto>> GetConversation(string userId1, string userId2);
    Task<List<MessageDto>> ReceiveMessages(string receiverId);
    Task<int> GetUnreadMessagesCount(string receiverId);
    Task<List<int>> GetChatHistoryUserIds(string receiverId);

}