using Eatnia.Catalog.Api.Dtos;
using Eatnia.Catalog.Api.Entities;

namespace Eatnia.Catalog.Api
{
    public static class Extensions
    {
        public static CatalogItemDto AsDto(this CatalogItem item)
        {
            return new CatalogItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
    }
}
