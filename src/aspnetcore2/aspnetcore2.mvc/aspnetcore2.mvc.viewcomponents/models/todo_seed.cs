using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspnetCore2.Mvc.ViewComponents.Models
{
    public class TodoSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {            
            var context = serviceProvider.CreateScope().ServiceProvider.GetService<TodoContext>();
            var index = 0;

            if (context.Database == null)
                throw new Exception("Database is null");

            while (index++ < 9)
                context.Add(new TodoItem
                {
                    IsDone = index % 3 == 0,
                    Priority = index % 5 + 1,
                    Name = $"Task #{index + 1}"
                });

            context.SaveChanges();
        }
    }
}
