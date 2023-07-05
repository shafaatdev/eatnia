using Eatnia.Catalog.Api.Entities;
using MongoDB.Driver;

namespace Eatnia.Catalog.Api.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private const string collectionName = "items";
        private readonly IMongoCollection<CatalogItem> dbCollection;
        private readonly FilterDefinitionBuilder<CatalogItem> filterBuilder = Builders<CatalogItem>.Filter;

        public CatalogRepository(IMongoDatabase database)
        {
            dbCollection = database.GetCollection<CatalogItem>(collectionName);
        }

        public async Task<IReadOnlyCollection<CatalogItem>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<CatalogItem> GetAsync(Guid id)
        {
            FilterDefinition<CatalogItem> filter = filterBuilder.Eq(entity => entity.Id, id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(CatalogItem entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await dbCollection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(CatalogItem entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<CatalogItem> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await dbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<CatalogItem> filter = filterBuilder.Eq(entity => entity.Id, id);
            await dbCollection.DeleteOneAsync(filter);
        }
    }
}