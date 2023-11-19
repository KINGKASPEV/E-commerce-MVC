using IdentityRoleAuthorization.Data.Context;
using IdentityRoleAuthorization.Data.Repositories.Interfaces;
using IdentityRoleAuthorization.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityRoleAuthorization.Data.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
           return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string Id)
        {
            return await _context.Products.FindAsync(Id);
        }


        public async Task UpdateProductAsync(string Id, Product product)
        {
            var productUpdate = await _context.Products.FindAsync(Id);
            if(productUpdate != null)
            {
                productUpdate.Name = product.Name;
                productUpdate.Description = product.Description;
                productUpdate.Price = product.Price;
                productUpdate.InStock= product.InStock;
                _context.Update(productUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> DeleteAllProductAsync()
        {
            var allProducts = await _context.Products.ToListAsync();
            if(allProducts != null && allProducts.Any())
            {
                _context.Products.RemoveRange(allProducts);
                await _context.SaveChangesAsync();
            }
            return allProducts;
        }
    }
}
