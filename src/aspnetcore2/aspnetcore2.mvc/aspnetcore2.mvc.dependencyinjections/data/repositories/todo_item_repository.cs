using AspnetCore2.Mvc.DependencyInjections.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCore2.Mvc.DependencyInjections.Models;

namespace AspnetCore2.Mvc.DependencyInjections.Data.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        public IEnumerable<TodoItem> List()
        {
            int index = 0;
            while (++index <= 25)
                yield return new TodoItem
                {
                    Name = $"Task #{index}",
                    IsDone = index % 3 == 0,
                    Priority = index % 5 + 1
                };
        }
    }
}
