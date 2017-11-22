// HomeController ~ Main controller
//
// Authors:
//      Adorno <adorno@protonmail.com>
//

using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using AspnetCore2.Mvc.Localization.Models;

namespace AspnetCore2.Mvc.Localization.Controllers
{
    public class HomeController : Controller
    {
        private IStringLocalizer<HomeController> _localizer;
        
        /// <summary>
        /// Constructor with dependency injection required to localization
        /// </summary>
        /// <param name="localizer"></param>
        public HomeController(IStringLocalizer<HomeController> localizer)
        => _localizer = localizer;

        /// <summary>
        /// Loads main page with localization (en-US as default)
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(Todo todo = null)
        {
            ViewData["Welcome"] = _localizer["Welcome"].Value;

            return View(todo ?? new Todo());
        }
        
        /// <summary>
        /// Posting and validating the model (modelbinder)
        /// </summary>
        /// <param name="todo">Todo entity</param>
        /// <returns>Simple response</returns>
        [HttpPost]
        public IActionResult Post(Todo todo)
        {
            if (!ModelState.IsValid)
                return View("Index", model: todo);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Save culture preferences to cookie
        /// </summary>
        private void SetLanguageToCookie()
        {
            if (Request.QueryString.HasValue && Request.QueryString.Value.ToLower().Contains("?culture"))
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(Request.QueryString.Value.Split('=')[1])));
        }
    }
}