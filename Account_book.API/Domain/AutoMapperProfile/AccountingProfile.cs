using Account_book.API.Domain.Entity;
using Account_book.API.Domain.Request.Get;
using Account_book.API.Domain.Request.Post;
using Account_book.API.Domain.Request.Put;
using AutoMapper;

namespace Account_book.API.Domain.AutoMapperProfile;

public class AccountingProfile : Profile
{
    public AccountingProfile() {
        CreateMap<QueryAccountingRequest, Accounting>();
        CreateMap<InsertAccountingRequest, Accounting>();
        CreateMap<PutAccountingRequest, Accounting>();
    }
    
}
