using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCUELA.Clases
{
    public static class cConexion
    {
        public static string GetConexion()
        {  //cadena
           // string cadena = "Data Source=SECRETARIA-2\\SQLEXPRESS;Initial Catalog=ESCUELA;Integrated Security=True";
            // HOME
              string cadena = "Data Source=SECRETARIA-2\\SQLEXPRESS;Initial Catalog=ESCUELA;User ID=sa;Password=123";
           //SERVIDOR
           //  string cadena = "Data Source=SERVIDOR-PC;Initial Catalog=ESCUELA;User ID=sa;Password=123";
            return cadena;
        }
    }
}
