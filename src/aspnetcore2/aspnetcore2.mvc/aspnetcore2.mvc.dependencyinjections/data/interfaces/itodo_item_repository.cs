using AspnetCore2.Mvc.DependencyInjections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore2.Mvc.DependencyInjections.Data.Interfaces
{
    public interface ITodoItemRepository
    {
        IEnumerable<TodoItem> List();
    }
}
