using AutoDependencyRegistration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using noo.api.Core.DataAbstraction;
using noo.api.Core.Request;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
builder.Services.AddAuthorization();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 25))));

builder.Services.AutoRegisterDependencies();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Development environment");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    Console.WriteLine("Production environment");
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.UseAddContextMiddleware();
app.MapControllers();

app.Run();
