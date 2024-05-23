using Account_book.API.Domain.Request.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account_book.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> PostAsync([FromBody]PostLoginRequest request) 
        {
            return Results.Ok(request);
        }
    }
}
