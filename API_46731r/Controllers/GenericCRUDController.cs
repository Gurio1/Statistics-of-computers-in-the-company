using API_46731r.Domain.Entities;
using API_46731r.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_46731r.Controllers
{
    [Authorize]
    public abstract class GenericCRUDController<TEntity,TService> : ControllerBase where TService :IGenericService<TEntity>
        where TEntity : BaseEntity
    {
        private readonly TService _entityService;
        private readonly ILogger<GenericCRUDController<TEntity, TService>> _logger;

        public GenericCRUDController(TService computerService, ILogger<GenericCRUDController<TEntity, TService>> logger)
        {
            _entityService = computerService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> CreateEntity([FromBody] TEntity computer)
        {
            var result = await _entityService.CreateAsync(computer);

            if (result is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetEntity), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetEntity(int id)
        {
            var result = await _entityService.GetByIdAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEntity([FromBody] TEntity computer)
        {
            var resultOfUpdate = await _entityService.Update(computer);

            if (resultOfUpdate is null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEntity(int id)
        {

            var resultOfDelete = await _entityService.RemoveById(id);

            if (!resultOfDelete)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
