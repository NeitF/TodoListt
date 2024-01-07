using Microsoft.EntityFrameworkCore;
using TodoList.Core.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");
var MySqlServerVersion = new MySqlServerVersion(new Version(8, 0, 35));

builder.Services.AddDbContext<TodoListContext>(options 
	=> options.UseMySql(ConnectionString, MySqlServerVersion, b => b.MigrationsAssembly("TodoList.Core")));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
