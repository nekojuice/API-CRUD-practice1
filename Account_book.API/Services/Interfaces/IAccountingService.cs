using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Entity;

namespace Account_book.API.Services.Interfaces
{
    public interface IAccountingService
    {
        public Task<IEnumerable<Accounting>> GetAsync(QueryAccountingRequest entity);
    }
}
