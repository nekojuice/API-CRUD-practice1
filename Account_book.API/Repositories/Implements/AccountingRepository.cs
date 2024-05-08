using Account_book.API.Domain.Request.Get;
using Account_book.API.Infrastructures.Database;
using Account_book.API.Repositories.Interfaces;
using Account_book.API.Domain.Entity;
using Dapper;

namespace Account_book.API.Repositories.Implements;

public class AccountingRepository : IAccountingRepository
{
    private readonly DatabaseConnectionHelper _connectionHelper;

    public AccountingRepository(DatabaseConnectionHelper databaseConnectionHelper)
    {
        _connectionHelper = databaseConnectionHelper;
    }

    public async Task<IEnumerable<Accounting>> GetByMemberIdAsync(Guid memberId)
    {
        string sql = @"SELECT [accountingId],a.[memberId],[typeId],[message],[money],[recordTime],[timestamp] 
                        FROM Accounting AS a
                        JOIN Member AS m ON a.memberId = m.memberId
                        WHERE a.memberId = @memberId";

        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            var data = await conn.QueryAsync<Accounting>(sql, new { memberId = memberId });
            return data;
        }
    }
}
