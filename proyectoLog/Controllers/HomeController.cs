using Logs;
using Microsoft.AspNetCore.Mvc;
using proyectoLog.Models;
using Serilog;
using Services;
using System.Diagnostics;

namespace proyectoLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogica _logica;

        public HomeController(ILogger<HomeController> logger, ILogica logica)
        {
            _logger = logger;
            _logica = logica;
        }

        public IActionResult Index()
        {
            _logica.Ejecucion();
            _logica.Ejecucion();
            _logica.Ejecucion();
            Log.Verbose("This is a verbose message"); // Detalle muy fino
            Log.Debug("This is a debug message"); // Mensaje de depuración
            Log.Information("This is an informational message"); // Mensaje informativo
            Log.Warning("This is a warning message"); // Mensaje de advertencia
            Log.Error("This is an error message"); // Mensaje de error
            Log.Fatal("This is a fatal message"); // Mensaje crítico
            _logger.LogInformation("HomeController.Index action INFO");
            _logger.LogError("HomeController.Index action ERROR");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
