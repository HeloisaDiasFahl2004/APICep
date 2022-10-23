using APICep.Models;
using APICep.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APICep.Controllers
{
    [Route("client/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        private readonly AddressService _addressService;

        public ClientController(ClientService clientService, AddressService addressService)
        {
            _clientService = clientService;
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Client>> Get() => _clientService.GetAll();

        [HttpGet("{Id:length(24)}", Name = "GetClient")]
        public ActionResult<Client> Get(string id)
        {
            var client = _clientService.GetById(id);
            if (client == null) return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public ActionResult<Client> Post(Client client)
        {
            Address address = _addressService.Create(client.Cep);//pega o objeto address
            client.Cep = address;//insere o address e já traz de volta
            _clientService.Create(client);
            return CreatedAtRoute("GetClient", new { id = client.Id.ToString() }, client);
        }
    }
}