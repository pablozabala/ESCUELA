using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESCUELA.Clases;
namespace ESCUELA
{
    public partial class FrmHorarioDicente : FormBase
    {
        DataTable tbHorario;
        public FrmHorarioDicente()
        {
            InitializeComponent();
        }

        private void FrmHorarioDicente_Load(object sender, EventArgs e)
        {

        }

        private void ArmarHorario()
        {
            cFunciones fun = new Clases.cFunciones();
            string col = "Hora;Nombre;Lunes;Martes;Miercoles;Jueves;Viernes";
            tbHorario = fun.CrearTabla(col);
            cRangoHorario rango = new cRangoHorario();
            DataTable tb = rango.GetRangoHorario(1);
            string Hora = "";
            string Nombre = "";
            string Val = "";
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                Hora = tb.Rows[i]["Hora"].ToString();
                Nombre = tb.Rows[i]["Nombre"].ToString();
                Val = Hora + ";" + Nombre;
                Val = Val + ";;;;;";
                tbHorario = fun.AgregarFilas(tbHorario, Val);
            }
            Grilla.DataSource = tbHorario;
            fun.AnchoColumnas(Grilla, "10;15;15;15;15;15;15");

        }

        private void GetHorarioxCodDocente(Int32 CodDocente)
        {

        }
    }
}
