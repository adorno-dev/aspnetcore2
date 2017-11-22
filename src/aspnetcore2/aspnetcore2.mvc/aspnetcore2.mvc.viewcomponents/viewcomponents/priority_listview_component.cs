using AspnetCore2.Mvc.ViewComponents.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspnetCore2.Mvc.ViewComponents.ViewComponents
{
    //[ViewComponent(Name = "PriorityList")]
    //public class XYZ : ViewComponent { }

    public class PriorityListViewComponent : ViewComponent
    {
        private readonly TodoContext _context;

        public PriorityListViewComponent(TodoContext context) =>
            _context = context;

        public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone) =>
            // View(await this.GetItemsAsync(maxPriority, isDone));
            View(maxPriority > 3 && isDone ? "PVC" : "Default", await this.GetItemsAsync(maxPriority, isDone)); // <-- If asking for all completed tasks, render with "PVC" view.
            

        private Task<List<TodoItem>> GetItemsAsync(int maxPriority, bool isDone) =>
            _context.Todo.Where(w => w.IsDone && w.Priority <= maxPriority)
                         .ToListAsync();
    }
}
