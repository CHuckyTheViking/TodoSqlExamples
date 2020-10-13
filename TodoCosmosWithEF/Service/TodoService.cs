using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoCosmosWithEF.Models;

namespace TodoCosmosWithEF.Service
{
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

        public static async Task<Todo> GetTodoAsync(string id)
        {
            using TodoContext context = new TodoContext();

            return await context.Todos.Where(todo => todo.Id == id).FirstOrDefaultAsync();
        }

        public static async Task<IEnumerable<Todo>> GetTodosByCompletedAsync(bool completed)
        {
            using TodoContext context = new TodoContext();

            return await context.Todos.Where(todo => todo.Completed == completed).ToListAsync();
        }

        public static async Task UpdateTodoAsync(string id)
        {
            using TodoContext context = new TodoContext();

            var todo = await context.Todos.Where(todo => todo.Id == id).FirstOrDefaultAsync();

            if (todo != null)
            {
                todo.Completed = true;
                context.Entry(todo).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public static async Task RemoveTodoAsync(string id)
        {
            using TodoContext context = new TodoContext();

            var todo = await context.Todos.Where(todo => todo.Id == id).FirstOrDefaultAsync();

            if (todo != null)
            {
                context.Todos.Remove(todo);
                await context.SaveChangesAsync();
            }
        }
    }
}
