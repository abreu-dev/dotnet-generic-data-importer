using GenericImporter.Application.Interfaces;
using GenericImporter.Application.Services;
using GenericImporter.Domain.CommandHandlers;
using GenericImporter.Domain.Commands.XptoCommands;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using GenericImporter.Domain.Interfaces;
using GenericImporter.Infra.Data.Contexts;
using GenericImporter.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GenericImporter.Infra.CrossCutting.IoC
{

    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain - Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Domain - Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AddXptoCommand, Unit>, XptoCommandHandler>();

            // Infra Data - Contexts
            services.AddScoped<DataContext>();

            // Infra Data - Repositories
            services.AddScoped<IXptoRepository, XptoRepository>();

            // Application - AppServices
            services.AddScoped<IXptoAppService, XptoAppService>();

        }
    }
}
