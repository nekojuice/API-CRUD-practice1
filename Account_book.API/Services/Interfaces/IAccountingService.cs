using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Entity;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Domain.Request.Put;
using Account_book.API.Domain.Response;

namespace Account_book.API.Services.Interfaces;

public interface IAccountingService
{
    public Task<IResultResponse> GetAsync(QueryAccountingRequest? request, Guid memberId);
    public Task<IResultResponse> GetByMemberIdAsync(Guid memberId);
    public Task<IResultResponse> InsertAsync(InsertAccountingRequest request, Guid memberId);
    public Task<IResultResponse> UpdateAsync(PutAccountingRequest request);
    public Task<IResultResponse> DeleteAsync(Guid accountingId);
}
