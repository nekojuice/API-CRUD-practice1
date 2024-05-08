using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Repositories.Interfaces;
using Account_book.API.Services.Interfaces;
using Account_book.API.Domain.Entity;
using AutoMapper;
using System.Collections.Generic;
using Account_book.API.Domain.Response;
using static Dapper.SqlMapper;

namespace Account_book.API.Services.Implements
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<ResultResponse> GetAsync(QueryMemberRequest? request)
        {
            var entity = _mapper.Map<Member>(request);
            var result = await _memberRepository.GetAsync(entity);
            return ResponseExtension.Query.QuerySuccess(result);
        }

        public async Task<ResultResponse> GetByMemberIdAsync(Guid memberId)
        {
            var result = await _memberRepository.GetByMemberIdAsync(memberId);
            if (!result.Any()) { return ResponseExtension.Command.QueryNotFound(memberId.ToString()); }
            return ResponseExtension.Query.QuerySuccess(result);
        }

        public async Task<ResultResponse> InsertAsync(InsertMemberRequest request)
        {
            var entity = _mapper.Map<Member>(request);
            var result = await _memberRepository.InsertAsync(entity);
            if (!result) { return ResponseExtension.Command.InsertFail(); }
            return ResponseExtension.Command.InsertSuccess();
        }

        public async Task<ResultResponse> UpdateAsync(Member request)
        {
            var result = await _memberRepository.UpdateAsync(request);
            if (!result) { return ResponseExtension.Command.UpdateFail(); }
            return ResponseExtension.Command.UpdateSuccess();
        }

        public async Task<ResultResponse> DeleteAsync(Guid request)
        {
            var result = await _memberRepository.DeleteAsync(request);
            if (!result) { return ResponseExtension.Command.DeleteFail(); }
            return ResponseExtension.Command.DeleteSuccess();
        }
    }
}
