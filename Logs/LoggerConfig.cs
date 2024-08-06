using Microsoft.Extensions.Configuration;
using Serilog;

namespace Logs
{
    public static class LoggerConfig
    {
        private static Serilog.ILogger _logger;

        public static void ConfigureLogger(IConfiguration configuration)
        {
            _logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        public static Serilog.ILogger Logger => _logger;
    }
}
