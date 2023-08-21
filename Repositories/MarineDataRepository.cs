using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

public class MarineDataRepository
{
    private readonly IMongoCollection<MarineData> _marineDatas;

    public MarineDataRepository(IMongoDatabase database)
    {
        _marineDatas = database.GetCollection<MarineData>("MarineData");
    }

    public List<MarineData> GetAll() => _marineDatas.Find(data => true).ToList();

    // Add methods to insert, update, delete as needed...
}
