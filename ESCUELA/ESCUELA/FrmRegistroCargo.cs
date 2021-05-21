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
using System.Data.SqlClient;
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
            fun.LlenarCombo(cmbCaracter, "Caracter", "Nombre", "CodCaracter");
        }

        private void txt_NroDoc_TextChanged(object sender, EventArgs e)
        {
            string NroDoc = txtNroDoc.Text;
            if (NroDoc.Length > 4)
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
            if (Validar ()==false)
            {
                return;
            }

            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
          
            try
            {
                GrabarDocente(con, tran);
                GrabarDocenteSuplente(con, tran);
                GrabarCargo(con, tran);
                tran.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");
            }
            catch (Exception)
            {
                tran.Rollback();
                con.Close();
                Mensaje("Hubo un erroren el proceso de grabación");
            }
        }

        public Int32  GrabarDocente(SqlConnection con,SqlTransaction tran)
        {
            string Apellido = txtApellido.Text;
            string NroDoc = txtNroDoc.Text;
            string Nombre = txtNombre.Text;
            string Email = txtMail.Text;
            string Celular = txtTelefono.Text;
            Int32 CodDocente = 0;
            cDocente doc = new cDocente();
            if (txtCodDocente.Text =="")
            {
                CodDocente = doc.GrabarDocenteTransaccion(con, tran, NroDoc, Apellido, Nombre, Email, Celular);
                txtCodDocente.Text = CodDocente.ToString();
            }
            return CodDocente;
        }

        public Int32 GrabarDocenteSuplente(SqlConnection con, SqlTransaction tran)
        {
            string Apellido = txtApellidoSuplente.Text;
            string NroDoc = txtNroDocSuplente.Text;
            string Nombre = txtNombreSuplente.Text;
            string Email = txtMailSuplente.Text;
            string Celular = txtTelefonoSuplente.Text;
            Int32 CodDocente = 0;
            cDocente doc = new cDocente();
            if (txtCodDocenteSuplente.Text == "")
            {  
                CodDocente = doc.GrabarDocenteTransaccion(con, tran, NroDoc, Apellido, Nombre, Email, Celular);
                txtCodDocenteSuplente.Text = CodDocente.ToString();
            }
            return CodDocente;
        }

        public void GrabarCargo(SqlConnection con, SqlTransaction tran)
        {
            Int32 CodDocente = 0;
            Int32 CodMateria = 0;
            string Curso = "";
            string Division = "";
            Int32 CodCaracter = 0;
            DateTime FechaDesde = DateTime.Now;
            DateTime FechaHasta = DateTime.Now;
            Int32 CodDocenteSuplente = 0;

            CodDocente = Convert.ToInt32(txtCodDocente.Text);
            CodMateria = Convert.ToInt32(cmbMateria.SelectedValue);
            Curso = txtCurso.Text;
            Division = txtDivision.Text;
            CodCaracter = Convert.ToInt32(cmbCaracter.SelectedValue);
            FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            CodDocenteSuplente = Convert.ToInt32(txtCodDocenteSuplente.Text);

            cCargo cargo = new cCargo();
            cargo.InsertarCargo(con, tran, CodDocente, CodMateria, Curso, Division,
                CodCaracter, FechaDesde, FechaHasta, CodDocenteSuplente);
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

            if (cmbCaracter.SelectedIndex  < 1)
            {
                Mensaje("Debe seleccionar una caracter ");
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

        private void btnAgregarMateria_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodMateria";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Materia";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Principal.CampoIdSecundarioGenerado != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                switch (Principal.NombreTablaSecundario)
                {

                    case "Materia":
                        CargarMateria();
                        cmbMateria.SelectedValue   = Principal.CampoIdSecundarioGenerado;
                        break;                    
                }
            }
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtNroDoc_TextChanged(object sender, EventArgs e)
        {
            string NroDoc = txtNroDoc.Text;
            if (NroDoc.Length > 4)
            {
                cDocente doc = new Clases.cDocente();
                DataTable trdo = doc.GetDocentexDni(NroDoc);
                if (trdo.Rows.Count > 0)
                {
                    txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                    txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                    txtTelefono.Text = trdo.Rows[0]["Celular"].ToString();
                    txtMail.Text = trdo.Rows[0]["Email"].ToString();
                }
                else
                {
                    txtMail.Text = "";
                    txtTelefono.Text = "";
                    txtApellido.Text = "";
                    txtNombre.Text = "";

                }
            }
        }

        private void txtNroDocSuplente_TextChanged(object sender, EventArgs e)
        { 
            string NroDoc = txtNroDocSuplente.Text;
            if (NroDoc.Length > 4)
            {        
                cDocente doc = new Clases.cDocente();
                DataTable trdo = doc.GetDocentexDni(NroDoc);
                if (trdo.Rows.Count > 0)
                {    
                    txtApellidoSuplente.Text = trdo.Rows[0]["Apellido"].ToString();
                    txtNombreSuplente.Text = trdo.Rows[0]["Nombre"].ToString();
                    txtTelefonoSuplente.Text = trdo.Rows[0]["Celular"].ToString();
                    txtMailSuplente.Text = trdo.Rows[0]["Email"].ToString();
                }
                else
                {
                    txtTelefonoSuplente.Text = "";
                    txtMailSuplente.Text = "";
                    txtApellidoSuplente.Text = "";
                    txtApellidoSuplente.Text = "";

                }
            }
        }
    }
}
