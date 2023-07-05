using Microsoft.AspNetCore.Mvc;
using Eatnia.Catalog.Api.Dtos;
using Eatnia.Catalog.Api.Entities;
using Eatnia.Common;

namespace Eatnia.Catalog.Api.Controllers
{
    [ApiController]
    [Route("catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly IRepository<CatalogItem> repository;

        public CatalogController(IRepository<CatalogItem> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<CatalogItemDto>> GetAsync()
        {
            var items = (await repository.GetAllAsync())
                        .Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogItemDto>> GetByIdAsync(Guid id)
        {
            var item = await repository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<CatalogItemDto>> PostAsync(CreateCatalogItemDto catalogItemDto)
        {
            var item = new CatalogItem
            {
                Name = catalogItemDto.Name,
                Description = catalogItemDto.Description,
                Price = catalogItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateCatalogItemDto catalogItemDto)
        {
            var existingItem = await repository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = catalogItemDto.Name;
            existingItem.Description = catalogItemDto.Description;
            existingItem.Price = catalogItemDto.Price;

            await repository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var item = await repository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await repository.RemoveAsync(item.Id);

            return NoContent();
        }
    }
}