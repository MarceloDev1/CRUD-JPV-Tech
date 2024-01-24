using Microsoft.Data.SqlClient;

namespace CRUDPessoas.Data
{
    public class ConnectionFactory
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=LAPTOP-84PPAT8A\\SQLEXPRESS;Initial Catalog=Pessoas;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            return new SqlConnection(connectionString);
        }
    }
}