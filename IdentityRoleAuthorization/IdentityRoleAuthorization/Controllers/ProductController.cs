using IdentityRoleAuthorization.Models.Dtos;
using IdentityRoleAuthorization.Service.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityRoleAuthorization.Controllers
{
	public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequestDto productRequestDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProductAsync(productRequestDto);
                return RedirectToAction(nameof(GetAllProduct));
            }

            return View(productRequestDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductRequestDto productRequestDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateProductAsync(id, productRequestDto);
                return RedirectToAction(nameof(GetAllProduct));
            }

            return View(productRequestDto);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(GetAllProduct));
        }

        //[HttpPost]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteAll()
        {
            var allProducts = await _productService.GetProductsAsync();
            return View("DeleteAll", allProducts);
        }

        //[HttpPost]
        [Authorize("Admin")]
        public async Task<IActionResult> ConfirmDeleteAll()
        {
            await _productService.DeleteAllProductAsync();
            return RedirectToAction(nameof(GetAllProduct));
        }
    }
}
