using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Pages.Data;
using Razor.Pages.Models;

namespace Razor.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db = null;

        public EditModel(AppDbContext db) => _db = db;

        [BindProperty]
        public Customer Customer { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            this.Customer = await _db.Customers.FindAsync(id);

            if (this.Customer == null)
                return RedirectToPage("./index");
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
                return Page();
            
            this._db.Attach(Customer).State = EntityState.Modified;

            try
            {
                await this._db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Customer {Customer.Id} not found!");
            }

            return RedirectToPage("./index");
        }
    }
}