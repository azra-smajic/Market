using Market.Core.Dtos;
using Market.Core.SearchObjects;
using Market.Infrastructure.UnitOfWork;

namespace Market.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<ProductDto> AddAsync(ProductDto entityDto)
        {
            entityDto = await _unitOfWork.ProductRepository.AddAsync<ProductDto>(entityDto);
            await _unitOfWork.SaveChangesAsync();
            return entityDto;
        }

        public Task<List<ProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetByIdAsync(Guid id)
        {
            return _unitOfWork.ProductRepository.GetByIdAsync(id);
        }

        public Task<List<ProductIndexDto>> GetForPaginationAsync(BaseSearchObject baseSearchObject, int pageSize, int offeset)
        {
            return _unitOfWork.ProductRepository.GetForPaginationAsync(baseSearchObject, pageSize, offeset);
        }

        public async Task RemoveByIdAsync(Guid id, bool isSoft = true)
        {
            await _unitOfWork.ProductRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Update(ProductDto entity)
        {
            _unitOfWork.ProductRepository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public async Task<ProductDto> UpdateAsync(ProductDto entity)
        {
            _unitOfWork.ProductRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}