using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Domain.Entity;
using Account_book.API.Domain.Response;
using Account_book.API.Domain.Request.Put;

namespace Account_book.API.Services.Interfaces;

public interface IMemberService
{
    public Task<IResultResponse> GetAsync(QueryMemberRequest? request);
    public Task<IResultResponse> GetByMemberIdAsync(Guid memberId);
    public Task<IResultResponse> InsertAsync(InsertMemberRequest request);
    public Task<IResultResponse> UpdateAsync(PutMemberRequest request);
    public Task<IResultResponse> DeleteAsync(Guid request);
}
