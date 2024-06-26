﻿namespace Account_book.API.Domain.Request.Put;

public class PutAccountingRequest
{
    /// <summary>
    /// PK
    /// </summary>
    public Guid AccountingId { get; set; }

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
