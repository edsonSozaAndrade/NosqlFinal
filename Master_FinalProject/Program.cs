using ApiManager.Implementation;
using ApiManager.Interface;
using DataAccess;
using DataAccess.Implementation;
using DataAccess.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
           
builder.Services.AddScoped<IFoodDataAccess, FoodDataAccess>();
builder.Services.AddScoped<IFoodManager, FoodManager>();
builder.Services.AddScoped<IPhoneticManager, PhoneticManager>();

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
