using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Entity;

namespace Account_book.API.Repositories.Interfaces
{
    public interface IAccountingRepository
    {
        public Task<IEnumerable<Accounting>> GetAsync(QueryAccountingRequest entity);
    }
}
