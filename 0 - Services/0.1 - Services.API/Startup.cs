using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;


using AutoMapper;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Globalization;
using CrossCutting.IoC;

namespace Services.API
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IConfiguration _configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                options.Events = new JwtBearerEvents
                                {
                                    OnTokenValidated = context =>
                                    {
                                        // Add the access_token as a claim, as we may actually need it
                                        var accessToken = context.SecurityToken as JwtSecurityToken;
                                        if (accessToken != null)
                                        {
                                            ClaimsIdentity identity = context.Principal.Identity as ClaimsIdentity;

                                        }

                                        return Task.CompletedTask;
                                    }
                                };

                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                                    ValidateIssuer = false,
                                    ValidateAudience = false,
                                    ValidateLifetime = true,
                                    ValidateIssuerSigningKey = true,
                                    ValidIssuer = "*",
                                    ValidAudience = "*",
                                    IssuerSigningKey = new SymmetricSecurityKey(
                                    Encoding.UTF8.GetBytes(_configuration["SecurityKey"]))

                                };
                            });
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "API Reports",
                        Version = "v1",
                        Description = "Todos os recursos disponíveis.",
                        Contact = new Contact
                        {
                            Name = "Vinícius Alexandre Saraiva Silva",
                            Url = "valexandre@br.fujitsu.com"
                        }
                    });


                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;

                string caminhoXmlDoc = System.IO.Path.Combine(caminhoAplicacao, "api-g36.xml");

                c.IncludeXmlComments(caminhoXmlDoc);


                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                 options.SerializerSettings.ContractResolver
                 = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();              
            });

            Injector.InitRepository(services);

            Injector.InitDomainService(services);

            Injector.InitApplicationService(services);
        }
        
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {   
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();


            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            var cultureInfo = new CultureInfo("pt-BR");
            cultureInfo.NumberFormat.CurrencySymbol = "R$";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pessoas");
                c.RoutePrefix = "api/docs";                
                c.DocumentTitle("Corona Developers");                
                c.InjectStylesheet("/swagger/custom.css");
                c.DocExpansion("none");
            });

            

            app.UseCors("AllowSpecificOrigin");

            app.UseMvc();
        }
    }
}
