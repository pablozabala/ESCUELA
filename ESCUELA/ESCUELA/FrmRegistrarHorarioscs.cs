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
    public partial class FrmRegistrarHorarioscs : FrmBase 
    {
        DataTable tbHorario;
        public FrmRegistrarHorarioscs()
        {
            InitializeComponent();
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
            for (int i = 0; i < tb.Rows.Count ; i++)
            {
                Hora = tb.Rows[i]["Hora"].ToString();
                Nombre = tb.Rows[i]["Nombre"].ToString();
                Val = Hora + ";" + Nombre;
                Val = Val + ";;;;;";
                tbHorario = fun.AgregarFilas(tbHorario, Val);
            }
            Grilla.DataSource = tbHorario;
            
            
        }

        private void FrmRegistrarHorarioscs_Load(object sender, EventArgs e)
        {
            ArmarHorario();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            string Materia = "Matematica Pablo ";
            int fila = Grilla.CurrentRow.Index;
            int col = Grilla.CurrentCell.ColumnIndex;
            Grilla.Rows[fila].Cells[col].Value = Materia;   

        }
    }
}
