using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Domain.Entity;
using Account_book.API.Domain.Response;
using Account_book.API.Domain.Request.Put;

namespace Account_book.API.Services.Interfaces;

public interface IMemberService
{
    public Task<ResultResponse> GetAsync(QueryMemberRequest? request);
    public Task<ResultResponse> GetByMemberIdAsync(Guid memberId);
    public Task<ResultResponse> InsertAsync(InsertMemberRequest request);
    public Task<ResultResponse> UpdateAsync(PutMemberRequest request);
    public Task<ResultResponse> DeleteAsync(Guid request);
}
