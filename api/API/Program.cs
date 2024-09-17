/*
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();
app.MapSwagger();
app.UseSwaggerUI();
app.Run();
*/

using System.Text;
using Application.Extensions;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["Connections:Database"];
builder.Services.AddFluentMigrator(connectionString);
builder.Services.AddDapper();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {          
            ValidIssuer=builder.Configuration["Jwt:Issuer"],
            ValidateAudience = false,
            IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapSwagger();
app.UseSwaggerUI();
app.Services.UpdateDatabase();
app.Run();