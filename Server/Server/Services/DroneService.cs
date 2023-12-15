using DotNetServer.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;


namespace DotNetServer.Services
{
    public class DroneService
    {
        // MongoDB context or similar injected here
        private readonly IMongoCollection<Drone> _droneCollection;

        public DroneService(
            IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _droneCollection = mongoDatabase.GetCollection<Drone>("Drone");
        }

        public async Task<List<Drone>> GetAllDronesAsync() =>
            await _droneCollection.Find(_ => true).ToListAsync();


        public async Task<Drone?> GetDroneByIdAsync(string id) =>
            await _droneCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Drone newdrone) =>
            await _droneCollection.InsertOneAsync(newdrone);

        public async Task UpdateAsync(string id, Drone updatedDrone) =>
            await _droneCollection.ReplaceOneAsync(x => x.Id == id, updatedDrone);

        public async Task RemoveAsync(string id) => await _droneCollection.DeleteOneAsync(x => x.Id == id);

    }
}
