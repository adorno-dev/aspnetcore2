using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCore2.Jwt.Api.Controllers
{
    public class ApiController : Controller
    {
        public async Task<IActionResult> Index()
            => await Task.FromResult(Json("OK"));
    }
}