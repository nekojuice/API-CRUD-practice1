using Account_book.API.Domain.Request.Get;
using Account_book.API.Infrastructures.Database;
using Account_book.API.Repositories.Interfaces;
using API_CRUD_practice1.Domain.Entity;
using Dapper;

namespace Account_book.API.Repositories.Implements
{
    public class AccountingRepository : IAccountingRepository
    {
        private readonly DatabaseConnectionHelper _connectionHelper;

        public AccountingRepository(DatabaseConnectionHelper databaseConnectionHelper)
        {
            _connectionHelper = databaseConnectionHelper;
        }

        public async Task<IEnumerable<Accounting>> GetAsync(QueryAccountingRequest entity)
        {
            string sql = @"SELECT [accountingId],a.[memberId],[typeId],[message],[money],[recordTime],[timestamp] 
                        FROM Accounting AS a
                        JOIN Member AS m ON a.memberId = m.memberId
                        WHERE 1 = 1 ";
            if (entity != null)
            {
                if (entity.email != null) { sql += "AND email = @email "; }
            }

            using (var conn = _connectionHelper.NkjMoneyConn())
            {
                var data = await conn.QueryAsync<Accounting>(sql, entity);
                return data;
            }
        }
    }
}
