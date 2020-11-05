using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Common
{
    public class MemoryRepository : IRepository
    {
        private readonly Dictionary<long, ToDoItem> _dic = new Dictionary<long, ToDoItem>();
        public MemoryRepository()
        {
            Init();
        }
        public async Task<ToDoItem> GetAsync(long id)
        {
            _dic.TryGetValue(id, out var item);
            return item;
        }
        public async Task UpsertAsync(ToDoItem model)
        {
            _dic[model.Id] = model;
        }

        public async Task<List<ToDoItem>> QueryAsync()
        {
            IEnumerable<ToDoItem> models = _dic.Values.ToList();
            return models.ToList();
        }

        private void Init()
        {
            string[] nameList = { "Jason", "Bill", "Micheal" };
            for (var i = 0; i < 3; i++)
            {
                var item = new ToDoItem()
                {
                    Id = i,
                    Name = nameList[i],
                    IsComplete = false
                };
                _dic[item.Id] = item;
            }
        }
    }
}
