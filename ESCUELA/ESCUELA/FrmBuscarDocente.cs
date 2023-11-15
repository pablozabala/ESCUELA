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
    public partial class FrmBuscarDocente : FrmBase
    {
        public FrmBuscarDocente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string Apellido = txtApellido.Text;
            string Nombre = txtNombre.Text;
            cDocente doc = new Clases.cDocente();
            DataTable trdo = doc.GetDocente(Apellido, Nombre);
            cFunciones fun = new Clases.cFunciones();
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;50;50");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("debe seleccionar un elelemtno");
                return;
            }
            int CodDocente = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.CodDocente = CodDocente;
            this.Close();
        }
    }
}
