using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Repositories.Interfaces;
using Account_book.API.Services.Interfaces;
using Account_book.API.Domain.Entity;

namespace Account_book.API.Services.Implements
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        { 
            _memberRepository = memberRepository;
        }

        public Task<IEnumerable<Member>> GetAsync(QueryMemberRequest condition)
        {
            var result = _memberRepository.GetAsync(condition);
            return result;
        }

        public Task<bool> InsertAsync(InsertMemberRequest entity)
        {
            var result = _memberRepository.InsertAsync(entity);
            return result;
        }

        public Task<bool> UpdateAsync(Member entity)
        {
            var result = _memberRepository.UpdateAsync(entity);
            return result;
        }

        public Task<bool> DeleteAsync(Guid memberId)
        {
            var result = _memberRepository.DeleteAsync(memberId);
            return result;
        }
    }
}
