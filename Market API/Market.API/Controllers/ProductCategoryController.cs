using AutoMapper;
using Market.Core.Dtos;
using Market.Core.SearchObjects;
using Market.Services.ProductCategoryService;

namespace Market.API.Controllers
{
    public class ProductCategoryController : BaseController<ProductCategoryDto, ProductCategoryUpsertDto, ProductCategoryUpsertDto, ProductCategoryIndexDto, ProductCategorySearchObject>
    {
        public ProductCategoryController(IProductCategoryService productCategoryService, IMapper mapper) : base(productCategoryService, mapper)
        {
        }
    }
}