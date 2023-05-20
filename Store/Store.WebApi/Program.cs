using Store.Application;
using Store.Infrastructure.Persistence;
using Store.Infrastructure.Persistence.Extensions;
using Store.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddApplicationLayer();
builder.Services.AddServices();
builder.Services.AddPersistence(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ChechOpenStoreMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
