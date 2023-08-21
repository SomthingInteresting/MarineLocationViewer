using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver; // Necessary for MongoDB

var builder = WebApplication.CreateBuilder(args);

// Load MongoDB configuration from appsettings.json
var mongoDbSettings = builder.Configuration.GetSection("MongoDB");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Add MongoDB services
builder.Services.AddScoped<MarineDataRepository>();
builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoDbSettings.GetSection("ConnectionString").Value));
builder.Services.AddScoped<IMongoDatabase>(sp => 
    sp.GetRequiredService<IMongoClient>().GetDatabase(mongoDbSettings.GetSection("DatabaseName").Value)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
