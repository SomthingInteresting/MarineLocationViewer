using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarineLocationViewer.Repositories
{
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

      public async Task<UpdateResult> Update(string id, MarineData marineData)
      {
          var updateDefinition = Builders<MarineData>.Update
              .Set(md => md.Latitude, marineData.Latitude)
              .Set(md => md.Longitude, marineData.Longitude)
              .Set(md => md.DateLogged, marineData.DateLogged);

          return await _marineDatas.UpdateOneAsync(data => data.Id == id, updateDefinition);
      }

      public async Task Delete(string id)
      {
          await _marineDatas.DeleteOneAsync(data => data.Id == id);
      }
  }
}