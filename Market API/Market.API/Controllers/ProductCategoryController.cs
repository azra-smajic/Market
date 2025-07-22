using AutoMapper;
using Market.Core.Dtos;
using Market.Core.SearchObjects;
using Market.Services.MarketService;

namespace Market.API.Controllers
{
    public class MarketController : BaseController<MarketDto, MarketDto, MarketDto, MarketIndexDto, MarketSearchObject>
    {
        public MarketController(IMarketService marketService, IMapper mapper) : base(marketService, mapper)
        {
        }
    }
}