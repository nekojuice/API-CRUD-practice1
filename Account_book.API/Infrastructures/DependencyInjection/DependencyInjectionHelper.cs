using Account_book.API.Infrastructures.Database;
using Account_book.API.Repositories.Implements;
using Account_book.API.Repositories.Interfaces;
using Account_book.API.Services.Implements;
using Account_book.API.Services.Interfaces;

namespace Account_book.API.Infrastructures.DependencyInjection;

public static class DependencyInjectionHelper
{
    public static void CustomDIConfigurator(this IServiceCollection services)
    {
        //DBConnection
        services.AddScoped<DatabaseConnectionHelper>();


        //Service
        services.AddScoped<IAccountingService, AccountingService>();
        services.AddScoped<IMemberService, MemberService>();
        //Repository
        services.AddScoped<IAccountingRepository, AccountingRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
    }
}
