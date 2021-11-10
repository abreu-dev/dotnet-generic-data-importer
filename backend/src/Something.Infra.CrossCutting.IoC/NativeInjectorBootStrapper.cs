using Something.Application.Interfaces;
using Something.Application.Services;
using Something.Domain.CommandHandlers;
using Something.Domain.Commands.XptoCommands;
using Core.Domain.Mediator;
using Core.Domain.Notifications;
using Something.Domain.Interfaces;
using Something.Infra.Data.Contexts;
using Something.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using GenericImporter.Service.Helpers;

namespace Something.Infra.CrossCutting.IoC
{

    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain - Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IImportAttributeHelper, ImportAttributeHelper>();

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
