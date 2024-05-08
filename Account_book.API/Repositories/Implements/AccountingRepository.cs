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
        string sql = @"
                      SELECT [AccountingId]
                              ,a.[MemberId]
                              ,[TypeId]
                              ,[Message]
                              ,[Money]
                              ,[RecordTime]
                              ,[Timestamp]
                        FROM [NkjMoney].[dbo].[Accounting] AS a
                        JOIN [NkjMoney].[dbo].[Member] AS m 
                          ON a.[MemberId] = m.[MemberId]
                       WHERE a.[MemberId] = @memberId";

        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            var data = await conn.QueryAsync<Accounting>(sql, new { memberId = memberId });
            return data;
        }
    }
}
