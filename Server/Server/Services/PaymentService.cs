using DotNetServer.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;


namespace DotNetServer.Services
{
    public class PaymentService
    {
        // MongoDB context or similar injected here
        private readonly IMongoCollection<Payment> _paymentCollection;

        public PaymentService(
            IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _paymentCollection = mongoDatabase.GetCollection<Payment>("Payment");
        }

        public async Task<List<Payment>> GetAllPaymentsAsync() =>
            await _paymentCollection.Find(_ => true).ToListAsync();


        public async Task<Payment?> GetPaymentByIdAsync(string id) =>
            await _paymentCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Payment newPayment) =>
            await _paymentCollection.InsertOneAsync(newPayment);

        public async Task UpdateAsync(string id, Payment updatedPayment) =>
            await _paymentCollection.ReplaceOneAsync(x => x.Id == id, updatedPayment);

        public async Task RemoveAsync(string id) => await _paymentCollection.DeleteOneAsync(x => x.Id == id);

    }
}
