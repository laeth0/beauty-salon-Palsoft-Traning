﻿using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Booking.API
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {

            var assembly = Assembly.GetExecutingAssembly();

            services.AddSwaggerAuthorizeOption();
            services.AddConfigCORS();
            services.AddCacheProfileService();
            services.AddEndpointsApiExplorer(); // Adds the default API explorer service just for minimal api.(EndPoint for minimal api يعني بضفلي سيرفيس انو يبحث جوا المشروع تاعي على )


            services.AddAutoMapper(assembly);


            services.AddValidatorsFromAssembly(assembly);
            services.AddFluentValidationAutoValidation();



            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(3);
            });


            services.AddProblemDetails(options =>
            {
                options.CustomizeProblemDetails = (context) =>
                {
                    context.ProblemDetails.Extensions["isSuccess"] = false;
                    context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
                };
            });


            return services;
        }





        public static IServiceCollection AddSwaggerAuthorizeOption(this IServiceCollection services)
        {

            // this configuration is for swagger to use JWT token for authorization
            // enable swagger authorize option


            /*
            AddSwaggerGen :-
            1.	Swagger Document Generation: Adds services required to generate Swagger documents.
            2.	UI Integration: Integrates the Swagger UI, which is a web-based interface that allows you to explore and test your API endpoints interactively. This is particularly useful for developers and testers.
            3.	Customization: Provides options to customize the generated Swagger document and UI. You can add descriptions, summaries, and other metadata to enhance the documentation.
            */
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Enter Bearer [space] and then your token in the text input below.",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                });


                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                // show this vedio  https://www.youtube.com/watch?v=lml_j5ujjeQ
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Travel and Accommodation Booking Platform",
                    Description = "Travel and Accommodation Booking Platform a comprehensive project transforming online hotel reservations. Dive into clean, secure APIs, emphasizing RESTful design, robust error handling, and secure JWT authentication.",
                    Contact = new OpenApiContact
                    {
                        Name = "Laeth Nueirat",
                        Email = "laethraed0@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/laethnueirat"),
                    }
                });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                options.IncludeXmlComments(xmlCommentsFullPath);

            });


            return services;
        }






        public static IServiceCollection AddConfigCORS(this IServiceCollection services)
        {
            services.AddCors(options =>

                options.AddDefaultPolicy(builder =>
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                        //.AllowCredentials()
                        )
            );

            return services;
        }




        public static IServiceCollection AddCacheProfileService(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.CacheProfiles.Add("Default60Sec", new CacheProfile
                {
                    Duration = 60,
                    Location = ResponseCacheLocation.Client,
                });

            })
                // Configures JsonOptions for the specified builder. Uses default values from JsonSeria1izerDefautts . 
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);//this line to ignore the loop reference in the json response

            return services;
        }




        public static ILoggingBuilder AddDefaultLoggingService(this ILoggingBuilder services)
        {
            services.ClearProviders(); // Clear all providers => the logging provider is Console, Debug, EventSource, EventLog ( Windows only )
            services.AddConsole(); // Add Console provider
            return services;
        }




    }
}
