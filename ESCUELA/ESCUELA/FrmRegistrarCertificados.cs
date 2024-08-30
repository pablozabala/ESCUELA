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
    public partial class FrmRegistrarCertificados : FormBase
    {
        public FrmRegistrarCertificados()
        {
            InitializeComponent();
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

        private void FrmRegistrarCertificados_Load(object sender, EventArgs e)
        {
            CargarCertificados8();
        }

        private void CargarCertificados8()
        {
            cCertificado cer = new cCertificado();
            DataTable trdo = cer.GetCertificados();
            cFunciones fun = new cFunciones();
            fun.LlenarComboDatatable(cmbCertificado, trdo, "nombre", "CodTipo");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodDocente.Text =="")
            {
                MessageBox.Show("Debe seleccionar un elemento");
                return;
            }

            if (cmbCertificado.SelectedIndex <1)
            {
                MessageBox.Show("Debe seleccionar un tipo de Certificado");
                return;
            }

            Int32 CodDocente = Convert.ToInt32(txtCodDocente.Text);
            DateTime Fecha = dpFecha.Value;
            Int32 CodTipo = Convert.ToInt32(cmbCertificado.SelectedValue);
            string Observacion = txtObservaciom.Text;

            cCertificado cer = new cCertificado();
            cer.Registrar(CodTipo, Fecha, CodDocente, Observacion);
            MessageBox.Show("Datos grabados correctamente"); 
        }
    }
}
