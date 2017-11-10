using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Pages.Data;
using Razor.Pages.Models;

namespace Razor.Pages
{
    public class MultipleHandlerModel : PageModel
    {
        private readonly AppDbContext _db = null;

        public MultipleHandlerModel(AppDbContext db)
            => _db = db;

        [BindProperty]
        public Customer Customer { get; set; }
        
        public async Task<IActionResult> OnPostJoinListAsync()
        {
            if (!this.ModelState.IsValid)
                return Page();
            
            _db.Customers.Add(Customer);

            await _db.SaveChangesAsync();

            return Redirect("./index");
        }

        public async Task<IActionResult> OnPostJoinListUCAsync()
        {
            if (!this.ModelState.IsValid)
                return Page();
            
            this.Customer.Name = Customer.Name?.ToUpper();

            return await OnPostJoinListAsync();
        }
    }
}