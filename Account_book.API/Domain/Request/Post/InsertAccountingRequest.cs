namespace Account_book.API.Domain.Request.Post;

public class InsertAccountingRequest
{
    /// <summary>
    /// FK 會員ID
    /// </summary>
    public Guid MemberId { get; set; }
    /// <summary>
    /// FK 類別標籤ID
    /// </summary>
    public Guid TypeId { get; set; }

    /// <summary>
    /// 該筆記帳備註訊息
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// 該筆記帳的消費金額
    /// </summary>
    public decimal Money { get; set; }

    /// <summary>
    /// 該筆記帳的消費時間
    /// </summary>
    public DateTime RecordTime { get; set; }
}
