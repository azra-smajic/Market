using Market.Core.Dtos;
using Market.Services.BaseService;

namespace Market.Services.ProductService
{
    public interface IProductService : IBaseService<ProductDto>, IPaginationBaseService<ProductIndexDto>
    {
    }
}