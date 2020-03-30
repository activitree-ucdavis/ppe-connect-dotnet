using System.Collections.Generic;
using HackCOVID19.Models;
using MongoDB.Driver;

namespace HackCOVID19.Services
{
    public class HealthCareProviderService
    {
        private readonly IMongoCollection<HealthCareProvider> _healthCareProviders;

        public HealthCareProviderService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _healthCareProviders = database.GetCollection<HealthCareProvider>(settings.HealthCareProvidersCollectionName);
        }

        public List<HealthCareProvider> Get() =>
            _healthCareProviders.Find(healthCareProvider => true).ToList();

        public HealthCareProvider Get(string id) =>
            _healthCareProviders.Find<HealthCareProvider>(healthCareProvider => healthCareProvider.Id == id).FirstOrDefault();

        public HealthCareProvider Create(HealthCareProvider healthCareProvider)
        {
            _healthCareProviders.InsertOne(healthCareProvider);
            return healthCareProvider;
        }

        public void Update(string id, HealthCareProvider healthCareProviderIn) =>
            _healthCareProviders.ReplaceOne(healthCareProvider => healthCareProvider.Id == id, healthCareProviderIn);

        public void Remove(HealthCareProvider healthCareProviderIn) =>
            _healthCareProviders.DeleteOne(healthCareProvider => healthCareProvider.Id == healthCareProviderIn.Id);

        public void Remove(string id) => 
            _healthCareProviders.DeleteOne(healthCareProvider => healthCareProvider.Id == id);
    }
}