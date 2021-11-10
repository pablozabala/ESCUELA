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
    public partial class FrmAbmDocente : FormBase
    {
        cFunciones fun;
        public FrmAbmDocente()
        {
            InitializeComponent();
        }

        private void FrmAbmDocente_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            Botonera(1);
            Grupo.Enabled = false;
        }

        private void Botonera(int Jugada)
        {
            switch (Jugada)
            {
                //estado inicial
                case 1:
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
                case 2:
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;
                    break;
                case 3:
                    //viene del buscador
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
            }


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txt_NroDoc.Text  == "")
            {
                Mensaje("Debe ingresar un número de documento");
                return;
            }
            if (txt_Apellido.Text == "")
            {
                Mensaje("Debe ingresar un apellido");
                return;
            }
              
            if (txt_Nombre.Text == "")
            {
                Mensaje("Debe ingresar un nombre");
                return;
            }

            if (txtCodDocente.Text == "")
                fun.GuardarNuevoGenerico(this, "Docente");
            else
            {
                // if (txt_Ruta.Text != "")
                //   txt_Ruta.Text = txt_Ruta.Text.Replace("\\", "\\\\");
                fun.ModificarGenerico(this, "Docente", "CodDocente", txtCodDocente.Text);

            }
            Mensaje("Datos grabados correctamente");
            fun.LimpiarGenerico(this);
            Grupo.Enabled = false;
            Botonera(1);
        }

        private void txt_NroDoc_TextChanged(object sender, EventArgs e)
        {
            string NroDoc = txt_NroDoc.Text;
            if (NroDoc.Length >6)
            {
                cDocente doc = new Clases.cDocente();
                DataTable trdo = doc.GetDocentexDni(NroDoc);
                if (trdo.Rows.Count >0)
                {
                    txt_Apellido.Text = trdo.Rows[0]["Apellido"].ToString();
                    txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                    txt_Email.Text = trdo.Rows[0]["Email"].ToString();
                    txtCodDocente.Text = trdo.Rows[0]["CodDocente"].ToString();
                    txt_Celular.Text = trdo.Rows[0]["Celular"].ToString();
                }
                else
                {
                    txtCodDocente.Text = "";
                    txt_Apellido.Text = "";
                    txt_Nombre.Text = "";
                    txt_Email.Text = "";
                }
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Principal.OpcionesdeBusqueda = "Apellido;Nombre;NroDoc";
            Principal.TablaPrincipal = "Docente";
            Principal.OpcionesColumnasGrilla = "CodDocente;NroDoc;Apellido;Nombre";
            Principal.ColumnasVisibles = "0;1;1;1";
            Principal.ColumnasAncho = "0;100;240;240";
            FrmBuscadorGenerico form = new FrmBuscadorGenerico();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (Principal.CodigoPrincipalAbm != null)
            {
                Botonera(3);
                txtCodDocente.Text = Principal.CodigoPrincipalAbm.ToString();
                cFunciones fun = new Clases.cFunciones();
                fun.CargarControles(this, "Docente", "CodDocente", txtCodDocente.Text);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Botonera(1);
            fun.LimpiarGenerico(this);
            Grupo.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
