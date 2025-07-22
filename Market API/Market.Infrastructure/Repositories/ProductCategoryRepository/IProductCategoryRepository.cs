using Market.Core.Dtos;
using Market.Core.SearchObjects;
using Market.Infrastructure.Repositories.BaseRepository;
using Market.Core.Entities;

namespace Market.Infrastructure.Repositories.ProdutCategoryRepository
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory, Guid>
    {
        Task<ProductCategoryDto> GetByIdAsync(int id);

        Task<List<ProductCategoryIndexDto>> GetForPaginationAsync(BaseSearchObject searchObject, int pageSize, int offeset)
           => throw new NotImplementedException();
    }
}