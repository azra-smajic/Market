using Market.Infrastructure.UnitOfWork;
using Market.Core.Dtos;
using Market.Core.SearchObjects;

namespace Market.Services.MarketService
{
    public class MarketService : IMarketService
    {
        private readonly UnitOfWork _unitOfWork;

        public MarketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<MarketDto> AddAsync(MarketDto entityDto)
        {
            entityDto = await _unitOfWork.MarketRepository.AddAsync<MarketDto>(entityDto);
            await _unitOfWork.SaveChangesAsync();
            return entityDto;
        }

        public Task<List<MarketDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MarketDto> GetByIdAsync(int id)
        {
            return _unitOfWork.MarketRepository.GetByIdAsync(id);
        }

        public Task<List<MarketIndexDto>> GetForPaginationAsync(BaseSearchObject baseSearchObject, int pageSize, int offeset)
        {
            return _unitOfWork.MarketRepository.GetForPaginationAsync(baseSearchObject, pageSize, offeset);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await _unitOfWork.MarketRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Update(MarketDto entity)
        {
            _unitOfWork.MarketRepository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public async Task<MarketDto> UpdateAsync(MarketDto entity)
        {
            _unitOfWork.MarketRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}