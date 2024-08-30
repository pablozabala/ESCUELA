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

        public void Registrar (int CodTipo , DateTime Fecha, int CodDocente, string Observacion)
        {
            string sql = "insert into Certificado ";
            sql = sql + " (CodTipo,Fecha,CodDocente,Observacion)";
            sql = sql + " values (";
            sql = sql + CodTipo.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + CodDocente.ToString();
            sql = sql + "," + "'" + Observacion + "'";
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public DataTable GetCertificadosxFecha(DateTime FechaDesde, DateTime FechaHasta, Int32? CodDocente)
        {
            string sql = "select c.CodCertificado,d.CodDocente,d.Apellido, d.Nombre  ,t.Nombre as Certificado , c.Fecha ";
            sql = sql + " from Docente d, Certificado c , tipocertificado t ";
            sql = sql + " where d.CodDocente=c.CodDocente ";
            sql = sql + " and c.CodTipo = t.CodTipo ";
            sql = sql + " and c.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and c.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";

            if (CodDocente !=null)
            {
                sql = sql + " and d.CodDocente =" + CodDocente.ToString();
            }

            sql = sql + " order by d.Apellido,d.Nombre ";

            return cDb.GetDatatable(sql);

        }

        public void Eliminar(Int32 CodCertificado)
        {
            string sql = "delete from Certificado ";
            sql = sql + " where CodCertificado=" + CodCertificado.ToString();
            cDb.Grabar(sql);
        }
    }
}
