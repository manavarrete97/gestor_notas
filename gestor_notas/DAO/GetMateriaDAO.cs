using gestor_notas.DTO;
using gestor_notas.DAO.Interface;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.DAO
{
    public class GetMateriaDAO : IGetMateriaDAO
    {
        public async Task<MateriaDTO> GetMateriaByIdAsync(NpgsqlConnection connection, int id)
        {
            try
            {
                var query = "SELECT id, nombre, id_profesor FROM materia WHERE id = @id;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new MateriaDTO
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                IdProfesor = reader.GetInt32(2)
                            };
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la materia por ID: {ex.Message}", ex);
            }
        }

        public async Task<List<MateriaDTO>> GetAllMateriasAsync(NpgsqlConnection connection)
        {
            try
            {
                var query = "SELECT id, nombre, id_profesor FROM materia;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var materias = new List<MateriaDTO>();

                        while (await reader.ReadAsync())
                        {
                            materias.Add(new MateriaDTO
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                IdProfesor = reader.GetInt32(2)
                            });
                        }

                        return materias;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la lista de materias: {ex.Message}", ex);
            }
        }
    }
}