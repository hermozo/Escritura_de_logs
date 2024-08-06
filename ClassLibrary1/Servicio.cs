using Microsoft.Extensions.Logging;
using Serilog;

namespace Services
{
    public interface ILogica
    {
        void Ejecucion();
    }

    public class Servicio : ILogica
    {
        private readonly ILogger<Servicio> _logger;

        public Servicio(ILogger<Servicio> logger)
        {
            _logger = logger;
        }

        public void Ejecucion()
        {
            Log.Verbose("This is a verbose message xcxcx"); // Detalle muy fino
            Log.Debug("This is a debug message xcxcxc"); // Mensaje de depuración
            Log.Information("This is an informational message xcxcx"); // Mensaje informativo
            Log.Warning("This is a warning message xccccccccccc"); // Mensaje de advertencia
            Log.Error("This is an error messagecccccc xcc"); // Mensaje de error
            Log.Fatal("This is a fatal messageccccccccc xc"); // Mensaje crítico

            _logger.LogInformation("Logica.Ejecucion action LOGICA");
        }
    }
}
