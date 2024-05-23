using Account_book.API.Domain.Request.Post;
using Account_book.API.Infrastructures.JWTToken;
using Account_book.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account_book.API.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly JwtHelpers _jwtHelpers;
    private readonly ILoginService _loginService;

    public LoginController(JwtHelpers jwtHelpers, ILoginService loginService)
    {
        _jwtHelpers = jwtHelpers;
        _loginService = loginService;
    }

    [HttpPost]
    public async Task<IResult> PostAsync([FromBody] PostLoginRequest request)
    {
        var result = await _loginService.ValidateUser(request);
        return Results.Ok(result);
    }
}
