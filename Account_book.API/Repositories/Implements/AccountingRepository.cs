using Account_book.API.Domain.Request.Get;
using Account_book.API.Infrastructures.Database;
using Account_book.API.Repositories.Interfaces;
using Account_book.API.Domain.Entity;
using Dapper;
using AutoMapper.Execution;
using static Dapper.SqlMapper;

namespace Account_book.API.Repositories.Implements;

public class AccountingRepository : IAccountingRepository
{
    private readonly DatabaseConnectionHelper _connectionHelper;

    public AccountingRepository(DatabaseConnectionHelper databaseConnectionHelper)
    {
        _connectionHelper = databaseConnectionHelper;
    }


    public async Task<IEnumerable<Accounting>> GetAsync(Accounting? entity)
    {
        string sql = @"
                    SELECT * FROM [NkjMoney].[dbo].[Accounting]
                     WHERE 1 = 1";
        if (entity != null)
        {
            if (entity.AccountingId != Guid.Empty) { sql += @" AND [AccountingId] = @AccountingId"; }
            if (entity.MemberId != Guid.Empty) { sql += @" AND [MemberId] = @MemberId"; }
            if (entity.TypeId != Guid.Empty) { sql += @" AND [TypeId] = @TypeId"; }
        }
        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            var data = await conn.QueryAsync<Accounting>(sql, entity);
            return data;
        }
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

    public async Task<bool> InsertAsync(Accounting entity)
    {
        string sql = @"
                    INSERT INTO [NkjMoney].[dbo].[Accounting]
                               ([MemberId]
                               ,[TypeId]
                               ,[Message]
                               ,[Money]
                               ,[RecordTime])
                         VALUES
                               (@MemberId
                               ,@TypeId
                               ,@Message
                               ,@Money
                               ,@RecordTime)";
        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            int count = await conn.ExecuteAsync(sql, entity);
            return count == 1 ? true : false;
        }
    }

    public async Task<bool> UpdateAsync(Accounting entity)
    {
        string sql = @"
                    UPDATE [NkjMoney].[dbo].[Accounting]
                       SET [MemberId] = @MemberId
                          ,[TypeId] = @TypeId
                          ,[Message] = @Message
                          ,[Money] = @Money
                          ,[RecordTime] = @RecordTime
                          ,[Timestamp] = @Timestamp
                     WHERE [AccountingId] = @AccountingId";
        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            int count = await conn.ExecuteAsync(sql, entity);
            return count == 1 ? true : false;
        }
    }

    public async Task<bool> DeleteAsync(Guid accountingId)
    {
        string sql = @"
                    DELETE FROM [NkjMoney].[dbo].[Accounting]
                          WHERE [AccountingId] = @accountingId";
        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            int count = await conn.ExecuteAsync(sql, new { accountingId = accountingId });
            return count == 1 ? true : false;
        }
    }
}
