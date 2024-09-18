using email_service.Models.Service;
using email_service.Services;
using email_service.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.Run();