namespace Account_book.API.Domain.Request.Get
{
    public class QueryAccountingRequest
    {
        /// <summary>
        /// PK
        /// </summary>
        public Guid AccountingId { get; set; }

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
        public string? Message { get; set; }

        /// <summary>
        /// 該筆記帳的消費金額
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 該筆記帳的消費時間
        /// </summary>
        public DateTime RecordTime { get; set; }

        /// <summary>
        /// 資料生成時的時間戳記
        /// </summary>
        public DateTime? Timestamp { get; set; }
    }
}
