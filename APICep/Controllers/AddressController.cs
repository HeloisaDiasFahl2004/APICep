using APICep.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICep.Controllers
{
    [Route("address/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet("{cep}")]
        public ActionResult<string> GetAddress(string cep)
        {
            var address = _addressService.GetAddress(cep);

            if (address == null) return NotFound();

            return Ok(address);
        }
    }
}
