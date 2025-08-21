using Market.Core.Dtos;
using Market.Core.SearchObjects;
using Market.Infrastructure.Repositories.BaseRepository;
using Market.Entities;

namespace Market.Infrastructure.Repositories.MarketRepository
{
    public interface IMarketRepository : IBaseRepository<MarketEntity, Guid>
    {
        Task<MarketDto> GetByIdAsync(Guid id);

        Task<List<MarketIndexDto>> GetForPaginationAsync(BaseSearchObject searchObject, int pageSize, int offeset)
           => throw new NotImplementedException();
    }
}