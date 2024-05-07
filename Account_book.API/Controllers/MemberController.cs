using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Services.Interfaces;
using Account_book.API.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace Account_book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IEnumerable<Member>> GetAsync([FromQuery] QueryMemberRequest condition)
        {
            var result = await _memberService.GetAsync(condition);
            return result;
        }

        [HttpPost]
        public async Task<bool> InsetrAsync([FromBody] InsertMemberRequest entity)
        {
            var result = await _memberService.InsertAsync(entity);
            return result;
        }

        [HttpPut]
        public async Task<bool> UpdateAsync([FromBody] Member entity)
        {
            var result = await _memberService.UpdateAsync(entity);
            return result;
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync([FromBody] Guid memberId)
        {
            var result = await _memberService.DeleteAsync(memberId);
            return result;
        }
    }
}
