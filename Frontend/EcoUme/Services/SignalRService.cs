using Microsoft.AspNetCore.SignalR.Client;

namespace EcoUme.Services;

public class SignalRService
{
    private readonly string _hubUrl;
    private readonly TokenStorageService _tokenStorageService;
    private HubConnection? _hubConnection;

    public SignalRService(string hubUrl, TokenStorageService tokenStorageService)
    {
        _hubUrl = hubUrl;
        _tokenStorageService = tokenStorageService;
    }

    private async Task InitializeConnection()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(_hubUrl, options =>
            {
                options.AccessTokenProvider = async () =>
                {
                    var token = await _tokenStorageService.GetTokenAsync();
                    Console.WriteLine($"Access Token: {token}"); // Debugging
                    return token;
                };
            })
            .WithAutomaticReconnect()
            .Build();
    }


    public async Task StartConnection()
    {
        await InitializeConnection();
        if (_hubConnection == null)
            throw new InvalidOperationException("HubConnection is not initialized.");

        if (_hubConnection.State == HubConnectionState.Disconnected)
        {
            await _hubConnection.StartAsync();
            Console.WriteLine("SignalR connection started.");
        }
    }

    public async Task StopConnection()
    {
        if (_hubConnection != null && _hubConnection.State == HubConnectionState.Connected)
        {
            await _hubConnection.StopAsync();
            Console.WriteLine("SignalR connection stopped.");
        }
    }

    public async Task SendMessage(string senderId, string receiverId, string message)
    {
        if (_hubConnection == null || _hubConnection.State != HubConnectionState.Connected)
        {
            throw new InvalidOperationException("Cannot send message. SignalR is not connected.");
        }

        await _hubConnection.SendAsync("SendMessage", senderId, receiverId, message);
    }

    public void OnMessageReceived(Action<string, string, string> messageHandler)
    {
        if (_hubConnection == null)
            throw new InvalidOperationException("HubConnection is not initialized.");

        _hubConnection.On<string, string, string>("ReceiveMessage", messageHandler);
    }

    public bool IsConnected()
    {
        return _hubConnection?.State == HubConnectionState.Connected;
    }
}