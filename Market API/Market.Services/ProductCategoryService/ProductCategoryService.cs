using Market.Infrastructure.UnitOfWork;
using Market.Core.Dtos;
using Market.Core.SearchObjects;

namespace Market.Services.ProductCategoryService
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<ProductCategoryDto> AddAsync(ProductCategoryDto entityDto)
        {
            entityDto = await _unitOfWork.ProductCategoryRepository.AddAsync<ProductCategoryDto>(entityDto);
            await _unitOfWork.SaveChangesAsync();
            return entityDto;
        }

        public Task<List<ProductCategoryDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategoryDto> GetByIdAsync(Guid id)
        {
            return _unitOfWork.ProductCategoryRepository.GetByIdAsync(id);
        }

        public Task<List<ProductCategoryIndexDto>> GetForPaginationAsync(BaseSearchObject baseSearchObject, int pageSize, int offeset)
        {
            return _unitOfWork.ProductCategoryRepository.GetForPaginationAsync(baseSearchObject, pageSize, offeset);
        }

        public async Task RemoveByIdAsync(Guid id, bool isSoft = true)
        {
            await _unitOfWork.ProductCategoryRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Update(ProductCategoryDto entity)
        {
            _unitOfWork.ProductCategoryRepository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public async Task<ProductCategoryDto> UpdateAsync(ProductCategoryDto entity)
        {
            _unitOfWork.ProductCategoryRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}