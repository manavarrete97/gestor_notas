using gestor_notas.DAO.Interface;
using gestor_notas.DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.DAO
{
    public class GetProfesorDAO : IGetProfesorDAO
    {
        public async Task<ProfesorDTO> GetProfesorByIdAsync(NpgsqlConnection connection, int id)
        {
            try
            {
                var query = "SELECT id, nombre FROM Profesor WHERE id = @id;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new ProfesorDTO
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            };
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el profesor por ID: {ex.Message}", ex);
            }
        }

        public async Task<List<ProfesorDTO>> GetAllProfesoresAsync(NpgsqlConnection connection)
        {
            try
            {
                var query = "SELECT id, nombre FROM Profesor;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var profesores = new List<ProfesorDTO>();

                        while (await reader.ReadAsync())
                        {
                            profesores.Add(new ProfesorDTO
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            });
                        }

                        return profesores;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la lista de profesores: {ex.Message}", ex);
            }
        }
    }
}
