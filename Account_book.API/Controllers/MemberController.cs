using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Services.Interfaces;
using Account_book.API.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;
using Account_book.API.Domain.Request.Put;
using Account_book.API.Domain.Response;

namespace Account_book.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly IMemberService _memberService;
    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    /// <summary>
    /// 多筆查詢 會員Member
    /// </summary>
    /// <param name="request">可接受查詢的 會員Member 欄位</param>
    /// <returns>會員Member 陣列</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> GetMemberAsync([FromQuery] QueryMemberRequest? request)
    {
        var result = await _memberService.GetAsync(request);
        return Results.Ok(result);
    }

    /// <summary>
    /// 單筆查詢 會員Member
    /// </summary>
    /// <param name="memberId">會員Id</param>
    /// <returns>會員Member 單筆</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    [Route("{memberId}")]
    public async Task<IResult> GetMemberByMemberIdAsync([FromRoute] Guid memberId)
    {
        var result = await _memberService.GetByMemberIdAsync(memberId);
        return Results.Ok(result);
    }

    /// <summary>
    /// 新增 會員Member
    /// </summary>
    /// <param name="request">會員資料</param>
    /// <returns>是否成功</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> InsertMemberAsync([FromBody] InsertMemberRequest request)
    {
        var result = await _memberService.InsertAsync(request);
        return Results.Ok(result);
    }

    /// <summary>
    /// 修改 會員Member
    /// </summary>
    /// <param name="request">會員資料</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> UpdateMemberAsync([FromBody] PutMemberRequest request)
    {
        var result = await _memberService.UpdateAsync(request);
        return Results.Ok(result);
    }

    /// <summary>
    /// 刪除 會員Member
    /// </summary>
    /// <param name="memberId">會員Id</param>
    /// <returns>是否成功</returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    [Route("{memberId}")]
    public async Task<IResult> DeleteMemberAsync([FromRoute] Guid memberId)
    {
        var result = await _memberService.DeleteAsync(memberId);
        return Results.Ok(result);
    }
}
