using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ESCUELA.Clases
{
    public class cRangoHorario
    {
        public DataTable GetRangoHorario(int CodTURNO)
        {
            String sql = "select * from RangoHorario ";
            sql = sql + " where CodTurno =" + CodTURNO.ToString();
            return cDb.GetDatatable(sql);
        }
    }
}
