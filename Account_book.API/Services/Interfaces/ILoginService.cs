using Account_book.API.Domain.Request.Post;
using Account_book.API.Domain.Response;

namespace Account_book.API.Services.Interfaces;

public interface ILoginService
{
    public Task<IResultResponse> ValidateUser(PostLoginRequest request);
}
