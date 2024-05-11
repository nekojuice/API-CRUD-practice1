using Account_book.API.Domain.Request.Get;
using Account_book.API.Infrastructures.Database;
using Account_book.API.Repositories.Interfaces;
using Account_book.API.Domain.Entity;
using Dapper;
using AutoMapper.Execution;
using static Dapper.SqlMapper;
using Account_book.API.Domain.Response.Get;

namespace Account_book.API.Repositories.Implements;

public class AccountingRepository : IAccountingRepository
{
    private readonly DatabaseConnectionHelper _connectionHelper;

    public AccountingRepository(DatabaseConnectionHelper databaseConnectionHelper)
    {
        _connectionHelper = databaseConnectionHelper;
    }


    public async Task<IEnumerable<GetAccountingResponse>> GetAsync(Accounting? entity)
    {
        string sql = @"
                SELECT [AccountingId]
                      ,[MemberId]
                      ,a.[TypeId]
                      ,[Message]
                      ,[Money]
                      ,[RecordTime]
                      ,[Timestamp]
                      ,t.[TypeName]
                  FROM [NkjMoney].[dbo].[Accounting] as a
                  JOIN [NkjMoney].[dbo].[LabelType] as t
                    ON a.[TypeId] = t.[TypeId]
                 WHERE 1 = 1";
        if (entity != null)
        {
            if (entity.AccountingId != Guid.Empty) { sql += @" AND [AccountingId] = @AccountingId"; }
            if (entity.MemberId != Guid.Empty) { sql += @" AND [MemberId] = @MemberId"; }
            if (entity.TypeId != Guid.Empty) { sql += @" AND a.[TypeId] = @TypeId"; }
        }
        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            var data = await conn.QueryAsync<GetAccountingResponse>(sql, entity);
            return data;
        }
    }

    // 含 TypeName
    public async Task<IEnumerable<GetAccountingResponse>> GetByMemberIdAsync(Guid memberId)
    {
        string sql = @"
                      SELECT [AccountingId]
                              ,a.[MemberId]
                              ,t.[TypeId]
                              ,[Message]
                              ,[Money]
                              ,[RecordTime]
                              ,[Timestamp]
                              ,t.[TypeName]
                        FROM [NkjMoney].[dbo].[Accounting] AS a
                        JOIN [NkjMoney].[dbo].[Member] AS m 
                          ON a.[MemberId] = m.[MemberId]
                        JOIN [NkjMoney].[dbo].[LabelType] AS t 
                          ON a.[TypeId] = t.[TypeId]
                       WHERE a.[MemberId] = @memberId";
        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            var data = await conn.QueryAsync<GetAccountingResponse>(sql, new { memberId = memberId });
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
