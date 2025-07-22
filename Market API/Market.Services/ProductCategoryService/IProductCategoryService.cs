using Market.Core.Dtos;
using Market.Services.BaseService;

namespace Market.Services.ProductCategoryService
{
    public interface IProductCategoryService : IBaseService<ProductCategoryDto>, IPaginationBaseService<ProductCategoryIndexDto>
    {
    }
}