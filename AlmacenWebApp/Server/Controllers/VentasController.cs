using AlmacenWebApp.Server.Servicios;
using AlmacenWebApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AlmacenWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly VentaServicio _servicio;

        public VentasController(VentaServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_servicio.GetList());
        }

        [HttpPost]
        public IActionResult Post(VentaDto request)
        {
            _servicio.CrearVenta(request);
            return Ok();
        }
    }
}
