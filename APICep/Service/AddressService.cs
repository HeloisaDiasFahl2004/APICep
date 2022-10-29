using APICep.Models;
using APICep.Utils;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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
        //public async Task<Address> GetAddress(string cep)
        //{
        //    HttpClient httpClient = new HttpClient();   
        //    var response = await httpClient.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
        //    var jsonString= await response.Content.ReadAsStringAsync();
        //    Address jsonObject = JsonConvert.DeserializeObject<Address>(jsonString);
        //    if (jsonObject == null) return NotFound();
        //    return jsonObject;  
        //}
        public Address Create(Address address) //método utilizado para executar uma requisição web
        {
            _address.InsertOne(address);
            return address;
        }
    }

}