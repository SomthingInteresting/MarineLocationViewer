using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MarineDataRepository
{
    private readonly IMongoCollection<MarineData> _marineDatas;

    public MarineDataRepository(IMongoDatabase database)
    {
        _marineDatas = database.GetCollection<MarineData>("MarineData");
    }

    public async Task<List<MarineData>> GetAll()
    {
        return await _marineDatas.Find(data => true).ToListAsync();
    }

    public async Task<MarineData> Get(string id)
    {
        return await _marineDatas.Find<MarineData>(data => data.Id == id).FirstOrDefaultAsync();
    }

    public async Task Create(MarineData marineData)
    {
        await _marineDatas.InsertOneAsync(marineData);
    }

    public async Task Update(string id, MarineData marineData)
    {
        await _marineDatas.ReplaceOneAsync(data => data.Id == id, marineData);
    }

    public async Task Delete(string id)
    {
        await _marineDatas.DeleteOneAsync(data => data.Id == id);
    }
}
