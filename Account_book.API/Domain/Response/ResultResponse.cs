using Account_book.API.Domain.Enum;

namespace Account_book.API.Domain.Response
{
    public record ResultResponse(ReturnCodeEnum ReturnCode = ReturnCodeEnum.Success, string ReturnMessage = "", object ReturnData = null);
}
