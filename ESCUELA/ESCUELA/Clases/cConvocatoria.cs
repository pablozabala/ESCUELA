﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ESCUELA.Clases
{
    public class cConvocatoria
    {
        public DataTable GetConvocatoriasVigentes()
        {
            string sql = "select * from convocatoria where FechaFin is null";
            return cDb.GetDatatable(sql);
        }

        public void grabarConvocatoriaxDocente(int IdConvocatoria,string Docente,string dni)
        {
            string sql = "insert into ConvocatoriaxDocente(IdConvocatoria,Docente,Dni)";
            sql = sql + " values(" + IdConvocatoria.ToString();
            sql = sql + "," + "'" + Docente +"'";
            sql = sql + "," + "'" + dni  + "'";
            sql = sql + ")  ";
            cDb.Grabar(sql);
        }

        public void BorrarDocentexConvocatoria(int IdConvocatoria,string dni)
        {
            string sql = "delete from ConvocatoriaxDocente ";
            sql = sql + " where IdConvocatoria=" + IdConvocatoria.ToString();
            sql = sql + " and Dni=" + "'" + dni + "'";
            cDb.Grabar(sql);
        }


        public DataTable GetConvocatoriaDocentexId(Int32 Convocatoria)
        {
            string sql = "select * from ConvocatoriaxDocente ";
            sql = sql + " where IdConvocatoria=" + Convocatoria.ToString();
            return cDb.GetDatatable(sql);
        }

        public DataTable GetConvocatoriaDocentexIdOrdenadaPuntaje(Int32 Convocatoria)
        {
            string sql = "select * from ConvocatoriaxDocente ";
            sql = sql + " where IdConvocatoria=" + Convocatoria.ToString();
            sql = sql + " order by Categoria asc ";
            return cDb.GetDatatable(sql);
        }

        public void CargarPuntaje(Double Puntaje,int Categoria,string dni,Int32 IdConvocatoria,string PuntajeLetra)
        {
            string sql = "";
            sql = "update ConvocatoriaxDocente";
            sql = sql + " set Puntaje=" + Puntaje.ToString().Replace(",", ".");
            sql = sql + ", Categoria=" + Categoria.ToString();
            sql = sql + ",PuntajeLetra=" + "'" + PuntajeLetra + "'";
            sql = sql + " where Dni=" + "'" + dni + "'";
            sql = sql + " and IdConvocatoria=" + IdConvocatoria.ToString();
            cDb.Grabar(sql);
        }

        public void FinaliarConvocatoria(Int32 IdConvocatoria)
        {
            string sql = "";
            sql = "update convocatoria set FechaFin=" + "'" + DateTime.Now.ToShortDateString() + "'";
            sql = sql + " where IdConvocatoria=" + IdConvocatoria.ToString();
            cDb.Grabar(sql);
        }
    }
}
