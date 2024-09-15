﻿using Application.Microservices.MailService;
using Application.Microservices.MailService.Interfaces;
using Application.Services;
using Infrastructure.Dapper;
using Infrastructure.Dapper.Interfaces;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {

        services.AddScoped<IBookElementRepository, BookElementRepository>();
        services.AddScoped<IBookElementService, BookElementService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IDapperSettings, DapperSettings>();
        services.AddScoped<IDapperContext, DapperContext>();
        
        return services;
    }
}