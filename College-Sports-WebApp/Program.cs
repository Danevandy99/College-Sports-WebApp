using College_Sports_WebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<SportsDataBasketballApiService>();

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

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CustomDbContext>();

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
    var dbContext = scope.ServiceProvider.GetRequiredService<CustomDbContext>();

    await dbContext.Database.MigrateAsync();
}

app.Run();
