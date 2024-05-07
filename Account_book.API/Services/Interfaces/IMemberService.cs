using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Domain.Entity;
using Account_book.API.Domain.Response;

namespace Account_book.API.Services.Interfaces
{
    public interface IMemberService
    {
        public Task<ResultResponse> GetAsync(Guid? request);
        public Task<ResultResponse> InsertAsync(InsertMemberRequest request);
        public Task<ResultResponse> UpdateAsync(Member request);
        public Task<ResultResponse> DeleteAsync(Guid request);
    }
}
