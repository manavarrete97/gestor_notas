using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Controllers.Materia
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaController : ControllerBase
    {
        private readonly IGetMateriaManager _getMateriaManager;
        private readonly IPostMateriaManager _postMateriaManager;
        private readonly IUpdateMateriaManager _updateMateriaManager;
        private readonly IDeleteMateriaManager _deleteMateriaManager;

        public MateriaController(
        IGetMateriaManager getMateriaManager,
        IPostMateriaManager postMateriaManager,
        IUpdateMateriaManager updateMateriaManager,
        IDeleteMateriaManager deleteMateriaManager)
        {
            _getMateriaManager = getMateriaManager;
            _postMateriaManager = postMateriaManager;
            _updateMateriaManager = updateMateriaManager;
            _deleteMateriaManager = deleteMateriaManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetMateria([FromQuery] int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var materia = await _getMateriaManager.GetMateriaByIdAsync(id.Value);
                    if (materia == null)
                    {
                        return NotFound("Materia no encontrada.");
                    }
                    return Ok(materia);
                }
                else
                {
                    var materias = await _getMateriaManager.GetAllMateriasAsync();
                    return Ok(materias);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las materias: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMateria([FromBody] MateriaDTO materiaDTO)
        {
            if (string.IsNullOrWhiteSpace(materiaDTO.Nombre) || materiaDTO.IdProfesor <= 0)
            {
                return BadRequest("Datos inválidos para agregar la materia.");
            }

            var result = await _postMateriaManager.AddMateriaAsync(materiaDTO);

            if (result)
            {
                return Ok("Materia agregada exitosamente.");
            }

            return StatusCode(500, "Error al agregar la materia.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMateria([FromBody] MateriaDTO materiaDTO)
        {
            if (materiaDTO.Id <= 0 || string.IsNullOrWhiteSpace(materiaDTO.Nombre) || materiaDTO.IdProfesor <= 0)
            {
                return BadRequest("Datos inválidos para actualizar la materia.");
            }

            var result = await _updateMateriaManager.UpdateMateriaAsync(materiaDTO);

            if (result)
            {
                return Ok("Materia actualizada exitosamente.");
            }

            return NotFound("Materia no encontrada.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMateria([FromQuery] int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido para eliminar la materia.");
            }

            var result = await _deleteMateriaManager.DeleteMateriaAsync(id);

            if (result)
            {
                return Ok("Materia eliminada exitosamente.");
            }

            return NotFound("Materia no encontrada.");
        }
    }
}