using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Services.Interfaces;
using Account_book.API.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

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
    public async Task<IResult> GetAsync([FromQuery] QueryMemberRequest? request)
    {
        var result = await _memberService.GetAsync(request);
        return Results.Ok(result);
    }

    [HttpGet]
    public async Task<IResult> GetByMemberIdAsync([FromQuery] Guid memberId)
    {
        var result = await _memberService.GetByMemberIdAsync(memberId);
        return Results.Ok(result);
    }

    [HttpPost]
    public async Task<IResult> InsertAsync([FromBody] InsertMemberRequest request)
    {
        var result = await _memberService.InsertAsync(request);
        return Results.Ok(result);
    }

    [HttpPut]
    public async Task<IResult> UpdateAsync([FromBody] Member request)
    {
        var result = await _memberService.UpdateAsync(request);
        return Results.Ok(result);
    }

    [HttpDelete]
    public async Task<IResult> DeleteAsync([FromBody] Guid request)
    {
        var result = await _memberService.DeleteAsync(request);
        return Results.Ok(result);
    }
}
