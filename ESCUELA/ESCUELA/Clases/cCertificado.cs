using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ESCUELA.Clases
{
    public class cCertificado
    {
        public DataTable GetCertificados()
        {
            string sql = "select * from TipoCertificado ";
            sql = sql + " order by Nombre ";
            return cDb.GetDatatable(sql);
        }

        public void Registrar (int CodTipo , DateTime Fecha, int CodDocente)
        {
            string sql = "insert into Certificado ";
            sql = sql + " (CodTipo,Fecha,CodDocente)";
            sql = sql + " values (";
            sql = sql + CodTipo.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + CodDocente.ToString();
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public DataTable GetCertificadosxFecha(DateTime FechaDesde, DateTime FechaHasta, Int32? CodDocente)
        {
            string sql = "select d.CodDocente,d.Nombre, d.Apellido ,t.Nombre as Certificado , c.Fecha ";
            sql = sql + " from Docente d, Certificado c , tipocertificado t ";
            sql = sql + " where d.CodDocente=c.CodDocente ";
            sql = sql + " and c.CodTipo = t.CodTipo ";
            sql = sql + " and c.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and c.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";

            if (CodDocente !=null)
            {
                sql = sql + " and d.CodDocente =" + CodDocente.ToString();
            }

            return cDb.GetDatatable(sql);

        }
    }
}
