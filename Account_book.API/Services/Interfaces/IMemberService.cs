using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Domain.Entity;

namespace Account_book.API.Services.Interfaces
{
    public interface IMemberService
    {
        public Task<IEnumerable<Member>> GetAsync(QueryMemberRequest condition);
        public Task<bool> InsertAsync(InsertMemberRequest entity);
        public Task<bool> UpdateAsync(Member entity);
        public Task<bool> DeleteAsync(Guid id);
    }
}
