using College_Sports_WebApp.Database;
using College_Sports_WebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<SportsDataBasketballApiService>();
builder.Services.AddScoped<ESPNApiService>();

var sportsDataApiKey = builder.Configuration["SportsDataApiKey"];

builder.Services.AddHttpClient<SportsDataBasketballApiService>(client =>
    {
        client.BaseAddress = new Uri("https://api.sportsdata.io/v3/cbb/");

        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", sportsDataApiKey);
    })
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new SocketsHttpHandler()
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(15)
        };
    })
    .SetHandlerLifetime(Timeout.InfiniteTimeSpan);

builder.Services.AddHttpClient<ESPNApiService>(client => 
    {
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.97 Safari/537.11");
        client.DefaultRequestHeaders.Add("ContentType", "application/x-www-form-urlencoded");
        client.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
        client.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip,deflate,sdch");
        client.DefaultRequestHeaders.AcceptLanguage.ParseAdd("en-GB,en-US;q=0.8,en;q=0.6");
        client.DefaultRequestHeaders.AcceptCharset.ParseAdd("ISO-8859-1,utf-8;q=0.7,*;q=0.3");
    });

builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<BaseDbContext, SqliteDbContext>();
}
else
{
    builder.Services.AddDbContext<BaseDbContext, MySQLDbContext>();
}


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BaseDbContext>();

    await dbContext.Database.MigrateAsync();
}

app.Run();
