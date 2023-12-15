using DotNetServer.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace DotNetServer.Services
{
    public class UserService
    {
        // MongoDB context or similar injected here
        private readonly IMongoCollection<User> _userCollection;
        

        public UserService(
            IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>("User");
        }

        public async Task<List<User>> GetAllUsersAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();


        public async Task<User?> GetUserByIdAsync(string id) =>
            await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User newUser) =>
            await _userCollection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, User updatedUser) =>
            await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        public async Task RemoveAsync(string id) => await _userCollection.DeleteOneAsync(x => x.Id == id);

    }
}
