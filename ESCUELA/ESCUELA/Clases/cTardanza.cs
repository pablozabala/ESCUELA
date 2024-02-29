using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ESCUELA.Clases
{
    public class cTardanza
    {
        public void Registrar(Int32 CodDocente, Int32? CodMotivo, DateTime Fecha)
        {
            string sql = "insert into Tardanza(";
            sql = sql + "CodMotivo,Fecha,CodDocente)";
            sql = sql + " values (";
            if (CodMotivo != null)
                sql = sql + CodMotivo.ToString();
            else
                sql = sql + "null";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + CodDocente.ToString();
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public DataTable GetTardanza(DateTime FechaDesde, DateTime FechaHasta)
        {
            string sql = "";
            sql = sql + " select (d.Apellido + ' ' + d.Nombre) as Doc ";
            sql = " ,m.Nombre , t.Fecha";
            sql = sql + " from Tardanza t ,MotivoTardanza  m , Docente d ";
            sql = sql + " where t.CodMotivo = m.CodMotivo";
            sql = sql + " and t.CodDocente=d.CodDocente ";
            sql = sql + " and t.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and t.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            return cDb.GetDatatable(sql);
        }
    }
}
