using app_adansonsilva_api.Data;
using app_adansonsilva_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace app_adansonsilva_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private IProducto _producto;

        public ProductoController(IProducto iproducto) {
            this._producto = iproducto;
        }
        [HttpGet]
        public async Task<IActionResult> ListarProducto()
        {
            return Ok(await _producto.ListarProduto());
        }
        [HttpGet("{codigo}")]
        public async Task<IActionResult> BuscarProducto(String codigo)
        {
            return Ok(await _producto.BuscarProducto(codigo));
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarProducto([FromBody] Producto producto)
        {
            if (producto == null) return BadRequest();
            if (producto == null) return BadRequest(ModelState);
            var registro = await _producto.RegistarProducto(producto);
            return Created("Producto resgistrado", registro);
        }
        [HttpPut]
        public async Task<IActionResult> EditarProducto([FromBody] Producto producto)
        {
            if (producto == null) return BadRequest();
            if (producto == null) return BadRequest(ModelState);
            var registro = await _producto.EditarProducto(producto);
            return Created("Producto editado", registro);
        }
        [HttpDelete]
        public async Task<IActionResult> BorrarProducto(String codigo)
        {
            var registro = await _producto.BorrarProducto(codigo);
            return Created("Producto borrado", registro);
        }
        
    }
}
