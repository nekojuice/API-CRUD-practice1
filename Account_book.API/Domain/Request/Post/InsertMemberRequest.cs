using System.ComponentModel.DataAnnotations;

namespace Account_book.API.Domain.Request.Post;

public class InsertMemberRequest
{
    /// <summary>
    /// 會員名稱
    /// </summary>
    [Display(Name = "姓名")]
    public string? Name { get; set; }

    /// <summary>
    /// 會員帳號 為電子信箱
    /// </summary>
    [Display(Name = "電子信箱(會員帳號)")]
    [Required(ErrorMessage = "{0} 為必填")]
    [EmailAddress(ErrorMessage = "電子信箱格式錯誤")]
    public string Email { get; set; }

    /// <summary>
    /// 登入用密碼
    /// </summary>
    [Display(Name = "密碼")]
    [Required(ErrorMessage = "{0} 為必填")]
    public string Password { get; set; }
}
