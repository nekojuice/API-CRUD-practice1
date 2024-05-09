using Account_book.API.Domain.Request.Get;
using Account_book.API.Services.Interfaces;
using Account_book.API.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Services.Implements;
using Account_book.API.Domain.Request.Put;
using Account_book.API.Domain.Response;

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

    /// <summary>
    /// 多筆查詢 記帳記錄Accounting
    /// </summary>
    /// <param name="request">查詢條件</param>
    /// <returns>記帳記錄Accounting 陣列</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse<QueryAccountingRequest>))]
    public async Task<IResult> GetAccountingAsync([FromQuery] QueryAccountingRequest? request)
    {
        var result = await _accountingService.GetAsync(request);
        return Results.Ok(result);
    }

    /// <summary>
    /// 多筆查詢 特定用戶 記帳記錄Accounting
    /// </summary>
    /// <param name="memberId">會員Id</param>
    /// <returns>記帳記錄Accounting 陣列</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse<QueryAccountingRequest>))]
    [Route("{memberId}")]
    public async Task<IResult> GetAccountingByMemberIdAsync([FromRoute] Guid memberId)
    {
        var result = await _accountingService.GetByMemberIdAsync(memberId);
        return Results.Ok(result);
    }

    /// <summary>
    /// 新增 記帳記錄Accounting
    /// </summary>
    /// <param name="request">記帳記錄資料</param>
    /// <returns>是否成功</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> InsertAccountingByMemberIdAsync([FromBody] InsertAccountingRequest request)
    {
        var result = await _accountingService.InsertAsync(request);
        return Results.Ok(result);
    }

    /// <summary>
    /// 修改 記帳記錄Accounting
    /// </summary>
    /// <param name="request">記帳記錄資料</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> UpdateAccountingAsync([FromBody] PutAccountingRequest request)
    {
        var result = await _accountingService.UpdateAsync(request); 
        return Results.Ok(result);
    }

    /// <summary>
    /// 刪除 記帳記錄Accounting
    /// </summary>
    /// <param name="accountingId">記帳記錄Id</param>
    /// <returns>是否成功</returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    [Route("{accountingId}")]
    public async Task<IResult> DeleteAccountingAsync([FromRoute] Guid accountingId)
    {
        var result = await _accountingService.DeleteAsync(accountingId);
        return Results.Ok(result);
    }
}
