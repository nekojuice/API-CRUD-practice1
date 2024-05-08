namespace Account_book.API.Domain.Request.Post;

public class InsertMemberRequest
{
    /// <summary>
    /// 會員名稱
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 會員帳號 為電子信箱
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 登入用密碼
    /// </summary>
    public string Password { get; set; }
}
