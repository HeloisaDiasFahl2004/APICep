using System.IO;
using System.Net;

namespace APICep.Service
{
    public class AddressService
    {
        public AddressService()
        {

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

    }
}
