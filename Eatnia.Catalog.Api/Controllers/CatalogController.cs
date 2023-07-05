using Eatnia.Catalog.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Eatnia.Catalog.Api.Controllers
{
    [ApiController]
    [Route("catalog")]
    public class CatalogController : ControllerBase
    {
        private static readonly List<CatalogItemDto> items = new()
        {
            new CatalogItemDto(Guid.NewGuid(), "Potion", "Restores a small amount of HP", 5, DateTimeOffset.UtcNow),
            new CatalogItemDto(Guid.NewGuid(), "Antidote", "Cures poison", 7, DateTimeOffset.UtcNow),
            new CatalogItemDto(Guid.NewGuid(), "Bronze sword", "Deals a small amount of damage", 20, DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public IEnumerable<CatalogItemDto> Get()
        {
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<CatalogItemDto> GetById(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<CatalogItemDto> Post(CreateCatalogItemDto createCatalogItemDto)
        {
            var item = new CatalogItemDto(Guid.NewGuid(), 
                createCatalogItemDto.Name, 
                createCatalogItemDto.Description, 
                createCatalogItemDto.PricePerDay, 
                DateTimeOffset.UtcNow);

            items.Add(item);

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UpdateCatalogItemDto updateCatalogItemDto)
        {
            var existingItem = items.Where(item => item.Id == id).SingleOrDefault();

            if (existingItem == null)
            {
                return NotFound();
            }

            var updatedItem = existingItem with
            {
                Name = updateCatalogItemDto.Name,
                Description = updateCatalogItemDto.Description,
                PricePerDay = updateCatalogItemDto.PricePerDay
            };

            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items[index] = updatedItem;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);

            if (index < 0)
            {
                return NotFound();
            }

            items.RemoveAt(index);

            return NoContent();
        }
    }
}