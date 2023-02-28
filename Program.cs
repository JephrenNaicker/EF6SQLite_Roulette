using EF6SQLite_Roulette.Data;
using EF6SQLite_Roulette.Logic.Interface;
using EF6SQLite_Roulette.Logic.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>c.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo
{
    Title = "Roulette API",
    Description = "A Simple Web API that allows you to play the roulette game",
    Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "Jephren Naicker",Email = "Jeph144@gmail.com"},Version ="v1"
}));
builder.Services.AddDbContext<RouletteDbContext>(options =>
                 options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
//Di
builder.Services.AddTransient<IRouletteDbServices, RouletteDbServices>();
builder.Services.AddTransient<IWheelBaordServices, WheelBoardService> ();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   
}
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
