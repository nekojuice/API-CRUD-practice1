using System.ComponentModel.DataAnnotations;

namespace Account_book.API.Domain.Request.Post;

public class InsertAccountingRequest
{
    /// <summary>
    /// FK 類別標籤ID
    /// </summary>
    [Display(Name = "類別標籤ID")]
    [Required(ErrorMessage = "{0} 為必填")]
    public Guid TypeId { get; set; }

    /// <summary>
    /// 該筆記帳備註訊息
    /// </summary>
    [Display(Name = "備註訊息")]
    public string? Message { get; set; }

    /// <summary>
    /// 該筆記帳的消費金額
    /// </summary>
    [Display(Name = "消費金額")]
    [Required(ErrorMessage = "{0} 為必填")]
    public decimal Money { get; set; }

    /// <summary>
    /// 該筆記帳的消費時間
    /// </summary>
    [Display(Name = "消費時間")]
    [Required(ErrorMessage = "{0} 為必填")]
    public DateTime RecordTime { get; set; }
}
