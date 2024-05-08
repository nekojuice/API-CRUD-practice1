using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Services.Interfaces;
using Account_book.API.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;
using Account_book.API.Domain.Request.Put;

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

    [HttpGet]
    public async Task<IResult> GetMemberAsync([FromQuery] QueryMemberRequest? request)
    {
        var result = await _memberService.GetAsync(request);
        return Results.Ok(result);
    }

    [HttpGet]
    [Route("{memberId}")]
    public async Task<IResult> GetMemberByMemberIdAsync([FromRoute] Guid memberId)
    {
        var result = await _memberService.GetByMemberIdAsync(memberId);
        return Results.Ok(result);
    }

    [HttpPost]
    public async Task<IResult> InsertMemberAsync([FromBody] InsertMemberRequest request)
    {
        var result = await _memberService.InsertAsync(request);
        return Results.Ok(result);
    }

    [HttpPut]
    public async Task<IResult> UpdateMemberAsync([FromBody] PutMemberRequest request)
    {
        var result = await _memberService.UpdateAsync(request);
        return Results.Ok(result);
    }

    [HttpDelete]
    [Route("{memberId}")]
    public async Task<IResult> DeleteMemberAsync([FromRoute] Guid memberId)
    {
        var result = await _memberService.DeleteAsync(memberId);
        return Results.Ok(result);
    }
}
