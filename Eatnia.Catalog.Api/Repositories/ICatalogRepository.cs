using Eatnia.Catalog.Api.Entities;

namespace Eatnia.Catalog.Api.Repositories
{
    public interface ICatalogRepository
    {
        Task CreateAsync(CatalogItem entity);
        Task<IReadOnlyCollection<CatalogItem>> GetAllAsync();
        Task<CatalogItem> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(CatalogItem entity);
    }
}