using AutoFinder.API.Custom;
using AutoFinder.API.Middleware;
using AutoFinder.Application.Resource;
using AutoFinder.Application;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using AutoFinder.Services;
using AutoFinder.Infrastructure.Persistence;
using AutoFinder.API.CustomExceptionMiddleware;

namespace AutoFinder.API
{
    namespace ExpertFinder.API
    {
        public class Startup
        {

            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }
            public void ConfigureServices(IServiceCollection services)
            {

                if (!string.IsNullOrEmpty(Configuration["AllowedOrigins"]))
                {
                    services.AddCors(options =>
                    {
                        options.AddPolicy("AutoFunder",
                            builder =>
                            {

                                builder.AllowAnyOrigin()
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod();
                            });
                    });
                }

                services.AddMvc()
                 .ConfigureApiBehaviorOptions(options =>
                 {
                     options.InvalidModelStateResponseFactory = context =>
                     {
                         var problems = new CustomBadRequest(context);
                         throw new BadHttpRequestException(problems.Detail);
                     };
                 });

                services.AddMemoryCache();
                services.AddApplicationServices();
                services.AddCoreServices();
                services.AddPersistanceServices();
                services.AddSettings(Configuration);


                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = CommonMessages.SwaggerTitle, Version = "v1.0.0" });
                    //add API Key to swagger
                    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                    {
                        Description = CommonMessages.ApiKeyInHeader,
                        Type = SecuritySchemeType.ApiKey,
                        Name = GenericStrings.ApiKeyCaption,
                        In = ParameterLocation.Header,
                        Scheme = "ApiKeyScheme"
                    });
                    var key = new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        },
                        In = ParameterLocation.Header
                    };
                    var requirement = new OpenApiSecurityRequirement
                    {
                             { key, new List<string>() }
                    };
                    options.AddSecurityRequirement(requirement);
                });

            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> _logger)
            {

                app.UseCors("AutoFinder");

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseCustomExceptionHandler();
                }
                app.UseHttpsRedirection();
                app.UseRouting();

                app.UseAuthentication();
                app.UseAuthorization();


                app.Use((context, next) =>
                {
                    Thread.CurrentPrincipal = context.User;
                    return next(context);
                });

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auto Finder");
                    c.ConfigObject = new ConfigObject
                    {
                        ShowCommonExtensions = true
                    };

                });

                //API key check Middleware
                app.UseMiddleware<ApiKeyMiddleware>();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
}
