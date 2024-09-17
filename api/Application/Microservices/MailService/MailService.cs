using Application.Microservices.MailService.Interfaces;
using Application.Microservices.MailService.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Microservices.MailService;

public class MailService(ILogger<MailService> logger) : IMailService
{
    private const string BaseUrl = "http://email-service:8080";
    private readonly HttpClient _client = new();

    public async Task<string> Ping()
    {
        var response = await _client.GetAsync($"{BaseUrl}/mail/ping");
        var content = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            logger.LogError($"Failed to ping email-service");
        }

        return content;
    }

    public async Task SendMessage(MailRequest request)
    {
        var content = new StringContent(JsonConvert.SerializeObject(request));
        var response = await _client.PostAsync($"{BaseUrl}/mail/send", content);

        if (!response.IsSuccessStatusCode)
        {
            logger.LogError($"Failed to send mail message");
        }
    }
}