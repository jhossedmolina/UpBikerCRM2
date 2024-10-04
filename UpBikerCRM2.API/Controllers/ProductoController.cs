using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpBikerCRM.Core.Entities;

namespace UpBikerCRM2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly Inventario _inventario;

        public ProductoController(Inventario inventario)
        {
            _inventario = inventario;
        }

        [HttpGet("{categoria}")]
        public async Task<ActionResult> ListarProductosPorCategoria(string categoria)
        {
            var listaProductos = _inventario.ListarProductosPorCategoria(categoria);
            if(listaProductos.Count == 0)
            {
                return NotFound($"No se han encontrado productos con la categoría {categoria}");
            }
            else
            {
                return Ok(listaProductos);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AgregarProducto(Inventario.Producto producto)
        {
            _inventario.AgregarProducto(producto.Nombre, producto.Precio, producto.Categoria);
            return Ok($"El producto se ha agregado correctamente");
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarProducto(string nombre, string categoria)
        {
            var resultado = _inventario.EliminarProducto(nombre, categoria);
            if (!resultado)
            {
                return NotFound("No se ha encontrado un producto con la información ingresada");
            }
            return NoContent();
        }
    }
}
