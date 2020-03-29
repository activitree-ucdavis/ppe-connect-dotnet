using System.Collections.Generic;
using HackCOVID19.Models;
using MongoDB.Driver;

namespace HackCOVID19.Services
{
    public class SupplierService
    {
        private readonly IMongoCollection<Supplier> _suppliers;

        public SupplierService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _suppliers = database.GetCollection<Supplier>(settings.SuppliersCollectionName);
        }

        public List<Supplier> Get() =>
            _suppliers.Find(supplier => true).ToList();

        public Supplier Get(string id) =>
            _suppliers.Find<Supplier>(supplier => supplier.Id == id).FirstOrDefault();

        public Supplier Create(Supplier supplier)
        {
            _suppliers.InsertOne(supplier);
            return supplier;
        }

        public void Update(string id, Supplier supplierIn) =>
            _suppliers.ReplaceOne(supplier => supplier.Id == id, supplierIn);

        public void Remove(Supplier supplierIn) =>
            _suppliers.DeleteOne(supplier => supplier.Id == supplierIn.Id);

        public void Remove(string id) => 
            _suppliers.DeleteOne(supplier => supplier.Id == id);
    }
}