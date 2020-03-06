namespace ESCUELA
{
    partial class FrmInscripcionConvocatoria
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdConvocatoria = new System.Windows.Forms.TextBox();
            this.btnPuntaje = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDocente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbConvocatoria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdConvocatoria);
            this.groupBox1.Controls.Add(this.btnPuntaje);
            this.groupBox1.Controls.Add(this.btnGrabar);
            this.groupBox1.Controls.Add(this.txtDni);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDocente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbConvocatoria);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 297);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulario de Convocatoria";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtIdConvocatoria
            // 
            this.txtIdConvocatoria.Location = new System.Drawing.Point(371, 37);
            this.txtIdConvocatoria.Name = "txtIdConvocatoria";
            this.txtIdConvocatoria.Size = new System.Drawing.Size(63, 26);
            this.txtIdConvocatoria.TabIndex = 8;
            // 
            // btnPuntaje
            // 
            this.btnPuntaje.Location = new System.Drawing.Point(233, 125);
            this.btnPuntaje.Name = "btnPuntaje";
            this.btnPuntaje.Size = new System.Drawing.Size(109, 31);
            this.btnPuntaje.TabIndex = 7;
            this.btnPuntaje.Text = "Puntaje";
            this.btnPuntaje.UseVisualStyleBackColor = true;
            this.btnPuntaje.Click += new System.EventHandler(this.btnPuntaje_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnGrabar.Location = new System.Drawing.Point(134, 125);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 31);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(134, 96);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(103, 26);
            this.txtDni.TabIndex = 5;
            this.txtDni.TextChanged += new System.EventHandler(this.txtDni_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dni";
            // 
            // txtDocente
            // 
            this.txtDocente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocente.Location = new System.Drawing.Point(134, 67);
            this.txtDocente.Name = "txtDocente";
            this.txtDocente.Size = new System.Drawing.Size(204, 26);
            this.txtDocente.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Docente";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // CmbConvocatoria
            // 
            this.CmbConvocatoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbConvocatoria.FormattingEnabled = true;
            this.CmbConvocatoria.Location = new System.Drawing.Point(146, 37);
            this.CmbConvocatoria.Name = "CmbConvocatoria";
            this.CmbConvocatoria.Size = new System.Drawing.Size(219, 28);
            this.CmbConvocatoria.TabIndex = 1;
            this.CmbConvocatoria.SelectedIndexChanged += new System.EventHandler(this.CmbConvocatoria_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Convocatoria";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 273);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(8, 23);
            this.textBox1.TabIndex = 1;
            // 
            // FrmInscripcionConvocatoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 321);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmInscripcionConvocatoria";
            this.Text = "FrmInscripcionConvocatoria";
            this.Load += new System.EventHandler(this.FrmInscripcionConvocatoria_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbConvocatoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDocente;
        private System.Windows.Forms.Button btnPuntaje;
        private System.Windows.Forms.TextBox txtIdConvocatoria;
    }
}