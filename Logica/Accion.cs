using Serilog;

namespace Logica
{
    public class Accion
    {
        public string Index() {
            Log.Error("Aqui esta el log en la clase accion");
            return "OK";
        }
    }
}
