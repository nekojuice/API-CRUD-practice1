using Serilog.Events;
using Serilog;
using Serilog.Formatting.Compact;

namespace Account_book.API.Infrastructures.Logging;

public static class SerilLogHelper
{
    public static void ConfigureSerilLogger(IConfiguration configuration)
    {
        // 全域設定
        /*  🔔new CompactJsonFormatter()
         *  由於 Log 的欄位很多，使用 Console Sink 會比較看不出來，改用 Serilog.Formatting.Compact 來記錄 JSON 格式的 Log 訊息會清楚很多！
         */
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information() // 設定最小Log輸出
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning) // 設定 Microsoft.AspNetCore 訊息為 Warning 為最小輸出
            .Enrich.FromLogContext()  // 可以增加Log輸出欄位 https://www.cnblogs.com/wd4j/p/15043489.html
            .WriteTo.Console(new CompactJsonFormatter()) // 寫入Console
            .WriteTo.Map(   // 寫入txt => 按照 level
            evt => evt.Level,
            (level, wt) => wt.File(
                new CompactJsonFormatter(),
                path: String.Format(configuration.GetValue<string>("Path:SerilLogSavePath"), level),
                restrictedToMinimumLevel: LogEventLevel.Information,
                rollOnFileSizeLimit: true,
                rollingInterval: RollingInterval.Day))
             .CreateLogger();
    }

    // 參考來源
    // https://stackoverflow.com/questions/60076922/serilog-logging-web-api-methods-adding-context-properties-inside-middleware

    public static string RequestPayload = "";

    public static async void EnrichFromRequest(IDiagnosticContext diagnosticContext, HttpContext httpContext)
    {
        var request = httpContext.Request;

        diagnosticContext.Set("RequestBody", RequestPayload);

        string responseBodyPayload = await ReadResponseBody(httpContext.Response);
        diagnosticContext.Set("ResponseBody", responseBodyPayload);

        // Set all the common properties available for every request
        diagnosticContext.Set("Host", request.Host);
        diagnosticContext.Set("Protocol", request.Protocol);
        diagnosticContext.Set("Scheme", request.Scheme);

        // Only set it if available. You're not sending sensitive data in a querystring right?!
        if (request.QueryString.HasValue)
        {
            diagnosticContext.Set("QueryString", request.QueryString.Value);
        }

        // Set the content-type of the Response at this point
        diagnosticContext.Set("ContentType", httpContext.Response.ContentType);

        // Retrieve the IEndpointFeature selected for the request
        var endpoint = httpContext.GetEndpoint();
        if (endpoint is object) // endpoint != null
        {
            diagnosticContext.Set("EndpointName", endpoint.DisplayName);
        }
    }

    private static async Task<string> ReadResponseBody(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        string responseBody = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);

        return $"{responseBody}";
    }
}
