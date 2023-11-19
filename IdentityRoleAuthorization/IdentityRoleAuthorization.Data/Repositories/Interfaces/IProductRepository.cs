using IdentityRoleAuthorization.Models;

namespace IdentityRoleAuthorization.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetByIdAsync(string Id);
        Task UpdateProductAsync(string Id, Product product);
        Task<IEnumerable<Product>> DeleteAllProductAsync();
    }
}
