using gestor_notas.Common.Interface;
using Npgsql;

namespace gestor_notas.Common
{
    public class PostgresConnection : IPostgresConnection
    {
        private readonly string _connectionString;

        public PostgresConnection()
        {
            _connectionString = "Host=localhost;Port=5433;Username=postgres;Password=Mateo123*;Database=escuela;";
        }
        public NpgsqlConnection GetConnection()
        {
            int retryCount = 3;
            while (retryCount > 0)
            {
                try
                {
                    var connection = new NpgsqlConnection(_connectionString);
                    connection.Open();

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("✅ Conexión establecida correctamente con PostgreSQL");
                        return connection;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error al conectar a PostgreSQL: {ex.Message}");
                    retryCount--;

                    if (retryCount == 0)
                    {
                        throw new Exception("Se agotaron los intentos de conexión a PostgreSQL.", ex);
                    }

                    Console.WriteLine("🔄 Reintentando conexión...");
                }
            }

            throw new Exception("No se pudo establecer la conexión a PostgreSQL.");
        }
    }
}
