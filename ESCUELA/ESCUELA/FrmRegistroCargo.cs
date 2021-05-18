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
    public partial class FrmRegistroCargo : FormBase
    {
        cFunciones fun;
        public FrmRegistroCargo()
        {
            InitializeComponent();
        }

        private void FrmRegistroCargo_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            CargarMateria();
            DateTime Hoy = DateTime.Now;
            txtFechaDesde.Text = Hoy.ToShortDateString();
            Hoy = Hoy.AddMonths(1);
            txtFechaHasta.Text = Hoy.ToShortDateString();
        }

        private void CargarMateria()
        {
            cMateria mat = new Clases.cMateria();
            DataTable trdo = mat.GetMateria();
            fun.LlenarComboDatatable(cmbMateria, trdo, "Nombre", "CodMateria");
        }

        private void txt_NroDoc_TextChanged(object sender, EventArgs e)
        {
            string NroDoc = txtNroDoc.Text;
            if (NroDoc.Length > 6)
            {
                cDocente doc = new Clases.cDocente();
                DataTable trdo = doc.GetDocentexDni(NroDoc);
                if (trdo.Rows.Count > 0)
                {
                    txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                    txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                    
                }
                else
                {
                    
                    txtApellido.Text = "";
                    txtNombre.Text = "";
                    
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar ()==true)
            {

            }
        }

        public Boolean Validar()
        {
            Boolean op = false;
            if (txtNroDoc.Text =="")
            {
                Mensaje("Debe ingresar un Número de documento");
                return false;
            }

            if (txtApellido.Text  == "")
            {
                Mensaje("Debe ingresar un Apellido");
                return false;
            }

            if (txtNombre.Text  == "")
            {
                Mensaje("Debe ingresar un Nombre");
                return false;
            }

            if (cmbMateria.SelectedIndex <1)
            {
                Mensaje("Debe seleccionar una materia ");
                return false;
            }

            if (txtCurso.Text == "")
            {
                Mensaje("Debe ingresar un curso");
                return false;
            }

            if (txtDivision.Text == "")
            {
                Mensaje("Debe ingresar una división");
                return false;
            }

            if (fun.ValidarFecha (txtFechaDesde.Text)==false)
            {
                Mensaje("La fecha desde ingresada es incorrecta");
                return false;
            }

            if (fun.ValidarFecha(txtFechaHasta.Text) == false)
            {
                Mensaje("La fecha hasta ingresada es incorrecta");
                return false;
            }

            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            if (FechaDesde > FechaHasta)
            {
                Mensaje("La fecha hasta debe ser superior a la fecha desde");
                return false;
            }

            return true;
        }
    }
}
