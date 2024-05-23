using Account_book.API.Domain.Entity;
using Account_book.API.Infrastructures.Database;
using Account_book.API.Repositories.Interfaces;
using Dapper;

namespace Account_book.API.Repositories.Implements;

public class LoginRepository : ILoginRepository
{
    private readonly DatabaseConnectionHelper _connectionHelper;
    public LoginRepository(DatabaseConnectionHelper databaseConnectionHelper) => _connectionHelper = databaseConnectionHelper;
    public async Task<Member> ValidateUser(Member entity)
    {
        string sql = @"
                    SELECT *
                      FROM [NkjMoney].[dbo].[Member]
                     WHERE [Email]  = @Email
                       AND [Password] = @Password
        ";
        using var conn = _connectionHelper.NkjMoneyConn();
        var reslut = await conn.QueryAsync<Member>(sql, entity);
        return reslut.FirstOrDefault();
    }
}
