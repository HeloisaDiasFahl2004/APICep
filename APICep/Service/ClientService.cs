using APICep.Models;
using APICep.Utils;
using MongoDB.Driver;
using System.Collections.Generic;

namespace APICep.Service
{
    public class ClientService
    {
        private readonly IMongoCollection<Client> _clients;

        public ClientService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clients = database.GetCollection<Client>(settings.ClientCollectionName);
        }
        public Client Create(Client client)
        {
            _clients.InsertOne(client);
            return client;
        }
        public List<Client> GetAll() => _clients.Find<Client>(client => true).ToList();
        public Client GetById(string id) => _clients.Find<Client>(client => client.Id == id).FirstOrDefault();
        //public Client GetName(string name) => _clients.Find<Client>(client => client.Name == name).FirstOrDefault();
       // public Client GetCep(string cep) => _clients.Find<Client>(client => client.Cep.Id == cep).FirstOrDefault();
        //public void Update(string id, Client clientIn) => _clients.ReplaceOne(client => client.Id == id, clientIn);
        //public void Remove(Client clientIn) => _clients.DeleteOne(client => client.Id == clientIn.Id);
    }
}
