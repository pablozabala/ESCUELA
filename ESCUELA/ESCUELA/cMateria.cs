using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ESCUELA.Clases
{
    public class cMateria
    {
        public DataTable GetMateria()
        {
            string sql = "select * from Materia ";
            sql = sql + " order by Nombre ";
            return cDb.GetDatatable(sql);            
        }

        public string GetMaeriaxCodigo(int CodMateria)
        {
            string Materia = "";
            string sql = "select nombre from materia ";
            sql = sql + " where CodMateria =" + CodMateria.ToString();
            DataTable trdo = cDb.GetDatatable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Nombre"].ToString ()!="" )
                    Materia = trdo.Rows[0]["Nombre"].ToString(); 
            }
            return Materia;
        }
    }
}
