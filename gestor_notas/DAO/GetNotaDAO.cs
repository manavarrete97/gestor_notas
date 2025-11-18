using gestor_notas.DTO;
using gestor_notas.DAO.Interface;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.DAO
{
    public class GetNotaDAO : IGetNotaDAO
    {
        public async Task<NotaDTO> GetNotaByEstudianteAndMateriaAsync(NpgsqlConnection connection, int idEstudiante, int idMateria)
        {
            try
            {
                var query = "SELECT id, nombre, id_materia, id_estudiante, valor FROM nota WHERE id_estudiante = @idEstudiante AND id_materia = @idMateria;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idEstudiante", idEstudiante);
                    command.Parameters.AddWithValue("@idMateria", idMateria);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new NotaDTO
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                IdMateria = reader.GetInt32(2),
                                IdEstudiante = reader.GetInt32(3),
                                Valor = reader.GetDecimal(4)
                            };
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la nota: {ex.Message}", ex);
            }
        }

        public async Task<List<NotaDTO>> GetNotasByMateriaAsync(NpgsqlConnection connection, int idMateria)
        {
            try
            {
                var query = "SELECT id, nombre, id_materia, id_estudiante, valor FROM nota WHERE id_materia = @idMateria;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idMateria", idMateria);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var notas = new List<NotaDTO>();

                        while (await reader.ReadAsync())
                        {
                            notas.Add(new NotaDTO
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                IdMateria = reader.GetInt32(2),
                                IdEstudiante = reader.GetInt32(3),
                                Valor = reader.GetDecimal(4)
                            });
                        }

                        return notas;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las notas: {ex.Message}", ex);
            }
        }

        public async Task<List<NotaDTO>> GetNotasByMateriaWithDetailsAsync(NpgsqlConnection connection, int idMateria)
        {
            try
            {
                var query = @"SELECT n.id, n.nombre, n.id_materia, n.id_estudiante, n.valor, 
 m.nombre AS materia_nombre, e.nombre AS estudiante_nombre
 FROM nota n
 INNER JOIN materia m ON n.id_materia = m.id
 INNER JOIN estudiante e ON n.id_estudiante = e.id
 WHERE n.id_materia = @idMateria;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idMateria", idMateria);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var notas = new List<NotaDTO>();

                        while (await reader.ReadAsync())
                        {
                            notas.Add(new NotaDTO
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                IdMateria = reader.GetInt32(2),
                                IdEstudiante = reader.GetInt32(3),
                                Valor = reader.GetDecimal(4),
                                MateriaNombre = reader.GetString(5),
                                EstudianteNombre = reader.GetString(6)
                            });
                        }

                        return notas;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las notas con detalles: {ex.Message}", ex);
            }
        }
    }
}