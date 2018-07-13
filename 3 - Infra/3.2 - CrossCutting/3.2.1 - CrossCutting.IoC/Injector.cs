using System;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC
{
    public static class Injector
    {

        public static void InitRepository(IServiceCollection services)
        {
            //services.AddScoped<IProfissaoRepository, ProfissaoRepository>();           
        }

        public static void InitDomainService(IServiceCollection services)
        {
            
        }  

        public static void InitApplicationService(IServiceCollection services)
        {
            
        }    

    }
}
