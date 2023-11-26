using IdentityRoleAuthorization.Models;

namespace IdentityRoleAuthorization.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetByIdAsync(int Id);
        Task UpdateProductAsync(int Id, Product product);
        Task<IEnumerable<Product>> DeleteAllProductAsync();
		Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
	}
}
