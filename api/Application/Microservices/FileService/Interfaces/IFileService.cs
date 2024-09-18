namespace Application.Microservices.FileService.Interfaces;

public interface IFileService
{
    Task<string> UploadFileAsync(byte[] file);
    Task<byte[]> DownloadFileAsync(Guid fileId);
    Task<string> GetLinkById(Guid fileId);
}