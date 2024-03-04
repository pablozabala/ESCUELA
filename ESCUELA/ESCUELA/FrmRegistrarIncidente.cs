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
    public partial class FrmRegistrarIncidente : FormBase
    {
        public FrmRegistrarIncidente()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text =="")
            {
                MessageBox.Show("Debe ingresar el nombre de la incidencia");
                return;
            }

            string Nombre = txtNombre.Text;
            DateTime Fecha = dpFecha.Value;
            cIncidencia Inc = new cIncidencia();
            Inc.Insertar(Nombre, Fecha);
            MessageBox.Show("Datos guardados correctamente");
            txtNombre.Text = "";

        }
    }
}
