using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NadinTest.Core;
using NadinTest.Core.Infrastructure.Base;
using NadinTest.Core.Infrastructure.Users;
using NadinTest.Data;
using NadinTest.Data.Contracts;
using NadinTest.Data.Repositories;
using NadinTest.Service.Services;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
        option.UseSqlServer(builder.Configuration.GetConnectionString("sqlServer")));


//var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");

//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

//}).AddJwtBearer(
//               x =>
//               {
//                   x.RequireHttpsMetadata = false;
//                   x.SaveToken = true;
//                   x.TokenValidationParameters = new TokenValidationParameters
//                   {
//                       ValidateIssuerSigningKey = true,
//                       IssuerSigningKey = new SymmetricSecurityKey(key),
//                       ValidateAudience = false,
//                       ValidateIssuer = false,
//                   };
//               }
//                );



//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(cfg =>
//{
//    cfg.RequireHttpsMetadata = false;
//    cfg.SaveToken = true;
//    cfg.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
//        ValidAudience = builder.Configuration["JwtSettings:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"])),
//        ValidateIssuerSigningKey = true,
//        ValidateLifetime = true,
//        ClockSkew = TimeSpan.Zero
//    };
//    cfg.Events = new JwtBearerEvents
//    {
//        OnAuthenticationFailed = context =>
//        {
//            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
//            logger.LogError("Authentication failed.", context.Exception);
//            return Task.CompletedTask;
//        },
//        OnTokenValidated = context =>
//        {
//            var tokenValidatorService = context.HttpContext.RequestServices.GetRequiredService<ITokenValidatorService>();
//            return tokenValidatorService.ValidateAsync(context);
//        },
//        OnMessageReceived = context =>
//        {
//            return Task.CompletedTask;
//        },
//        OnChallenge = context =>
//        {
//            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
//            logger.LogError("OnChallenge error", context.Error, context.ErrorDescription);
//            return Task.CompletedTask;
//        }
//    };
//});



  builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
    };
});
builder.Services.AddMvc();



builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IJwtService, JwtService>();





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Nadin Test api" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
            
            },
            new string[] {}
          }
        });
});

builder.Services.AddControllers();




var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
