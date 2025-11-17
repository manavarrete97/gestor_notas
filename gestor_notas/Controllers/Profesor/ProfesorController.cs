using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Controllers.Profesor
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly IPostProfesorManager _postProfesorManager;
        private readonly IGetProfesorManager _getProfesorManager;
        private readonly IDeleteProfesorManager _deleteProfesorManager;
        private readonly IUpdateProfesorManager _updateProfesorManager;

        public ProfesorController(
            IPostProfesorManager postProfesorManager,
            IGetProfesorManager getProfesorManager,
            IDeleteProfesorManager deleteProfesorManager,
            IUpdateProfesorManager updateProfesorManager)
        {
            _postProfesorManager = postProfesorManager;
            _getProfesorManager = getProfesorManager;
            _deleteProfesorManager = deleteProfesorManager;
            _updateProfesorManager = updateProfesorManager;
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

        [HttpGet]
        public async Task<IActionResult> GetProfesor([FromQuery] int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var profesor = await _getProfesorManager.GetProfesorByIdAsync(id.Value);
                    if (profesor == null)
                    {
                        return NotFound("Profesor no encontrado.");
                    }
                    return Ok(profesor);
                }
                else
                {
                    var profesores = await _getProfesorManager.GetAllProfesoresAsync();
                    return Ok(profesores);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los profesores: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProfesor([FromQuery] int id)
        {
            try
            {
                var result = await _deleteProfesorManager.DeleteProfesorAsync(id);

                if (result)
                {
                    return Ok("Profesor eliminado exitosamente.");
                }

                return NotFound("Profesor no encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el profesor: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfesor([FromBody] ProfesorDTO profesorDTO)
        {
            if (profesorDTO.Id <= 0 || string.IsNullOrWhiteSpace(profesorDTO.Nombre))
            {
                return BadRequest("Datos inválidos para actualizar el profesor.");
            }

            try
            {
                var result = await _updateProfesorManager.UpdateProfesorAsync(profesorDTO);

                if (result)
                {
                    return Ok("Profesor actualizado exitosamente.");
                }

                return NotFound("Profesor no encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el profesor: {ex.Message}");
            }
        }
    }
}
