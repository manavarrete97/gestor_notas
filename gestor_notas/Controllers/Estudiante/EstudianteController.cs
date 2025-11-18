using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Controllers.Estudiante
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly IGetEstudianteManager _getEstudianteManager;
        private readonly IPostEstudianteManager _postEstudianteManager;
        private readonly IUpdateEstudianteManager _updateEstudianteManager;
        private readonly IDeleteEstudianteManager _deleteEstudianteManager;

        public EstudianteController(
        IGetEstudianteManager getEstudianteManager,
        IPostEstudianteManager postEstudianteManager,
        IUpdateEstudianteManager updateEstudianteManager,
        IDeleteEstudianteManager deleteEstudianteManager)
        {
            _getEstudianteManager = getEstudianteManager;
            _postEstudianteManager = postEstudianteManager;
            _updateEstudianteManager = updateEstudianteManager;
            _deleteEstudianteManager = deleteEstudianteManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstudiante([FromQuery] int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var estudiante = await _getEstudianteManager.GetEstudianteByIdAsync(id.Value);
                    if (estudiante == null)
                    {
                        return NotFound("Estudiante no encontrado.");
                    }
                    return Ok(estudiante);
                }
                else
                {
                    var estudiantes = await _getEstudianteManager.GetAllEstudiantesAsync();
                    return Ok(estudiantes);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los estudiantes: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEstudiante([FromBody] EstudianteDTO estudianteDTO)
        {
            if (string.IsNullOrWhiteSpace(estudianteDTO.Nombre))
            {
                return BadRequest("El nombre del estudiante es requerido.");
            }

            var result = await _postEstudianteManager.AddEstudianteAsync(estudianteDTO);

            if (result)
            {
                return Ok("Estudiante agregado exitosamente.");
            }

            return StatusCode(500, "Error al agregar el estudiante.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEstudiante([FromBody] EstudianteDTO estudianteDTO)
        {
            if (estudianteDTO.Id <= 0 || string.IsNullOrWhiteSpace(estudianteDTO.Nombre))
            {
                return BadRequest("Datos inválidos para actualizar el estudiante.");
            }

            var result = await _updateEstudianteManager.UpdateEstudianteAsync(estudianteDTO);

            if (result)
            {
                return Ok("Estudiante actualizado exitosamente.");
            }

            return NotFound("Estudiante no encontrado.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEstudiante([FromQuery] int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido para eliminar el estudiante.");
            }

            var result = await _deleteEstudianteManager.DeleteEstudianteAsync(id);

            if (result)
            {
                return Ok("Estudiante eliminado exitosamente.");
            }

            return NotFound("Estudiante no encontrado.");
        }
    }
}