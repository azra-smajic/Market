using AutoMapper;
using Dapper;
using Market.Core.Dto;
using Market.Core.Dtos;
using Market.Core.Entities;
using Market.Core.SearchObjects;
using Market.Infrastructure.Database;
using Market.Infrastructure.Repositories.BaseRepository;

namespace Market.Infrastructure.Repositories.ProductRepository
{
    public class ProductRepository : BaseRepository<Product, Guid>, IProductRepository
    {
        public ProductRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<ProductDto> GetByIdAsync(Guid pId)
        {
            var query = "SELECT * FROM fn_products_get_by_id(@pId);" +
                              "SELECT * FROM fn_productimages_get_by_productid(@pId);";

            using (var result = await DbConnection.QueryMultipleAsync(query, new DynamicParameters(new { pId })))
            {
                var product = await result.ReadFirstOrDefaultAsync<ProductDto>();
                if (product != null)
                {
                    product.ProductImages = (await result.ReadAsync<ProductImageDto>())?.ToList();
                }
                return product;
            }
        }

        public async Task<List<ProductIndexDto>> GetForPaginationAsync(BaseSearchObject searchObject, int pageSize, int offeset)
        {
            var search = searchObject as ProductSearchObject;
            var query = "SELECT * FROM fn_products_get_by_parameters(@pName, @pSku, @pMarketId, @pProductCategoryId, @pLimit, @pOffset);";

            var result = await DbConnection.QueryAsync(query,
                         new DynamicParameters(new { pName = search.SearchFilter, pSku = search.Sku, pMarketId = search.MarketId, pProductCategoryId = search.ProductCategoryId, pLimit = pageSize, pOffset = offeset }));

            return Mapper.Map<List<ProductIndexDto>>(result);
        }
    }
}