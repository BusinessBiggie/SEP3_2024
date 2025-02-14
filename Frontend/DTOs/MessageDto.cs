namespace DTOs;


public class ChatHistoryResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public List<MessageDto> Data { get; set; }
}

public class MessageDto
{
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
}

