using AutoMapper;
using Dapper;
using Market.Core.Dtos;
using Market.Core.SearchObjects;
using Market.Infrastructure.Database;
using Market.Infrastructure.Repositories.BaseRepository;
using Market.Entities;

namespace Market.Infrastructure.Repositories.MarketRepository
{
    public class MarketRepository : BaseRepository<MarketEntity, Guid>, IMarketRepository
    {
        public MarketRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<MarketDto> GetByIdAsync(int pId)
        {
            var query = "SELECT * FROM fn_markets_get_by_id(@pId);";

            var result = await DbConnection.QueryFirstAsync(query, new DynamicParameters(new { pId }));

            return Mapper.Map<MarketDto>(result);
        }

        public async Task<List<MarketIndexDto>> GetForPaginationAsync(BaseSearchObject searchObject, int pageSize, int offeset)
        {
            var search = searchObject as MarketSearchObject;
            var query = "SELECT * FROM fn_markets_get_by_parameters(@pName, @pLocation, @pLimit, @pOffset);";

            var result = await DbConnection.QueryAsync(query,
                         new DynamicParameters(new { pName = search.SearchFilter, pLocation = search.Location, pLimit = pageSize, pOffset = offeset }));

            return Mapper.Map<List<MarketIndexDto>>(result);
        }
    }
}