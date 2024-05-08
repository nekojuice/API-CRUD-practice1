namespace Account_book.API.Domain.Request.Get
{
    public class QueryMemberRequest
    {
        /// <summary>
        /// PK 會員編號
        /// </summary>
        public Guid? memberId { get; set; }

        /// <summary>
        /// 會員名稱
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// 會員帳號 為電子信箱
        /// </summary>
        public string? email { get; set; }
    }
}
