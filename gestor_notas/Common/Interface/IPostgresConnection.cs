using Npgsql;

namespace gestor_notas.Common.Interface
{
    public interface IPostgresConnection
    {
        NpgsqlConnection GetConnection();
    }
}
