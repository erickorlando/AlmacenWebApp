using AlmacenWebApp.Server.Servicios;
using AlmacenWebApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AlmacenWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoServicio _servicio;

        public ProductosController(ProductoServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_servicio.Listar());
        }

        [HttpPost]
        public IActionResult Crear(ProductoDto producto)
        {
            try
            {
                _servicio.Agregar(producto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error al insertar los datos");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Actualizar(int id, ProductoDto producto)
        {
            _servicio.Actualizar(id, producto);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult ObtenerPorId(int id)
        {
            var registro = _servicio.ObtenerPorId(id);
            if (registro is null)
            {
                return NotFound();
            }
            return Ok(registro);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Eliminar(int id)
        {
            _servicio.Eliminar(id);
            return Ok();
        }
    }
}
