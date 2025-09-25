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
        public void Insertar(int CodDocente,int CodCurso, string Curso, string Hora, int CodTurno, int Dia)
        {
            string sql = "";
            sql = "insert into HorarioDocente(";
            sql = sql + "CodDocente,CodCurso,Curso,Hora,CodTurno, Dia ";
            sql = sql + ")";
            sql = sql + "values (";
            sql = sql + CodDocente.ToString();
            sql = sql + "," + CodCurso.ToString();
            sql = sql + "," + "'" + Curso + "'";
            sql = sql + "," + "'" + Hora + "'";
            sql = sql + "," + CodTurno.ToString();
            sql = sql + "," + Dia.ToString();
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public void Modificar(int CodDocente, int CodCurso, string Curso, string Hora, int Dia)
        {
            string sql = "";
            sql = "update HorarioDocente set";
            sql = sql + " Curso=" + "'" + Curso + "'";
            sql = sql + ", Dia =" + Dia.ToString();
            sql = sql + " where Hora =" + "'" + Hora + "'";
            sql = sql + " and CodDocente =" + CodDocente.ToString();
            sql = sql + " and CodCurso =" + CodCurso.ToString();
            cDb.Grabar(sql);
        }

        public DataTable GetHorarioxCodDocente(int CodDocente,string Hora, int CodCurso, int Dia)
        {
            string sql = "select * ";
            sql = sql + " from HorarioDocente ";
            sql = sql + " where CodDocente=" + CodDocente.ToString();
            sql = sql + " and Hora =" + "'" + Hora + "'";
            sql = sql + " and CodCurso =" + CodCurso.ToString();
            sql = sql + " and Dia =" + Dia.ToString();
            return cDb.GetDatatable(sql);
        }

        public DataTable GetHorarioxCodDocente(Int32 CodDocente, Int32 CodTurno)
        {
            string sql = "";
            sql = "select * from horariodocente ";
            sql = sql + " where CodDocente=" + CodDocente.ToString();
            sql = sql + " and CodTurno =" + CodTurno.ToString();
            return cDb.GetDatatable(sql);
        }

        
    }
}
