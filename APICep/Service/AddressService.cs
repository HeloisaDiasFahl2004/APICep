using APICep.Models;
using APICep.Utils;
using MongoDB.Driver;
using System.IO;
using System.Net;

namespace APICep.Service
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;

        public AddressService(IDatabaseSettings settings)
        {
            var address = new MongoClient(settings.ConnectionString);
            var database = address.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }

        public string GetAddress(string cep) //método utilizado para executar uma requisição web
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + cep + "/json/"); //url
            request.AllowAutoRedirect = false;
            HttpWebResponse verificaServidor = (HttpWebResponse)request.GetResponse();
            Stream stream = verificaServidor.GetResponseStream();
            if (stream == null) return null;
            StreamReader answerReader = new StreamReader(stream);
            string message = answerReader.ReadToEnd();
            return message;

        }
        public Address Create(Address address) //método utilizado para executar uma requisição web
        {
            _address.InsertOne(address);
            return address;
        }
    }

    }

