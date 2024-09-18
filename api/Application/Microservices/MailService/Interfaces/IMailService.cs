using Application.Microservices.MailService.Models;
using Domain.Entities;

namespace Application.Microservices.MailService.Interfaces;

public interface IMailService
{
    Task<string> Ping();
    Task SendMessage(MailRequest request);
}