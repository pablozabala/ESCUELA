using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ESCUELA.Clases
{
    public class cIncidencia
    {
        public void Insertar(string Nombre, DateTime Fecha)
        {
            string sql = "insert into Incidencia(Nombre,Fecha)";
            sql = sql + " values (";
            sql = sql + "'" + Nombre + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public DataTable GetIncidencia(DateTime FechaDesde, DateTime FechaHasta)
        {
            string sql = "";  
            sql = "select Nombre, Fecha ";
            sql = sql + " from Incidencia ";
            sql = sql + " where Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            return cDb.GetDatatable(sql);

        }

    }
}
