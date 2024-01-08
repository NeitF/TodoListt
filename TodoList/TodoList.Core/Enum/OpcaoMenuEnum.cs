using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Core.Enum
{
    public enum OpcaoMenuEnum : byte
    {
        Add = 1,
        Remover,
        Alterar,
        MarcarComoCompletado,
        VerTodos,
        Sair
    }
}
