namespace ESCUELA
{
    partial class FrmRegistroCargo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.cmbCaracter = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAgregarMateria = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDivision = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCodDocente = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Grupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.label11);
            this.Grupo.Controls.Add(this.txtMail);
            this.Grupo.Controls.Add(this.label10);
            this.Grupo.Controls.Add(this.txtTelefono);
            this.Grupo.Controls.Add(this.cmbCaracter);
            this.Grupo.Controls.Add(this.label9);
            this.Grupo.Controls.Add(this.btnAgregarMateria);
            this.Grupo.Controls.Add(this.btnCancelar);
            this.Grupo.Controls.Add(this.btnGuardar);
            this.Grupo.Controls.Add(this.txtFechaHasta);
            this.Grupo.Controls.Add(this.label8);
            this.Grupo.Controls.Add(this.label7);
            this.Grupo.Controls.Add(this.txtFechaDesde);
            this.Grupo.Controls.Add(this.cmbMateria);
            this.Grupo.Controls.Add(this.label5);
            this.Grupo.Controls.Add(this.txtDivision);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Controls.Add(this.label4);
            this.Grupo.Controls.Add(this.label6);
            this.Grupo.Controls.Add(this.txtCurso);
            this.Grupo.Controls.Add(this.txtNroDoc);
            this.Grupo.Controls.Add(this.txtNombre);
            this.Grupo.Controls.Add(this.txtApellido);
            this.Grupo.Controls.Add(this.txtCodDocente);
            this.Grupo.ForeColor = System.Drawing.Color.Black;
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(498, 347);
            this.Grupo.TabIndex = 22;
            this.Grupo.TabStop = false;
            this.Grupo.Text = "Ficha Datos Personales";
            // 
            // cmbCaracter
            // 
            this.cmbCaracter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCaracter.FormattingEnabled = true;
            this.cmbCaracter.Location = new System.Drawing.Point(109, 216);
            this.cmbCaracter.Name = "cmbCaracter";
            this.cmbCaracter.Size = new System.Drawing.Size(341, 24);
            this.cmbCaracter.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(21, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 17);
            this.label9.TabIndex = 51;
            this.label9.Text = "Caracter";
            // 
            // btnAgregarMateria
            // 
            this.btnAgregarMateria.Location = new System.Drawing.Point(457, 157);
            this.btnAgregarMateria.Name = "btnAgregarMateria";
            this.btnAgregarMateria.Size = new System.Drawing.Size(28, 23);
            this.btnAgregarMateria.TabIndex = 50;
            this.btnAgregarMateria.UseVisualStyleBackColor = true;
            this.btnAgregarMateria.Click += new System.EventHandler(this.btnAgregarMateria_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(244, 297);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 31);
            this.btnCancelar.TabIndex = 49;
            this.btnCancelar.Text = "Guardar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(163, 297);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 31);
            this.btnGuardar.TabIndex = 48;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(285, 246);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(66, 23);
            this.txtFechaHasta.TabIndex = 47;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(191, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 46;
            this.label8.Text = "Fecha Hasta";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(13, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 45;
            this.label7.Text = "Fecha desde";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(109, 246);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(66, 23);
            this.txtFechaDesde.TabIndex = 44;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // cmbMateria
            // 
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(110, 160);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(341, 24);
            this.cmbMateria.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(191, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "División";
            // 
            // txtDivision
            // 
            this.txtDivision.Location = new System.Drawing.Point(270, 190);
            this.txtDivision.Multiline = true;
            this.txtDivision.Name = "txtDivision";
            this.txtDivision.Size = new System.Drawing.Size(96, 20);
            this.txtDivision.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(20, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Curso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(20, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Materia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(17, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(19, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(17, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nro Doc";
            // 
            // txtCurso
            // 
            this.txtCurso.Location = new System.Drawing.Point(110, 190);
            this.txtCurso.Multiline = true;
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.Size = new System.Drawing.Size(66, 20);
            this.txtCurso.TabIndex = 9;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(110, 31);
            this.txtNroDoc.Multiline = true;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(128, 20);
            this.txtNroDoc.TabIndex = 7;
            this.txtNroDoc.TextChanged += new System.EventHandler(this.txt_NroDoc_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(110, 83);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(340, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(110, 57);
            this.txtApellido.Multiline = true;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(340, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // txtCodDocente
            // 
            this.txtCodDocente.Location = new System.Drawing.Point(321, 31);
            this.txtCodDocente.Multiline = true;
            this.txtCodDocente.Name = "txtCodDocente";
            this.txtCodDocente.Size = new System.Drawing.Size(100, 20);
            this.txtCodDocente.TabIndex = 0;
            this.txtCodDocente.Visible = false;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(109, 109);
            this.txtTelefono.Multiline = true;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(340, 20);
            this.txtTelefono.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(19, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 54;
            this.label10.Text = "Teléfono";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(109, 135);
            this.txtMail.Multiline = true;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(340, 20);
            this.txtMail.TabIndex = 55;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(20, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 17);
            this.label11.TabIndex = 56;
            this.label11.Text = "Mail";
            // 
            // FrmRegistroCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 453);
            this.Controls.Add(this.Grupo);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmRegistroCargo";
            this.Text = "Registrar Cargos";
            this.Load += new System.EventHandler(this.FrmRegistroCargo_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCurso;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCodDocente;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDivision;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.MaskedTextBox txtFechaHasta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtFechaDesde;
        private System.Windows.Forms.Button btnAgregarMateria;
        private System.Windows.Forms.ComboBox cmbCaracter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMail;
    }
}