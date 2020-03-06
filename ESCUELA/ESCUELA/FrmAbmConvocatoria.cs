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
    public partial class FrmAbmConvocatoria : FrmBase 
    {
        cFunciones fun;
        public FrmAbmConvocatoria()
        {
            InitializeComponent();
        }

        private void FrmAbmConvocatoria_Load(object sender, EventArgs e)
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
            if (txt_Descripcion.Text =="")
            {
                MessageBox.Show("Debe ingresar un nomre para continuar");
                return;
            }
            if (txtCodigo.Text == "")
                fun.GuardarNuevoGenerico(this, "Convocatoria");
            else
            {
                // if (txt_Ruta.Text != "")
                //   txt_Ruta.Text = txt_Ruta.Text.Replace("\\", "\\\\");
                fun.ModificarGenerico(this, "Convocatoria", "IdConvocatoria", txtCodigo.Text);

            }
            Mensaje("Datos grabados correctamente");
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Principal.OpcionesdeBusqueda = "Descripcion";
            Principal.TablaPrincipal = "Convocatoria";
            Principal.OpcionesColumnasGrilla = "IdConvocatoria;Descripcion;FechaFin";
            Principal.ColumnasVisibles = "0;1;1";
            Principal.ColumnasAncho = "0;390;190";
            FrmBuscadorGenerico form = new FrmBuscadorGenerico();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (Principal.CodigoPrincipalAbm != null)
            {
                Botonera(3);
                txtCodigo.Text = Principal.CodigoPrincipalAbm.ToString();
                cFunciones fun = new Clases.cFunciones();
                fun.CargarControles(this, "Convocatoria", "IdConvocatoria", txtCodigo.Text);                
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
             Botonera(2);
            Grupo.Enabled = true;
        }
    }
}
