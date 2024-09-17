using System.Text;
using Application.Microservices.FileService.Interfaces;
using Application.Microservices.FileService.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Microservices.FileService;

public class FileService(ILogger<FileService> logger) : IFileService
{
    private const string BaseUrl = "http://file-service:10002";


    public async Task<string> UploadFileAsync(byte[] file)
    {
        using var client = new HttpClient();
        var image = new ImageData { Image = Convert.ToBase64String(file) };
        var response = await client.PostAsync($"{BaseUrl}/api/files", new StringContent(JsonConvert.SerializeObject(image), Encoding.UTF8, "application/json"));
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            logger.LogError($"Failed to upload file. {content}");
        }

        return content;
    }

    public async Task<byte[]> DownloadFileAsync(string fileId)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync($"{BaseUrl}/api/files/{fileId}");
        var content = await response.Content.ReadAsByteArrayAsync();
        if (!response.IsSuccessStatusCode)
        {
            logger.LogError($"Failed to download file. {content}");
        }

        return content;
    }
}