using Account_book.API.Domain.Request.Get;
using API_CRUD_practice1.Domain.Entity;

namespace Account_book.API.Services.Interfaces
{
    public interface IAccountingService
    {
        public Task<IEnumerable<Accounting>> GetAsync(QueryAccountingRequest entity);
    }
}
