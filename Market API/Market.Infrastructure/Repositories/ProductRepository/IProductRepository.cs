using Market.Core.Dtos;
using Market.Core.Entities;
using Market.Core.SearchObjects;
using Market.Infrastructure.Repositories.BaseRepository;

namespace Market.Infrastructure.Repositories.ProductRepository
{
    public interface IProductRepository : IBaseRepository<Product, Guid>
    {
        Task<ProductDto> GetByIdAsync(Guid id);

        Task<List<ProductIndexDto>> GetForPaginationAsync(BaseSearchObject searchObject, int pageSize, int offeset)
           => throw new NotImplementedException();
    }
}