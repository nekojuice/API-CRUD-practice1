using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Entity;
using Account_book.API.Domain.Response.Get;

namespace Account_book.API.Repositories.Interfaces;

public interface IAccountingRepository
{
    public Task<IEnumerable<GetAccountingResponse>> GetAsync(Accounting? entity);
    public Task<IEnumerable<GetAccountingResponse>> GetByMemberIdAsync(Guid memberId);
    public Task<bool> InsertAsync(Accounting entity);
    public Task<bool> UpdateAsync(Accounting entity);
    public Task<bool> DeleteAsync(Guid accountingId);
}
