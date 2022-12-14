using ApiCatalogo.Context;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>                          //Classe importante 
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //Utilizando para ignorar ciclos infinitos dentro dos objetos
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection"); //instancia da string de conexao
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(mySqlConnection));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();//Classe importante

app.Run();
