using System;
using Domain.Commands.Cars;
using Domain.Events.Cars;
using Domain.Shared.Handlers;
using Domain.Shared.Interfaces.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC
{
    public static class Injector
    {

        public static void AddInjectorProject(this IServiceCollection services)
        {
           //Domain Bus
           services.AddScoped<IMediatorHandler,MediatorHandler>();

           InitRepositories(services);  
           InitDomainServices(services);
           InitApplicationServices(services);
           InitDomainCommands(services);
           InitDomainEvents(services);
        }

        public static void InitDomainCommands(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<CreateCarCommand>,CarCommandHandler>();
            services.AddScoped<INotificationHandler<DeleteCarCommand>,CarCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateCarCommand>,CarCommandHandler>();

        }  

        public static void InitDomainEvents(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<CreateCarEvent>,CarEventHandler>();
            services.AddScoped<INotificationHandler<DeleteCarEvent>,CarEventHandler>();
            services.AddScoped<INotificationHandler<UpdateCarEvent>,CarEventHandler>();
        }
        public static void InitRepositories(IServiceCollection services)
        {
            //services.AddScoped<IProfissaoRepository, ProfissaoRepository>();           
        }

        public static void InitDomainServices(IServiceCollection services)
        {
            
        }  

        public static void InitApplicationServices(IServiceCollection services)
        {
            
        }   

           

    }
}
