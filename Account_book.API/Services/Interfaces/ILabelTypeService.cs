using Account_book.API.Domain.Response;

namespace Account_book.API.Services.Interfaces
{
    public interface ILabelTypeService
    {
        public Task<IResultResponse> GetAll();
    }
}
