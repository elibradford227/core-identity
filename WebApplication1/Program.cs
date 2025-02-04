using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Extensions;
using WebApplication1.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<WebApp1DbContext>()
    .AddApiEndpoints();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebApp1DbContext>(options =>
   options.UseNpgsql(builder.Configuration["WebappDbConnectionString"]));
//builder.Services.AddNpgsql<WebApp1DbContext>(builder.Configuration["WebappDbConnectionString"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
    //app.MapOpenApi():
}

app.Urls.Add("http://0.0.0.0:8080");  
app.Urls.Add("https://0.0.0.0:8081"); 

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
