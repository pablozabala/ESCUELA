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
    public partial class FrmRegistrarFaltas : FrmBase
    {
        public FrmRegistrarFaltas()
        {
            InitializeComponent();
        }

        private void FrmRegistrarFaltas_Load(object sender, EventArgs e)
        {
            LLenarCombo();
        }

        private void LLenarCombo()
        {
            string Val = "";
            cFunciones fun = new Clases.cFunciones();
            DataTable trdo = fun.CrearTabla("Codigo;Tipo");
            Val = "0;Seleccionar ";
            trdo = fun.AgregarFilas(trdo, Val);
            Val = "1;Ausente c/ Aviso ";
            trdo = fun.AgregarFilas(trdo, Val);
            Val = "2;Carpeta Médica ";
            trdo = fun.AgregarFilas(trdo, Val);
            cmbMotivo.DataSource = trdo;
            cmbMotivo.ValueMember = "Codigo";
            cmbMotivo.DisplayMember = "Tipo";
            //fun.LlenarComboDatatable(cmbMotivo, trdo, "Tippo", "Codigo");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbMotivo.SelectedIndex <1)
            {
                MessageBox.Show("Debe seleccionar un motivo");
                return;
            }
            int CodDocente = 1;
            DateTime Fecha = dpFecha.Value;
            MessageBox.Show(Fecha.ToShortDateString());
            int aa = 0, cm = 0;
            int COdMotivo = Convert.ToInt32(cmbMotivo.SelectedValue);
            switch(COdMotivo)
            {
                case 1:
                    aa = 1;
                    cm = 0;
                    break;
                case 2:
                    aa = 0;
                    cm = 1;
                    break;
            }

            cFalta falta = new cFalta();
            falta.Insertar(CodDocente, Fecha, aa, cm);
            MessageBox.Show("Datos grabados correctamente");
        }
    }
}
