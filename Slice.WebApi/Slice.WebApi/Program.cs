using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Slice.WebApi.Models;
using Slice.WebApi.Models.Entities;
using System.Text;

namespace Slice.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //// Retrieve the JWT key from our environment variables
            //var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY") ?? builder.Configuration["Jwt:Key"];
            //var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();

            //if (string.IsNullOrWhiteSpace(jwtKey) || jwtKey == "your_secret_key_here")
            //{
            //    logger.LogError("JWT Key has not been configured correctly.");
            //    throw new InvalidOperationException("JWT Key has not been configured correctly.");
            //}

            //logger.LogInformation($"JWT Key: {jwtKey}");

            //// Ensure the key is at least 256-bit
            //if (jwtKey.Length < 32)
            //{
            //    logger.LogError("JWT Key must be at least 256-bit (32 characters) long.");
            //    throw new InvalidOperationException("JWT Key must be at least 256-bit (32 characters) long.");
            //}

            builder.Services.AddAuthorization();

            //Config our db context for Identity
            builder.Services.AddIdentityApiEndpoints<User>()
               .AddEntityFrameworkStores<ApplicationDbContext>();

            ////JWT Authentication 
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            //        ValidateIssuer = true,
            //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //        ValidateAudience = true,
            //        ValidAudience = builder.Configuration["Jwt:Audience"],
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero
            //    };

            //});

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                    }
                });
            });

            var app = builder.Build();

            // Map Identity API endpoints
            app.MapIdentityApi<User>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            //app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}