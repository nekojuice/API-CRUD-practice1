using Account_book.API.Domain.Request.Get;
using Account_book.API.Services.Interfaces;
using Account_book.API.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Services.Implements;
using Account_book.API.Domain.Request.Put;

namespace Account_book.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountingController : ControllerBase
{
    private readonly IAccountingService _accountingService;
    public AccountingController(IAccountingService accountingService)
    {
        _accountingService = accountingService;
    }

    [HttpGet]
    public async Task<IResult> GetAccountingAsync([FromQuery] QueryAccountingRequest? request)
    {
        var result = await _accountingService.GetAsync(request);
        return Results.Ok(result);
    }

    [HttpGet]
    [Route("{memberId}")]
    public async Task<IResult> GetAccountingByMemberIdAsync([FromRoute] Guid memberId)
    {
        var result = await _accountingService.GetByMemberIdAsync(memberId);
        return Results.Ok(result);
    }

    [HttpPost]
    public async Task<IResult> InsertAccountingByMemberIdAsync([FromBody] InsertAccountingRequest request)
    {
        var result = await _accountingService.InsertAsync(request);
        return Results.Ok(result);
    }

    [HttpPut]
    public async Task<IResult> UpdateAccountingAsync([FromBody] PutAccountingRequest request)
    {
        var result = await _accountingService.UpdateAsync(request); 
        return Results.Ok(result);
    }

    [HttpDelete]
    [Route("{accountingId}")]
    public async Task<IResult> DeleteAccountingAsync([FromRoute] Guid accountingId)
    {
        var result = await _accountingService.DeleteAsync(accountingId);
        return Results.Ok(result);
    }
}
