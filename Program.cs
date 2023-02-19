using Microsoft.EntityFrameworkCore;
using API.Data.Collector.Models;
using System.Configuration;
using API.Data.Collector.Data.Services;
using Sentry;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseSentry();

// Add services to the container.

builder.Services.AddControllers();

var connectionString_Ticker = builder.Configuration.GetConnectionString("ConnectionString2");

builder.Services.AddDbContext<TickerNamesContext>(opt => opt.UseSqlServer(connectionString_Ticker));
builder.Services.AddDbContext<TickerPricesContext>(opt => opt.UseSqlServer(connectionString_Ticker));
builder.Services.AddDbContext<TickerVolumesContext>(opt => opt.UseSqlServer(connectionString_Ticker));
builder.Services.AddDbContext<TickerPurchaseContext>(opt => opt.UseSqlServer(connectionString_Ticker));
builder.Services.AddDbContext<CurrencyExchangeRateContext>(opt => opt.UseSqlServer(connectionString_Ticker));
builder.Services.AddDbContext<PortfolioContext>(opt => opt.UseSqlServer(connectionString_Ticker));

builder.Services.AddTransient<TickerNamesService>();
builder.Services.AddTransient<TickerVolumesService>();
builder.Services.AddTransient<TickerPurchaseService>();
builder.Services.AddTransient<TickerPricesService>();
builder.Services.AddTransient<MarketNewsService>();
builder.Services.AddTransient<StockService>();
builder.Services.AddTransient<CurrencyService>();
builder.Services.AddTransient<PortfolioService>();

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSentryTracing();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=TickerItems}/{action=Index}/{id?}");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
