using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Infrastructures.Database;
using Account_book.API.Repositories.Interfaces;
using Account_book.API.Domain.Entity;
using Dapper;
using static Dapper.SqlMapper;

namespace Account_book.API.Repositories.Implements
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DatabaseConnectionHelper _connectionHelper;
        public MemberRepository(DatabaseConnectionHelper databaseConnectionHelper)
        {
            _connectionHelper = databaseConnectionHelper;
        }


        public async Task<IEnumerable<Member>> GetAsync(Member? entity)
        {
            string sql = @"SELECT * FROM Member as m
                            WHERE 1 = 1";

            if (entity != null)
            {
                if (entity.memberId != Guid.Empty) { sql += @" AND m.memberId = @memberId"; }
                if (!string.IsNullOrEmpty(entity.name)) { sql += @" AND m.name = @name"; }
                if (!string.IsNullOrEmpty(entity.email)) { sql += @" AND m.email = @email"; }
            }
            using (var conn = _connectionHelper.NkjMoneyConn())
            {
                var reslut = await conn.QueryAsync<Member>(sql, entity);
                return reslut;
            }
        }

        public async Task<IEnumerable<Member>> GetByMemberIdAsync(Guid memberId)
        {
            string sql = @"SELECT * FROM [dbo].[Member]
                            WHERE memberId = @memberId";
            using (var conn = _connectionHelper.NkjMoneyConn())
            {
                var reslut = await conn.QueryAsync<Member>(sql, new { memberId = memberId });
                return reslut;
            }
        }

        public async Task<bool> InsertAsync(Member entity)
        {
            string sql = @"INSERT Member(name, email, password)
                            VALUES(@name, @email, @password)";
            using (var conn = _connectionHelper.NkjMoneyConn())
            {
                int count = await conn.ExecuteAsync(sql, entity);
                return count == 1 ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(Member entity)
        {
            string sql = @"UPDATE Member 
                            SET name = @name,
                                email = @email,
                                password = @password
                            WHERE memberId = @memberId";
            using (var conn = _connectionHelper.NkjMoneyConn())
            {
                int count = await conn.ExecuteAsync(sql, entity);
                return (count == 1 ? true : false);
            }
        }

        public async Task<bool> DeleteAsync(Guid memberId)
        {
            string sql = @"DELETE FROM Member
                            WHERE memberId = @memberId
                            ";
            using (var conn = _connectionHelper.NkjMoneyConn())
            {
                int count = await conn.ExecuteAsync(sql, new { memberId = memberId });
                return (count == 1 ? true : false);
            }
        }


    }
}
