using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Core.Context;
using TodoList.Core.Enum;
using TodoList.Core.Entities;

public class ConsoleProgram
{
    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var services = new ServiceCollection();
        var ConnectionString = config.GetConnectionString("ConexaoPadrao");
        var MySqlServerVersion = new MySqlServerVersion(new Version(8, 0, 35));

        services.AddDbContext<TodoListContext>(options => options.UseMySql(ConnectionString, MySqlServerVersion));

        var serviceProvider = services.BuildServiceProvider(); 
        var context = serviceProvider.GetService<TodoListContext>();

        Console.WriteLine($"Sistema operacional: {{RuntimeInformation.OSDescription}}");
        Console.WriteLine("Lista de tarefas a fazer\n");

        while (true)
        {
            ExibirMenu();
            Enum.TryParse(Console.ReadLine(), true, out OpcaoMenuEnum opcao);
            ProcessarEscolha(opcao, context);
        }
        
        
    }         
    internal static void ExibirMenu()
    {
        Console.WriteLine(new string('=', 30));

        Console.WriteLine("Menu:");
        Console.WriteLine("1 - Adicionar tarefa\n" +
                            "2 - Remover tarefa\n" +
                            "3 - Editar tarefa\n" +
                            "4 - Marcar tarefa como completa\n" +
                            "5 - Ver todas as tarefas\n" +
                            "6 - Buscar tarefa por Id\n" +
                            "7 - Sair");

        Console.WriteLine(new string('=', 30));
    }

    internal static void ProcessarEscolha(OpcaoMenuEnum opcao, TodoListContext context)
    {
        switch (opcao)
        {
            case OpcaoMenuEnum.Add:
                AdicionarTarefa(context);
                break;
        }
    }

    internal static void AdicionarTarefa(TodoListContext context)
    {
        Console.WriteLine("Descrição: ");
        string descricao = Console.ReadLine();

        context.TodoItems.Add(new TodoItem(descricao));
        context.SaveChanges();
    }

}