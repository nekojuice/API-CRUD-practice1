using Account_book.API.Domain.Request.Get;
using Account_book.API.Repositories.Interfaces;
using Account_book.API.Services.Interfaces;
using API_CRUD_practice1.Domain.Entity;

namespace Account_book.API.Services.Implements
{
    public class AccountingService : IAccountingService
    {
        private readonly IAccountingRepository _accountingRepository;
        public AccountingService(IAccountingRepository accountingRepository)
        {
            _accountingRepository = accountingRepository;
        }

        public async Task<IEnumerable<Accounting>> GetAsync(QueryAccountingRequest entity)
        {
            var result = await _accountingRepository.GetAsync(entity);
            return result;
        }
    }
}
