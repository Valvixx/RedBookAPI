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

using Application.Extensions;
using Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["Connections:Database"];
builder.Services.AddFluentMigrator(connectionString);
builder.Services.AddDapper();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.MapControllers();
app.MapSwagger();
app.UseSwaggerUI();
app.Services.UpdateDatabase();
app.Run();