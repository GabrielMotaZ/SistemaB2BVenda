

using Ardalis.GuardClauses;
using Microsoft.ApplicationInsights.Extensibility;
using Serilog;

namespace SistemaVendas.Configurations;

internal static class ConfiguracaoDoSerilog
{
    public static void AddSerilog(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        Guard.Against.Null(services, nameof(services));
        Guard.Against.Null(configuration, nameof(configuration));

        var serviceProvider = services.BuildServiceProvider();
        var telemetryConfig = serviceProvider.GetRequiredService<TelemetryConfiguration>();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .WriteTo.Debug()
            .WriteTo.Console(
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
            .WriteTo.ApplicationInsights(telemetryConfig, TelemetryConverter.Traces)
            .CreateLogger();

        services.AddSingleton(Log.Logger);
    }
}
