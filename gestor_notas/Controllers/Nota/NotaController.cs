using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Controllers.Nota
{
 [ApiController]
 [Route("api/[controller]")]
 public class NotaController : ControllerBase
 {
 private readonly IGetNotaManager _getNotaManager;
 private readonly IPostNotaManager _postNotaManager;
 private readonly IUpdateNotaManager _updateNotaManager;
 private readonly IDeleteNotaManager _deleteNotaManager;

 public NotaController(
 IGetNotaManager getNotaManager,
 IPostNotaManager postNotaManager,
 IUpdateNotaManager updateNotaManager,
 IDeleteNotaManager deleteNotaManager)
 {
 _getNotaManager = getNotaManager;
 _postNotaManager = postNotaManager;
 _updateNotaManager = updateNotaManager;
 _deleteNotaManager = deleteNotaManager;
 }

 [HttpGet]
 public async Task<IActionResult> GetNota([FromQuery] int idEstudiante, [FromQuery] int idMateria)
 {
 try
 {
 var nota = await _getNotaManager.GetNotaByEstudianteAndMateriaAsync(idEstudiante, idMateria);
 if (nota == null)
 {
 return NotFound("Nota no encontrada.");
 }
 return Ok(nota);
 }
 catch (Exception ex)
 {
 return StatusCode(500, $"Error al obtener la nota: {ex.Message}");
 }
 }

 [HttpPost]
 public async Task<IActionResult> AddNota([FromBody] NotaDTO notaDTO)
 {
 if (string.IsNullOrWhiteSpace(notaDTO.Nombre) || notaDTO.IdMateria <=0 || notaDTO.IdEstudiante <=0 || notaDTO.Valor <=0)
 {
 return BadRequest("Datos inválidos para agregar la nota.");
 }

 try
 {
 var result = await _postNotaManager.AddNotaAsync(notaDTO);
 if (result)
 {
 return Ok("Nota agregada exitosamente.");
 }
 return StatusCode(500, "Error al agregar la nota.");
 }
 catch (Exception ex)
 {
 return StatusCode(500, ex.Message);
 }
 }

 [HttpPut]
 public async Task<IActionResult> UpdateNota([FromQuery] int idNota, [FromQuery] int idProfesor, [FromBody] decimal valor)
 {
 if (idNota <=0 || idProfesor <=0 || valor <=0)
 {
 return BadRequest("Datos inválidos para actualizar la nota.");
 }

 try
 {
 var result = await _updateNotaManager.UpdateNotaAsync(idNota, valor, idProfesor);
 if (result)
 {
 return Ok("Nota actualizada exitosamente.");
 }
 return NotFound("Nota no encontrada o el profesor no está autorizado.");
 }
 catch (Exception ex)
 {
 return StatusCode(500, ex.Message);
 }
 }

 [HttpDelete]
 public async Task<IActionResult> DeleteNota([FromQuery] int idNota, [FromQuery] int idProfesor)
 {
 if (idNota <=0 || idProfesor <=0)
 {
 return BadRequest("Datos inválidos para eliminar la nota.");
 }

 try
 {
 var result = await _deleteNotaManager.DeleteNotaAsync(idNota, idProfesor);
 if (result)
 {
 return Ok("Nota eliminada exitosamente.");
 }
 return NotFound("Nota no encontrada o el profesor no está autorizado.");
 }
 catch (Exception ex)
 {
 return StatusCode(500, ex.Message);
 }
 }

 [HttpGet("details")]
 public async Task<IActionResult> GetNotasByMateriaWithDetails([FromQuery] int idMateria)
 {
 try
 {
 var notas = await _getNotaManager.GetNotasByMateriaWithDetailsAsync(idMateria);
 if (notas == null || notas.Count ==0)
 {
 return NotFound("No se encontraron notas para la materia especificada.");
 }
 return Ok(notas);
 }
 catch (Exception ex)
 {
 return StatusCode(500, $"Error al obtener las notas con detalles: {ex.Message}");
 }
 }
 }
}