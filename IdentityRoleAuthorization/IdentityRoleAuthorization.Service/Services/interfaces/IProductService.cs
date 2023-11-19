using IdentityRoleAuthorization.Models.Dtos;

namespace IdentityRoleAuthorization.Service.Services.interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(ProductRequestDto productRequestDto);
        Task<IEnumerable<ProductResponseDto>> GetProductsAsync();
        Task<ProductResponseDto> GetByIdAsync(string productId);
        Task UpdateProductAsync(string productId, ProductRequestDto productRequestDto);
        Task DeleteProductAsync(string productId);
        Task<IEnumerable<ProductResponseDto>> DeleteAllProductAsync();
    }
}
