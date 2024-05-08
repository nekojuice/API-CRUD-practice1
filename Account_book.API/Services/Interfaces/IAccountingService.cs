using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Entity;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Domain.Request.Put;
using Account_book.API.Domain.Response;

namespace Account_book.API.Services.Interfaces;

public interface IAccountingService
{
    public Task<ResultResponse> GetAsync(QueryAccountingRequest? request);
    public Task<ResultResponse> GetByMemberIdAsync(Guid memberId);
    public Task<ResultResponse> InsertAsync(InsertAccountingRequest request);
    public Task<ResultResponse> UpdateAsync(PutAccountingRequest request);
    public Task<ResultResponse> DeleteAsync(Guid accountingId);
}
