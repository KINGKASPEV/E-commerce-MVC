using IdentityRoleAuthorization.Models;
using IdentityRoleAuthorization.Service.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityRoleAuthorization.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IProductService _productService;

		public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
			_productService = productService;
		}

		public async Task<IActionResult> Index()
		{
			// Fetch products for the homepage
			var products = await _productService.GetProductsAsync();

			// Pass the product data to the view
			return View(products);
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}