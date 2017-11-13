using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Pages.Data;
using Razor.Pages.Models;

namespace Razor.Pages.Customers
{
    public class CreatePageModel : PageModel // Por convensao as classes derivadas sao declaradas como <PageName>Model
    {
        [TempData] // expoe TempData de um Controller
        public string Message { get; set; }
        
        [BindProperty] // funciona somente quando o verbo HTTP for um não GET, ou seja, POST,PUT,PATCH etc.. similar ao modelbinding
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync([FromServices] AppDbContext db)
        {
            if (!ModelState.IsValid)
                return Page(); // Similar como as actions retornam suas views
            
            db.Customers.Add(Customer);

            await db.SaveChangesAsync();

            this.Message = $"Customer {Customer.Name} added with successfully.";
            
            return RedirectToPage("./index"); // RedirectToPage similar ao RedirectToAction
        }
    }
}