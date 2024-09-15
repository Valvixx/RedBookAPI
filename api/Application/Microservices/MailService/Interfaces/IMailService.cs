namespace Application.Microservices.MailService.Interfaces;

public interface IMailService
{
    Task<string> Ping();
}