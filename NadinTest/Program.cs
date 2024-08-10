using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NadinTest.Core.Infrastructure.Base;
using NadinTest.Core.Infrastructure.Users;
using NadinTest.Data;
using NadinTest.Data.Contracts;
using NadinTest.Data.Repositories;
using NadinTest.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option => 
        option.UseSqlServer(builder.Configuration.GetConnectionString("sqlServer")));
builder.Services.AddScoped<IUserService , UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductService , ProductService>();
builder.Services.AddScoped<IRepository, Repository>();


builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
