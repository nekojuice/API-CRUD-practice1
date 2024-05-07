using Microsoft.Data.SqlClient;

namespace Account_book.API.Infrastructures.Database
{
    public class DatabaseConnectionHelper
    {
        private readonly IConfiguration _configuration;

        public DatabaseConnectionHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection NkjMoneyConn()
        {
            return new SqlConnection(_configuration.GetConnectionString("NkjMoney"));
        }
    }
}
