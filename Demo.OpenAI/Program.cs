using Demo.OpenAI.Options;
using Demo.OpenAI.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

builder.Services.Configure<RequestOptions>(options =>
    config.GetSection(nameof(RequestOptions)).Bind(options));

builder.Services.AddScoped<IOpenAIService, OpenAIService>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
