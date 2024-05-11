namespace Account_book.API.Infrastructures.Cors;

public static class Cors
{
    // 參考來源
    // https://learn.microsoft.com/zh-tw/aspnet/core/security/cors?view=aspnetcore-8.0
    public static void CorsSetting(this IServiceCollection services, IHostEnvironment env)
    {
        string AllowOrigin = "_Account_book_html";

        services.AddCors(options =>
        {
            // .AddDefaultPolicy(...) 使用預設
            options.AddPolicy(
                name: AllowOrigin,
                builder =>
                {
                    if (env.IsDevelopment() || env.IsEnvironment("Testing"))
                    {
                        //builder.WithOrigins(
                        //    "http://localhost:5500",
                        //    "https://localhost:5500",
                        //    "http://127.0.0.1:5500")
                        //        .AllowAnyHeader()
                        //        .AllowAnyMethod()
                        //        .AllowCredentials();

                        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                    }
                });
        });
    }

}
