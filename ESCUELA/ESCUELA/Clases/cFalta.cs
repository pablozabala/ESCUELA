using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ESCUELA.Clases
{
    public  class cFalta
    {
        public void Insertar (int CodDocente, DateTime Fecha, int aa, int cm, int c3, int fg, int le)
        {
            // rf registro falta siempre esta en 1
            //para sacar el contador general 
            int rf = 1;
            string sql = "insert into Falta(";
            sql = sql + "CodDocente,Fecha,aa,cm,c3,fg, le, rf";
            sql = sql + ")";
            sql = sql + " values ( " + CodDocente.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + aa.ToString();
            sql = sql + "," + cm.ToString();
            sql = sql + "," + c3.ToString();
            sql = sql + "," + fg.ToString();
            sql = sql + "," + le.ToString();
            sql = sql + "," + rf.ToString();
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public DataTable GetFaltas (DateTime FechaDesde, DateTime FechaHasta)
        {
            string sql = "";
            sql = "select d.CodDocente ,d.Nombre ,d.Apellido , sum (f.rf) as rf ";
            sql = sql + ", sum(aa) as aa, sum(cm) as cm , sum(le) as le , sum (c3) as c3 , sum(fg) as fg ";
            sql = sql + " from falta f  , docente d ";
            sql = sql + " where f.CodDocente = d.CodDocente ";
            sql = sql + " and f.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and f.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " group by d.CodDocente , d.Nombre, d.Apellido ";
            sql = sql + " order by rf desc ";
            return cDb.GetDatatable(sql);
        }
    }
}
