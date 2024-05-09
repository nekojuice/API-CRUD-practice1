using Account_book.API.Domain.Enum;

namespace Account_book.API.Domain.Response;

public interface IResultResponse;

public record ResultResponse(ReturnCodeEnum ReturnCode = ReturnCodeEnum.Success, string ReturnMessage = "", object? ReturnData = null) : IResultResponse;
public record ResultResponse<T>(ReturnCodeEnum ReturnCode = ReturnCodeEnum.Success, string ReturnMessage = "", T? ReturnData = default) : IResultResponse;

