using ATSApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ATSApi.Services;

public class PositionsService
{
    private readonly IMongoCollection<Position> _positionsCollection;

    public PositionsService(
        IOptions<PositionDatabaseSettings> PositionDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            PositionDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            PositionDatabaseSettings.Value.DatabaseName);

        _positionsCollection = mongoDatabase.GetCollection<Position>(
            PositionDatabaseSettings.Value.PositionsCollectionName);
    }

    public async Task<List<Position>> GetAsync() =>
        await _positionsCollection.Find(_ => true).ToListAsync();

    public async Task<Position?> GetAsync(string id) =>
        await _positionsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Position newPosition) =>
        await _positionsCollection.InsertOneAsync(newPosition);

    public async Task UpdateAsync(string id, Position updatedPosition) =>
        await _positionsCollection.ReplaceOneAsync(x => x.Id == id, updatedPosition);

    public async Task RemoveAsync(string id) =>
        await _positionsCollection.DeleteOneAsync(x => x.Id == id);
}
