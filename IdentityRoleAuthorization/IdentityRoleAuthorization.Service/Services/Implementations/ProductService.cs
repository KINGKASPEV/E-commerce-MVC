using IdentityRoleAuthorization.Models.Dtos;
using IdentityRoleAuthorization.Models;
using IdentityRoleAuthorization.Data.Repositories.Interfaces;
using IdentityRoleAuthorization.Service.Services.interfaces;

namespace IdentityRoleAuthorization.Service.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;

        public ProductService(IProductRepository productRepository, IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }

        public async Task AddProductAsync(ProductRequestDto productRequestDto)
        {
            var product = MapToProduct(productRequestDto);
            await _productRepository.AddProductAsync(product);
        }

        public async Task<IEnumerable<ProductResponseDto>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            return MapToProductResponseDtos(products);
        }

        public async Task<ProductResponseDto> GetByIdAsync(int productId)
        {
            var product =  await _productRepository.GetByIdAsync(productId);
            return MapToProductResponseDto(product);
        }

        public async Task UpdateProductAsync(int productId, ProductRequestDto productRequestDto)
        {
            var product = MapToProduct(productRequestDto);
            await _productRepository.UpdateProductAsync(productId, product);
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product =await _productRepository.GetByIdAsync(productId);
            if (product != null)
            {
                await _productRepository.DeleteProductAsync(product);
            }
        }

        public async Task<IEnumerable<ProductResponseDto>> DeleteAllProductAsync()
        {
            var allProducts = await _productRepository.DeleteAllProductAsync();
            return MapToProductResponseDtos(allProducts);
        }

        private Product MapToProduct(ProductRequestDto productRequestDto)
        {
            var imageSaveResult = productRequestDto.ImageFile != null ? _fileService.SaveImage(productRequestDto.ImageFile) : null;

            return new Product
            {
                Name = productRequestDto.Name,
                Description = productRequestDto.Description,
                Price = productRequestDto.Price,
                InStock = productRequestDto.InStock,
                DatePosted = productRequestDto.DatePosted,
                ImageFileName = imageSaveResult != null ? imageSaveResult.Item2 : null
            };
        }


        private ProductResponseDto MapToProductResponseDto(Product product)
        {
            if (product == null)
            {
                return null;
            }

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                InStock = product.InStock,
                ManufacturingDate = product.DatePosted,
                ImageFileName = product.ImageFileName,
            };
        }

        private IEnumerable<ProductResponseDto> MapToProductResponseDtos(IEnumerable<Product> products)
        {
            var productResponseDtos = new List<ProductResponseDto>();

            foreach (var product in products)
            {
                productResponseDtos.Add(MapToProductResponseDto(product));
            }

            return productResponseDtos;
        }
    }

}
