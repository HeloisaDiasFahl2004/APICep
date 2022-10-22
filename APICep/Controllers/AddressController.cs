using APICep.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICep.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public AddressController()
        {
            //vazio pois no método getAdress já tem a requisição HTTP
        }
        [HttpGet("{cep}")]
        public ActionResult<string> GetAddress(string cep)
        {
            var address = new AddressService().GetAddress(cep);

            if (address == null) return NotFound();

            return Ok(address);
        }
    }
}
