using System;
using System.Windows.Forms;

namespace InterfacesBasicas
{
    internal static class EjecutorMain
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Esta forma me la hizo el programa: Crea una instancia y ejecuta la aplicacion en una linea.
            Application.Run(new PresentacionCalculadora());
            //// Crea una instancia, objeto, del formulario principal.
            //PresentacionCalculadora Calculadora = new PresentacionCalculadora();
            ////La clase Application contiene el metodo Run, el cual se encarga de correr la apliacion.
            //Application.Run(Calculadora);

        }
    }
}
