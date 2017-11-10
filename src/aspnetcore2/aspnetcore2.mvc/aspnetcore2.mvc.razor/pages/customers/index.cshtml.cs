using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Pages.Data;
using Razor.Pages.Models;

namespace Razor.Pages
{       
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db = null;

        public IndexModel(AppDbContext db) => _db = db;

        [TempData] // Ao fazer a leitura ele é descarregado da memória.. verificar os metodos Peek e Keep para fazer a leitura sem excluir
        public string Message { get; set; }

        public IList<Customer> Customers { get; private set; }

        public async Task OnGetAsync() => Customers = await _db.Customers.AsNoTracking().ToListAsync();

        // Este método é executado quando um form manda um post com o seguinte manipulador: asp-page-handler="delete"
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var contact = await _db.Customers.FirstOrDefaultAsync(w => w.Id.Equals(id));
            
            if (contact != null)
            {
                _db.Customers.Remove(contact);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}