﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESCUELA
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {       
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             //   Application.Run(new FrmBuscarDocente());
                 Application.Run(new Principal());
           //   Application.Run(new FrmConsultarCertificados() );
        }
    }
}
