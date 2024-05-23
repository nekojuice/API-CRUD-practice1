using Account_book.API.Domain.Entity;
using Account_book.API.Infrastructures.Database;
using Account_book.API.Repositories.Interfaces;
using Dapper;

namespace Account_book.API.Repositories.Implements
{
    public class LabelTypeRepository : ILabelTypeRepository
    {
        private readonly DatabaseConnectionHelper _connectionHelper;
        public LabelTypeRepository(DatabaseConnectionHelper databaseConnectionHelper)
        { _connectionHelper = databaseConnectionHelper; }

        public async Task<IEnumerable<LabelType>> GetAll()
        {
            string sql = @"
                        SELECT [TypeId]
                              ,[TypeName]
                          FROM [NkjMoney].[dbo].[LabelType]";
            using var conn = _connectionHelper.NkjMoneyConn();
            var result = await conn.QueryAsync<LabelType>(sql);
            return result;
        }
    }
}
