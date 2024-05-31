namespace Account_book.API.Infrastructures.Cors;

public static class Cors
{
    // 參考來源
    // https://learn.microsoft.com/zh-tw/aspnet/core/security/cors?view=aspnetcore-8.0
    public static void CorsSetting(this IServiceCollection services, IHostEnvironment env)
    {
        // 使用預設
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
            });
        });

        // 使用具名規則
        //string allowOrigin = "_Account_book_html";
        //services.AddCors(options =>
        //{
        //    options.AddPolicy(
        //        name: allowOrigin,
        //        builder =>
        //        {
        //            if (env.IsDevelopment() || env.IsEnvironment("Testing"))
        //            {
        //                builder.WithOrigins(
        //                    "http://localhost:5500",
        //                    "https://localhost:5500",
        //                    "http://127.0.0.1:5500",
        //                    "https://127.0.0.1:5500",
        //                    "http://localhost:5173", // 5173 port: Vue client dev
        //                    "https://localhost:7186"
        //                    ) 
        //                        .AllowAnyHeader()
        //                        .AllowAnyMethod()
        //                        .AllowCredentials();
        //            }
        //        });
        //});
    }

}
