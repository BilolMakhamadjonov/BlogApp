using Blog.Application;
using Blog.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDataAccess(configuration);

builder.Services.AddApplicationServices(configuration);


builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy =>
        {
            policy.WithOrigins("https://localhost:7137") // Blazor URL
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
/////
app.UseCors("AllowBlazor");





app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
