using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore2.Mvc.DependencyInjections.Models
{
    public class TodoItem
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public bool IsDone { get; set; }
    }
}
