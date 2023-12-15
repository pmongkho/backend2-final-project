using DotNetServer.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;


namespace DotNetServer.Services
{
    public class DroneActionService
    {
        // MongoDB context or similar injected here
        private readonly IMongoCollection<DroneAction> _droneActionCollection;

        public DroneActionService(
            IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _droneActionCollection = mongoDatabase.GetCollection<DroneAction>("DroneAction");
        }

        public async Task<List<DroneAction>> GetAllDroneActionsAsync() =>
            await _droneActionCollection.Find(_ => true).ToListAsync();


        public async Task<DroneAction?> GetDroneActionByIdAsync(string id) =>
            await _droneActionCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(DroneAction newDroneAction) =>
            await _droneActionCollection.InsertOneAsync(newDroneAction);

        public async Task UpdateAsync(string id, DroneAction updatedDroneAction) =>
            await _droneActionCollection.ReplaceOneAsync(x => x.Id == id, updatedDroneAction);

        public async Task RemoveAsync(string id) => await _droneActionCollection.DeleteOneAsync(x => x.Id == id);

    }
}
