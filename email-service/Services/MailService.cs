using email_service.Models.Service;
using email_service.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace email_service.Services;

public class MailService : IMailService
{
    private readonly MailSettings _mailSettings;

    public MailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }
    
    public async Task SendEmailAsync(MailRequest mailRequest)
    {
        var email = new MimeMessage
        {
            Sender = MailboxAddress.Parse(_mailSettings.Username),
            To = { MailboxAddress.Parse(mailRequest.Recepient) },
            Subject = mailRequest.Subject
        };

        var builder = new BodyBuilder();

        // if (mailRequest.Attachments != null)
        // {
        //     byte[] fileBytes;
        //     
        //     foreach (var file in mailRequest.Attachments)
        //     {
        //         using var ms = new MemoryStream();
        //         file.CopyTo(ms);
        //         fileBytes = ms.ToArray();
        //         builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
        //     }
        // }

        builder.HtmlBody = mailRequest.Body;
        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_mailSettings.Username, _mailSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}