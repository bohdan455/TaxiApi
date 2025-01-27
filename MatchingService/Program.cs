using MatchingService.Services.Services;
using MatchingService.Services.Services.Interfaces;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDatabase>(cfg =>
{
    IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect($"{builder.Configuration["Redis:Url"]}");
    return multiplexer.GetDatabase();
});
builder.Services.AddScoped<IRideService, RideService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();