using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Market.Core.SearchObjects;
using Market.Services.BaseService;
using Microsoft.AspNetCore.Authorization;

namespace Market.API.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class BaseController<dtoEntity, dtoInsertEntity, dtoUpdateEntity, dtoForPagination, dtoSearchObject> : ControllerBase where dtoEntity : class
    {
        protected readonly IMapper Mapper;
        protected IBaseService<dtoEntity> BaseService { get; }

        public BaseController(IBaseService<dtoEntity> baseService, IMapper mapper)
        {
            BaseService = baseService;
            Mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<List<dtoEntity>> Get()
        {
            return await BaseService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public virtual async Task<dtoEntity> Get(int id)
        {
            return await BaseService.GetByIdAsync(id);
        }

        [HttpGet("{page}/{pageSize}")]
        public virtual async Task<List<dtoForPagination>> Get(int page, int pageSize, [FromQuery] dtoSearchObject search)
        {
            return await ((IPaginationBaseService<dtoForPagination>)BaseService).GetForPaginationAsync(search as BaseSearchObject, pageSize, (page - 1) * pageSize);
        }

        [HttpPost]
        public virtual async Task<dtoEntity> Post(dtoInsertEntity insertEntity)
        {
            return await BaseService.AddAsync(Mapper.Map<dtoEntity>(insertEntity));
        }

        [HttpPut("{id}")]
        public virtual async Task<dtoEntity> Put(int id, dtoUpdateEntity updateEntity)
        {
            return await BaseService.UpdateAsync(Mapper.Map<dtoEntity>(updateEntity));
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await BaseService.RemoveByIdAsync(id);
            return Ok();
        }
    }
}