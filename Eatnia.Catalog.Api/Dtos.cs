using System;
using System.ComponentModel.DataAnnotations;

namespace Eatnia.Catalog.Api.Dtos
{
    public record CatalogItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);

    public record CreateCatalogItemDto([Required] string Name, string Description, [Range(0, 1000)] decimal Price);

    public record UpdateCatalogItemDto([Required] string Name, string Description, [Range(0, 1000)] decimal Price);
}