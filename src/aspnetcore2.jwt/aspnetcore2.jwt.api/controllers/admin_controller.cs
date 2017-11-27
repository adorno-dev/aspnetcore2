using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCore2.Jwt.Api.Controllers
{
    [Authorize(Policy="Admin")]
    [Route(template: "[controller]")]
    public class AdminController : Controller
    {
        public async Task<IActionResult> Index() =>
            await Task.FromResult(Json(new { message = "You have [Admin Claim]" }));
    }
}