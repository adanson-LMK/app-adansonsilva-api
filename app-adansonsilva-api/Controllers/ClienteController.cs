
using app_adansonsilva_api.Data;
using app_adansonsilva_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace app_adansonsilva_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private ICliente _cliente;

        public ClienteController(ICliente icliente) {
            this._cliente = icliente;
        }
        [HttpGet]
        public async Task<IActionResult> ListarCliente()
        {
            return Ok(await _cliente.ListarCliente());
        }
        [HttpGet("{codigo}")]
        public async Task<IActionResult> BuscarCliente(String codigo)
        {
            return Ok(await _cliente.BuscarCliente(codigo));
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarCliente([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();
            if (cliente == null) return BadRequest(ModelState);
            var registro = await _cliente.RegistarCliente(cliente);
            return Created("Cliente resgistrado", registro);
        }
        [HttpPut]
        public async Task<IActionResult> EditarCliente([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();
            if (cliente == null) return BadRequest(ModelState);
            var registro = await _cliente.EditarCliente(cliente);
            return Created("Cliente editado", registro);
        }
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> BorrarCliente(String codigo)
        {
            var registro = await _cliente.BorrarCliente(codigo);
            return Created("Cliente borrado", registro);
        }
        
    }
}
