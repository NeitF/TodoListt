using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Core.Context;
using TodoList.Core.Enum;
using TodoList.Core.Entities;
using System.Runtime.InteropServices;

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
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Sistema Operacional: {RuntimeInformation.OSDescription}");
            Console.WriteLine("Lista de tarefas a fazer\n");

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
                          "6 - Sair");

        Console.WriteLine(new string('=', 30));
    }

    internal static void ProcessarEscolha(OpcaoMenuEnum opcao, TodoListContext context)
    {
        switch (opcao)
        {
            case OpcaoMenuEnum.Add:
                AdicionarTarefa(context);
                break;
            case OpcaoMenuEnum.Remover:
                RemoverTarefa(context);
                break;
            case OpcaoMenuEnum.Alterar:
                EditarTarefa(context);
                break;
            case OpcaoMenuEnum.MarcarComoCompletado:
                MarcarComoCompletado(context);
                break;
            case OpcaoMenuEnum.VerTodos:
                VerTodasAsTarefas(context);
                break;
            case OpcaoMenuEnum.Sair:
                Environment.Exit(0);
                break;
        }

        Console.WriteLine("Precisone ENTER para continuar");
        Console.ReadLine();
    }

    internal static void AdicionarTarefa(TodoListContext context)
    {
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();

        context.TodoItems.Add(new TodoItem(descricao));
        context.SaveChanges();
    }

    internal static void RemoverTarefa(TodoListContext context)
    {
        Console.Write("Id: ");
        int.TryParse(Console.ReadLine(), out int id);

        var itemEncontrado = context.TodoItems.Find(id);
        if (itemEncontrado == null)
        {
            Console.WriteLine("Não foi encontrado nenhum item com o ID informado");
            return;
        }

        context.TodoItems.Remove(itemEncontrado);
        context.SaveChanges();
    }

    internal static void EditarTarefa(TodoListContext context)
    {
        Console.Write("Id: ");
        int.TryParse(Console.ReadLine(), out int id);

        var itemEncontrado = context.TodoItems.Find(id);
        if (itemEncontrado == null)
        {
            Console.WriteLine("Não foi encontrado nenhum item com o ID informado");
            return;
        }

        Console.Write("Descrição: ");
        itemEncontrado.Descricao = Console.ReadLine();
        Console.Write("Completo [s/n]?");
        char.TryParse(Console.ReadLine(), out char completo);

        if (completo == 's')
            itemEncontrado.IsCompleto = true;
        else
            itemEncontrado.IsCompleto = false;

        context.TodoItems.Update(itemEncontrado);
        context.SaveChanges();
    }

    internal static void MarcarComoCompletado(TodoListContext context)
    {
        Console.Write("Id: ");
        int.TryParse(Console.ReadLine(), out int id);

        var itemEncontrado = context.TodoItems.Find(id);
        if (itemEncontrado == null)
        {
            Console.WriteLine("Não foi encontrado nenhum item com o ID informado");
            return;
        }

        itemEncontrado.IsCompleto = true;
        context.TodoItems.Update(itemEncontrado);
        context.SaveChanges();
    }

    internal static void VerTodasAsTarefas(TodoListContext context)
    {
        var todosOsItens = context.TodoItems.ToList();

        foreach (var item in todosOsItens)
            Console.WriteLine($"========\nID: {item.Id}\nDESCRICAO: {item.Descricao}\nCOMPLETA: {item.IsCompleto}\n========");
    }
}