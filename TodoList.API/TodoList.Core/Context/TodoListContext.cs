using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Core.Entities;

namespace TodoList.Core.Context
{
	internal class TodoListContext : DbContext
	{
		public TodoListContext(DbContextOptions<TodoListContext> options) : base(options) { }

		public DbSet<TodoItem> Items { get; set; }
	}
}
