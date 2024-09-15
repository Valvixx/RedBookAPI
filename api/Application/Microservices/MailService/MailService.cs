using Application.Microservices.MailService.Interfaces;

namespace Application.Microservices.MailService;

public class MailService : IMailService
{
    private readonly string _baseUrl = "http://email-service:8080";
    private readonly HttpClient _client;

    public MailService()
    {
        _client = new HttpClient();
    }
    
    public async Task<string> Ping()
    {
        var response = await _client.GetAsync($"{_baseUrl}/mail/ping");
        var content = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to ping email-service");
        }

        return content;
    }
}