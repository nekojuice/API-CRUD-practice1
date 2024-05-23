using Account_book.API.Domain.Entity;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Domain.Response;
using Account_book.API.Infrastructures.JWTToken;
using Account_book.API.Repositories.Interfaces;
using Account_book.API.Services.Interfaces;
using AutoMapper;

namespace Account_book.API.Services.Implements;

public class LoginService : ILoginService
{
    private readonly ILoginRepository _loginRepository;
    private readonly JwtHelpers _jwtHelpers;
    private readonly IMapper _mapper;
    public LoginService(ILoginRepository loginRepository, JwtHelpers jwtHelpers, IMapper mapper)
    {
        _loginRepository = loginRepository;
        _jwtHelpers = jwtHelpers;
        _mapper = mapper;
    }

    public async Task<IResultResponse> ValidateUser(PostLoginRequest request)
    {
        var entity = _mapper.Map<Member>(request);
        var member = await _loginRepository.ValidateUser(entity);
        if (member.MemberId !=  Guid.Empty)
        {
            var token = _jwtHelpers.GenerateToken(member.MemberId.ToString());
            return ResponseExtension.Command.SiginSuccess(token);
        }
        return ResponseExtension.Verify.LoginVerificationError();
    }
}
