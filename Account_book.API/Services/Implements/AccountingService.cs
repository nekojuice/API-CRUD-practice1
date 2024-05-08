using Account_book.API.Domain.Request.Get;
using Account_book.API.Repositories.Interfaces;
using Account_book.API.Services.Interfaces;
using Account_book.API.Domain.Entity;

namespace Account_book.API.Services.Implements
{
    public class AccountingService : IAccountingService
    {
        private readonly IAccountingRepository _accountingRepository;
        public AccountingService(IAccountingRepository accountingRepository)
        {
            _accountingRepository = accountingRepository;
        }

        public async Task<IEnumerable<Accounting>> GetByMemberIdAsync(Guid memberId)
        {
            var result = await _accountingRepository.GetByMemberIdAsync(memberId);
            return result;
        }
    }
}
