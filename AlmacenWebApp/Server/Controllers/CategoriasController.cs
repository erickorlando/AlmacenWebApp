using AlmacenWebApp.Entidades;
using AlmacenWebApp.Server.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace AlmacenWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaServicio _servicio;

        public CategoriasController(CategoriaServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_servicio.Listar());
        }

        [HttpPost]
        public IActionResult Crear(Categoria categoria)
        {
            try
            {
                _servicio.Agregar(categoria);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error al insertar los datos");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Actualizar(int id, Categoria categoria)
        {
            _servicio.Actualizar(id, categoria);
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
