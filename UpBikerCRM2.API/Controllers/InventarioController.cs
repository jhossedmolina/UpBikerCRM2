using Microsoft.AspNetCore.Mvc;
using UpBikerCRM.Core.Entities;

namespace UpBikerCRM2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly Inventario _inventario;

        public InventarioController(Inventario inventario)
        {
            _inventario = inventario;
        }

        [HttpGet]
        public async Task<ActionResult> CalcularValorTotalInventario()
        {
            double valorTotalInventario = _inventario.CalcularValorTotalInventario();
            return Ok(valorTotalInventario);
        }
    }
}
