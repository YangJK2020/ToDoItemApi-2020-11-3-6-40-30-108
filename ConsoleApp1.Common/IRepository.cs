using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1.Common
{
    public interface IRepository
    {
        Task<ToDoItem> GetAsync(long id);
        Task<List<ToDoItem>> QueryAsync();
        Task UpsertAsync(ToDoItem model);
    }
}