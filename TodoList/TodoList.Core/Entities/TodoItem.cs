using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Core.Entities;

public class TodoItem
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public bool IsCompleto { get; set; }

    public TodoItem(string descricao, bool isCompleto = false)
    {
        Descricao = descricao;
        IsCompleto = isCompleto;
    }
}
