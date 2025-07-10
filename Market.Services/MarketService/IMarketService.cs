using Market.Core.Dtos;
using Market.Services.BaseService;

namespace Market.Services.MarketService
{
    public interface IMarketService : IBaseService<MarketDto>, IPaginationBaseService<MarketIndexDto>
    {
    }
}