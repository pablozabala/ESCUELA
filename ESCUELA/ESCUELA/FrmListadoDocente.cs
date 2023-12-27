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
    public partial class FrmListadoDocente : FrmBase
    {
        public FrmListadoDocente()
        {
            InitializeComponent();
        }

        private void FrmListadoDocente_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            cDocente doc = new cDocente();
            string Apellido = "", Nombre = "";
            Apellido = txtApellido.Text;
            DataTable trdo = doc.GetDocentes(Apellido, Nombre);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;50;50");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void BTNaCEPTAR_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un elemento ");
                return;
            }
            Int32 CodDocente = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.CodDocente = CodDocente; 
        }
    }
}
