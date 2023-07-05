using System;
using System.ComponentModel.DataAnnotations;

namespace Eatnia.Catalog.Api.Dtos
{
    public record CatalogItemDto(Guid Id, string Name, string Description, decimal PricePerDay, DateTimeOffset CreatedDate);

    public record CreateCatalogItemDto([Required] string Name, string Description, [Range(0, 1000)] decimal PricePerDay);

    public record UpdateCatalogItemDto([Required] string Name, string Description, [Range(0, 1000)] decimal PricePerDay);
}