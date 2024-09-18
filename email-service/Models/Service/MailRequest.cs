namespace email_service.Models.Service;

public class MailRequest
{
    public string Recepient { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}