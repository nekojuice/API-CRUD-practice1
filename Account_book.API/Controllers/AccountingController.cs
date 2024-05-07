using Account_book.API.Domain.Request.Get;
using Account_book.API.Services.Interfaces;
using API_CRUD_practice1.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account_book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        private readonly IAccountingService _accountingService;
        public AccountingController(IAccountingService accountingService)
        {
            _accountingService = accountingService;
        }

        [HttpGet]
        public async Task<IEnumerable<Accounting>> Get([FromQuery] QueryAccountingRequest entity)
        {
            var result = await _accountingService.GetAsync(entity);
            return result;
        }
    }
}
