using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ESCUELA.Clases
{
    public class cHorarioDocentecs
    {
        public void Insertar(int CodDocente,int CodCurso, string Curso, string Hora )
        {
            string sql = "";
            sql = "insert into HorarioDocente(";
            sql = sql + "CodDocente,CodCurso,Curso,Hora";
            sql = sql + ")";
            sql = sql + "values (";
            sql = sql + CodDocente.ToString();
            sql = sql + "," + CodCurso.ToString();
            sql = sql + "," + "'" + Curso + "'";
            sql = sql + "," + "'" + Hora + "'";
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public void Modificar(int CodDocente, int CodCurso, string Curso, string Hora)
        {
            string sql = "";
            sql = "update HorarioDocente set";
            sql = sql + " Curso=" + "'" + Curso + "'";
            sql = sql + " where Hora =" + "'" + Hora + "'";
            sql = sql + " and CodDocente =" + CodDocente.ToString();
            cDb.Grabar(sql);
        }

        public DataTable GetHorarioxCodDocente(int CodDocente,string Hora)
        {
            string sql = "select * ";
            sql = sql + " from HorarioDocente ";
            sql = sql + " where CodDocente=" + CodDocente.ToString();
            sql = sql + " and Hora =" + "'" + Hora + "'";
            return cDb.GetDatatable(sql);
        }

        
    }
}
