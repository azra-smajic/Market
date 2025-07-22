using AutoMapper;
using Dapper;
using Market.Core.Dtos;
using Market.Core.SearchObjects;
using Market.Infrastructure.Database;
using Market.Infrastructure.Repositories.BaseRepository;
using Market.Core.Entities;

namespace Market.Infrastructure.Repositories.ProdutCategoryRepository
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory, Guid>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<ProductCategoryDto> GetByIdAsync(int pId)
        {
            var query = "SELECT * FROM fn_productcategories_get_by_id(@pId);";

            var result = await DbConnection.QueryFirstAsync(query, new DynamicParameters(new { pId }));

            return Mapper.Map<MarketDto>(result);
        }

        public async Task<List<ProductCategoryIndexDto>> GetForPaginationAsync(BaseSearchObject searchObject, int pageSize, int offeset)
        {
            var search = searchObject as ProductCategorySearchObject;
            var query = "SELECT * FROM fn_productcategories_get_by_parameters(@pName, @pMarketId, @pLimit, @pOffset);";

            var result = await DbConnection.QueryAsync(query,
                         new DynamicParameters(new { pName = search.SearchFilter, pMarketId = search.MarketId, pLimit = pageSize, pOffset = offeset }));

            return Mapper.Map<List<ProductCategoryIndexDto>>(result);
        }
    }
}