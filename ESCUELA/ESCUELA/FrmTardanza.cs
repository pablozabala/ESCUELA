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
    public partial class FrmTardanza : FormBase
    {
        public FrmTardanza()
        {
            InitializeComponent();
        }

        private void FrmTardanza_Load(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            fun.LlenarCombo(cmbMotivo, "Motivotardanza", "Nombre", "CodMotivo");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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
                    txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                    txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodDocente.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodDocente.Text =="")
            {
                MessageBox.Show("Debe seleccionar un docente ");
                return;
            }

            if (cmbMotivo.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar un motivo de tardanza ");
                return;
            }

            Int32? CodMotivo = Convert.ToInt32(cmbMotivo.SelectedValue);
            Int32 CodDocente = Convert.ToInt32(txtCodDocente.Text);
            DateTime Fecha = dpFecha.Value;
            string Observacion = txtObservacion.Text;
            cTardanza tardanza = new cTardanza();
            tardanza.Registrar(CodDocente, CodMotivo, Fecha, Observacion);
            MessageBox.Show("Datos grabados correctamente");
            
        }
    }
}
