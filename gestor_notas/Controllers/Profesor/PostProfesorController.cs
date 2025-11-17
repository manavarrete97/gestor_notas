using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace gestor_notas.Controllers.Profesor
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostProfesorController : ControllerBase
    {
        private readonly IPostProfesorManager _postProfesorManager;

        public PostProfesorController(IPostProfesorManager postProfesorManager)
        {
            _postProfesorManager = postProfesorManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddProfesor([FromBody] ProfesorDTO profesorDTO)
        {
            if (string.IsNullOrWhiteSpace(profesorDTO.Nombre))
            {
                return BadRequest("El nombre del profesor es requerido.");
            }

            var result = await _postProfesorManager.AddProfesorAsync(profesorDTO);

            if (result)
            {
                return Ok("Profesor agregado exitosamente.");
            }

            return StatusCode(500, "Error al agregar el profesor.");
        }
    }
}
