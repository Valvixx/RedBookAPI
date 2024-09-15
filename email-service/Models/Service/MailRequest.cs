namespace email_service.Models.Service;

public class MailRequest
{
    public string From { get; set; }
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<IFormFile>? Attachments { get; set; }
}