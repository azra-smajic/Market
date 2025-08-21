using AutoMapper;
using Market.Core.Dtos;
using Market.Core.SearchObjects;
using Market.Services.ProductCategoryService;
using Market.Services.ProductService;

namespace Market.API.Controllers
{
    public class ProductController : BaseController<ProductDto, ProductDto, ProductDto, ProductIndexDto, ProductSearchObject>
    {
        public ProductController(IProductService productService, IMapper mapper) : base(productService, mapper)
        {
        }
    }
}