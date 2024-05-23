using Account_book.API.Domain.Entity;
using Account_book.API.Domain.Request.Post;

namespace Account_book.API.Repositories.Interfaces;

public interface ILoginRepository
{
    public Task<bool> ValidateUser(Member entity);
}
