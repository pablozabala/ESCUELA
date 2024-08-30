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
    public partial class FrmListadoDiarioFalta : FormBase 
    {
        public FrmListadoDiarioFalta()
        {
            InitializeComponent();
        }

        private void FrmListadoDiarioFalta_Load(object sender, EventArgs e)
        {
            dpFechaDesde.Value = DateTime.Now;
            dpFechaHasta.Value = DateTime.Now;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            DateTime Desde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime Hasta = Convert.ToDateTime(dpFechaHasta.Value);
            Int32? CodDocente = null;
            if (txtCodDocente.Text != "")
                CodDocente = Convert.ToInt32(txtCodDocente.Text);

            cFalta falta = new cFalta();
            DataTable trdo = falta.GetFaltasDiario(Desde, Hasta, CodDocente);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;0;18;18;14;7;7;7;7;7;7;8");
        }


        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un elemento ");
                return;
            }
            DateTime Fecha = DateTime.Now;
            DateTime FechaRegistro = Convert.ToDateTime(Grilla.CurrentRow.Cells[4].Value);
            Int32 CodFalta = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            if ( FechaRegistro.ToShortDateString() == Fecha.ToShortDateString())
            {
                cFalta falta = new cFalta();
                falta.Borrar(CodFalta);
                Mensaje("Registro borrado");
                Buscar();
            }
            else
            {
                Mensaje("no Puede borrar ");
            }

            
        }

        private void btnAbrirDocente_Click(object sender, EventArgs e)
        {
            FrmBuscarDocente frm = new ESCUELA.FrmBuscarDocente();
            frm.FormClosing += new FormClosingEventHandler(Continuar);
            frm.ShowDialog();
        }

        private void Continuar(object sender, FormClosingEventArgs e)
        {
            if (Principal.CodDocente != null)
            {
                cDocente doc = new Clases.cDocente();
                Int32 CodDOcente = Convert.ToInt32(Principal.CodDocente);
                DataTable trdo = doc.GetDoocentexCodigo(CodDOcente);
                if (trdo.Rows.Count > 0)
                {
                    txtCodDocente.Text = CodDOcente.ToString();
                    string Ape = trdo.Rows[0]["Apellido"].ToString();
                    string Nom = trdo.Rows[0]["Nombre"].ToString();
                    txtDocente.Text = (Nom + " " + Ape);
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar en elemento ");
                return;
            }

            var Resul = MessageBox.Show("Confirma Elimianr", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resul == DialogResult.Yes)
            {
                Int32 Codigo = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
                cFalta falta = new Clases.cFalta();
                falta.Borrar(Codigo);
                MessageBox.Show("Datos grabados correctamente");
                Buscar();
            }

        }
    }
}
