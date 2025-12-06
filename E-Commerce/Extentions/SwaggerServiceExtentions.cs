using Microsoft.OpenApi.Models;

namespace E_Commerce.Extentions
{
    public static class SwaggerServiceExtentions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services) {

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",new OpenApiInfo() {Title="ApiStore",Version="v1" });
           

            var securitySchema = new OpenApiSecurityScheme
            {
                Description = "Jwt authorization header using the bearer scheme ",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearer"
                }

            };

                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement {
                    {securitySchema,new []{"bearer" } }
                };


            });


            return services;
        }

    }
}
