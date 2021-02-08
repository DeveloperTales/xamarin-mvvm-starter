using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVVMStarter.Core.Models;

namespace MVVMStarter.Core.Services
{
    public class ApiService : IApiService
    {
        private static List<TodoItem> _todoItems;

        public ApiService()
        {
            _todoItems = new List<TodoItem>()
            {
                new TodoItem
                {
                    Id= Guid.NewGuid().ToString(),
                    Title = "First",
                    Notes = "First Todo Item"
                },
                new TodoItem
                {
                    Id= Guid.NewGuid().ToString(),
                    Title = "Second",
                    Notes = "Second Todo Item"
                }
            };
        }        

        public async Task<ICollection<TodoItem>> GetTodoItemsAsync()
        {
            return await Task.FromResult(_todoItems);
        }

        public async Task<bool> SaveItemAsync(TodoItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
                _todoItems.Add(item);
            }
            else
            {
                var index = _todoItems.FindIndex(todoItem => todoItem.Id == item.Id);
                _todoItems[index].Title = item.Title;
                _todoItems[index].Notes = item.Notes;
                _todoItems[index].Done = item.Done;
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(TodoItem item)
        {
            return await Task.FromResult(true);
        }
    }
}
