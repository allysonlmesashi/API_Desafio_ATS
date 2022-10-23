using ATSApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ATSApi.Services;

public class CandidatesService
{
    private readonly IMongoCollection<Candidate> _candidatesCollection;

    public CandidatesService(
        IOptions<CandidateDatabaseSettings> CandidateDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            CandidateDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            CandidateDatabaseSettings.Value.DatabaseName);

        _candidatesCollection = mongoDatabase.GetCollection<Candidate>(
            CandidateDatabaseSettings.Value.CandidatesCollectionName);
    }

    public async Task<List<Candidate>> GetAsync() =>
        await _candidatesCollection.Find(_ => true).ToListAsync();

    public async Task<Candidate?> GetAsync(string id) =>
        await _candidatesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Candidate newCandidate) =>
        await _candidatesCollection.InsertOneAsync(newCandidate);

    public async Task UpdateAsync(string id, Candidate updatedCandidate) =>
        await _candidatesCollection.ReplaceOneAsync(x => x.Id == id, updatedCandidate);

    public async Task RemoveAsync(string id) =>
        await _candidatesCollection.DeleteOneAsync(x => x.Id == id);
}
