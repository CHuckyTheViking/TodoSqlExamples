using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoSqlCodeFirst.Models;

namespace TodoSqlCodeFirst.Services
{
    /// <summary>
    /// Performs CRUD operations for a Sql Server
    /// CRUD = Create Read Update Delete = Add, Get, Update, Remove
    /// </summary>

    public static class TodoService
    {
        public static async Task AddTodoAsync(string activity)
        {
            using TodoContext context = new TodoContext();

            context.Todos.Add(new Todo(activity));
            await context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            using TodoContext context = new TodoContext();

            return await context.Todos.ToListAsync();
        }

        public static async Task<Todo> GetTodoAsync(int id)
        {
            using TodoContext context = new TodoContext();

            return await context.Todos.FindAsync(id);
        }

        public static async Task<IEnumerable<Todo>> GetTodosByCompletedAsync(bool completed)
        {
            using TodoContext context = new TodoContext();

            return await context.Todos.Where(todo => todo.Completed == completed).ToListAsync();
        }

        public static async Task UpdateTodoAsync(int id)
        {
            using TodoContext context = new TodoContext();

            var todo = await context.Todos.FindAsync(id);
            //if (todo != null)
            if (todo is Todo)
            {
                todo.Completed = true;
                context.Entry(todo).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }

        }

        public static async Task RemoveTodoAsync(int id)
        {
            using TodoContext context = new TodoContext();

            var todo = await context.Todos.FindAsync(id);
            //if (todo != null)
            if (todo is Todo)
            {
                context.Todos.Remove(todo);
                await context.SaveChangesAsync();
            }
        }
    }
}
