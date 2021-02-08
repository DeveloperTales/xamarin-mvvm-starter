using System.Collections.Generic;
using System.Threading.Tasks;
using MVVMStarter.Core.Models;

namespace MVVMStarter.Core.Services
{
    public interface IApiService
    {
        Task<ICollection<TodoItem>> GetTodoItemsAsync();

        Task<bool> SaveItemAsync(TodoItem item);

        Task<bool> DeleteItemAsync(TodoItem item);
    }
}
