using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityRoleAuthorization.Controllers
{
    public class ProductController : Controller
    {
        [Authorize]
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
