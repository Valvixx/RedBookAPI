using email_service.Models.Service;

namespace email_service.Services.Interfaces;

public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);
}