using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCUELA.Clases
{
    public  class cFalta
    {
        public void Insertar (int CodDocente, DateTime Fecha, int aa, int cm)
        {
            string sql = "insert into Falta(";
            sql = sql + "CodDocente,Fecha,aa,cm";
            sql = sql + ")";
            sql = sql + " values ( " + CodDocente.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + aa.ToString();
            sql = sql + "," + cm.ToString();
            sql = sql + ")";
            cDb.Grabar(sql);
        }
    }
}
