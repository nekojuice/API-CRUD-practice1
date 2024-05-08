using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Entity;

namespace Account_book.API.Repositories.Interfaces;

public interface IAccountingRepository
{
    public Task<IEnumerable<Accounting>> GetAsync(Accounting? entity);
    public Task<IEnumerable<Accounting>> GetByMemberIdAsync(Guid memberId);
    public Task<bool> InsertAsync(Accounting entity);
    public Task<bool> UpdateAsync(Accounting entity);
    public Task<bool> DeleteAsync(Guid accountingId);
}
