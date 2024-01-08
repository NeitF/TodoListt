using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Core.Context;

var config = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.Development.json")
    .Build();

var services = new ServiceCollection();
var ConnectionString = config.GetConnectionString("ConexaoPadrao");
var MySqlServerVersion = new MySqlServerVersion(new Version(8, 0, 35));

services.AddDbContext<TodoListContext>(options => options.UseMySql(ConnectionString, MySqlServerVersion));

var serviceProvider = services.BuildServiceProvider(); 
var context = serviceProvider.GetService<TodoListContext>();

