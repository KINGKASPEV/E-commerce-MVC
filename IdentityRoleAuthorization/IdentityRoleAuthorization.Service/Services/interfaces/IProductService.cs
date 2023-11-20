using IdentityRoleAuthorization.Models.Dtos;

namespace IdentityRoleAuthorization.Service.Services.interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(ProductRequestDto productRequestDto);
        Task<IEnumerable<ProductResponseDto>> GetProductsAsync();
        Task<ProductResponseDto> GetByIdAsync(int productId);
        Task UpdateProductAsync(int productId, ProductRequestDto productRequestDto);
        Task DeleteProductAsync(int productId);
        Task<IEnumerable<ProductResponseDto>> DeleteAllProductAsync();
    }
}
