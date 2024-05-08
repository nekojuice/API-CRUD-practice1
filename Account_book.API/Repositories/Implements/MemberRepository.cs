using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Infrastructures.Database;
using Account_book.API.Repositories.Interfaces;
using Account_book.API.Domain.Entity;
using Dapper;
using static Dapper.SqlMapper;

namespace Account_book.API.Repositories.Implements;

public class MemberRepository : IMemberRepository
{
    private readonly DatabaseConnectionHelper _connectionHelper;
    public MemberRepository(DatabaseConnectionHelper databaseConnectionHelper)
    {
        _connectionHelper = databaseConnectionHelper;
    }


    public async Task<IEnumerable<Member>> GetAsync(Member? entity)
    {
        string sql = @"
                   SELECT * FROM [NkjMoney].[dbo].[Member]
                    WHERE 1 = 1";
        if (entity != null)
        {
            if (entity.MemberId != Guid.Empty) { sql += @" AND [MemberId] = @MemberId"; }
            if (!string.IsNullOrEmpty(entity.Name)) { sql += @" AND [Name] = @Name"; }
            if (!string.IsNullOrEmpty(entity.Email)) { sql += @" AND [Email] = @Email"; }
        }
        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            var reslut = await conn.QueryAsync<Member>(sql, entity);
            return reslut;
        }
    }

    public async Task<IEnumerable<Member>> GetByMemberIdAsync(Guid memberId)
    {
        string sql = @"
                   SELECT * FROM [NkjMoney].[dbo].[Member]
                    WHERE [MemberId] = @MemberId";
        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            var reslut = await conn.QueryAsync<Member>(sql, new { memberId = memberId });
            return reslut;
        }
    }

    public async Task<bool> InsertAsync(Member entity)
    {
        string sql = @"
                     INSERT INTO [NkjMoney].[dbo].[Member]
                           ([MemberId]
                           ,[Name]
                           ,[Email]
                           ,[Password])
                     VALUES
                           (<MemberId, uniqueidentifier,>
                           ,<Name, nvarchar(20),>
                           ,<Email, nvarchar(100),>
                           ,<Password, varchar(32),>)";
        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            int count = await conn.ExecuteAsync(sql, entity);
            return count == 1 ? true : false;
        }
    }

    public async Task<bool> UpdateAsync(Member entity)
    {
        string sql = @"
                    UPDATE [NkjMoney].[dbo].[Member]
                       SET [MemberId] = <MemberId, uniqueidentifier,>
                          ,[Name] = <Name, nvarchar(20),>
                          ,[Email] = <Email, nvarchar(100),>
                          ,[Password] = <Password, varchar(32),>
                     WHERE [MemberId] = @MemberId";
        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            int count = await conn.ExecuteAsync(sql, entity);
            return (count == 1 ? true : false);
        }
    }

    public async Task<bool> DeleteAsync(Guid memberId)
    {
        string sql = @"
                     DELETE FROM [NkjMoney].[dbo].[Member]
                      WHERE [MemberId] = @MemberId";
        using (var conn = _connectionHelper.NkjMoneyConn())
        {
            int count = await conn.ExecuteAsync(sql, new { memberId = memberId });
            return (count == 1 ? true : false);
        }
    }


}
