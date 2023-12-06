namespace TPI_Cine_Frontend
{
    partial class FrmActualizarFuncion
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
            btnCancelar = new Button();
            btnAceptar = new Button();
            cboFormato = new ComboBox();
            cboPelicula = new ComboBox();
            txtSala = new TextBox();
            txtFecha = new TextBox();
            lblSala = new Label();
            lblFormato = new Label();
            lblFecha = new Label();
            lblPelicula = new Label();
            btnEditar = new Button();
            grpEditar = new GroupBox();
            grpEditar.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(237, 249);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(17, 249);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 20;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // cboFormato
            // 
            cboFormato.FormattingEnabled = true;
            cboFormato.Location = new Point(98, 116);
            cboFormato.Name = "cboFormato";
            cboFormato.Size = new Size(180, 23);
            cboFormato.TabIndex = 19;
            // 
            // cboPelicula
            // 
            cboPelicula.FormattingEnabled = true;
            cboPelicula.Location = new Point(115, 36);
            cboPelicula.Name = "cboPelicula";
            cboPelicula.Size = new Size(180, 23);
            cboPelicula.TabIndex = 18;
            // 
            // txtSala
            // 
            txtSala.Location = new Point(98, 162);
            txtSala.Name = "txtSala";
            txtSala.Size = new Size(180, 23);
            txtSala.TabIndex = 17;
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(98, 70);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(180, 23);
            txtFecha.TabIndex = 16;
            // 
            // lblSala
            // 
            lblSala.AutoSize = true;
            lblSala.BackColor = SystemColors.ActiveCaption;
            lblSala.Location = new Point(61, 162);
            lblSala.Name = "lblSala";
            lblSala.Size = new Size(28, 15);
            lblSala.TabIndex = 15;
            lblSala.Text = "Sala";
            // 
            // lblFormato
            // 
            lblFormato.AutoSize = true;
            lblFormato.BackColor = SystemColors.ActiveCaption;
            lblFormato.Location = new Point(37, 117);
            lblFormato.Name = "lblFormato";
            lblFormato.Size = new Size(52, 15);
            lblFormato.TabIndex = 14;
            lblFormato.Text = "Formato";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = SystemColors.ActiveCaption;
            lblFecha.Location = new Point(13, 72);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(76, 15);
            lblFecha.TabIndex = 13;
            lblFecha.Text = "Fecha y Hora";
            // 
            // lblPelicula
            // 
            lblPelicula.AutoSize = true;
            lblPelicula.BackColor = SystemColors.ActiveCaption;
            lblPelicula.Location = new Point(41, 27);
            lblPelicula.Name = "lblPelicula";
            lblPelicula.Size = new Size(48, 15);
            lblPelicula.TabIndex = 12;
            lblPelicula.Text = "Pelicula";
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(126, 249);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 22;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // grpEditar
            // 
            grpEditar.BackColor = SystemColors.ActiveCaption;
            grpEditar.Controls.Add(txtSala);
            grpEditar.Controls.Add(cboFormato);
            grpEditar.Controls.Add(txtFecha);
            grpEditar.Controls.Add(lblFecha);
            grpEditar.Controls.Add(lblPelicula);
            grpEditar.Controls.Add(lblSala);
            grpEditar.Controls.Add(lblFormato);
            grpEditar.Location = new Point(17, 12);
            grpEditar.Name = "grpEditar";
            grpEditar.Size = new Size(295, 221);
            grpEditar.TabIndex = 23;
            grpEditar.TabStop = false;
            grpEditar.Text = "Editar";
            // 
            // FrmActualizarFuncion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(330, 280);
            Controls.Add(btnEditar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cboPelicula);
            Controls.Add(grpEditar);
            Name = "FrmActualizarFuncion";
            Text = "Actualizar funcion";
            Load += FrmActualizarFuncion_Load;
            grpEditar.ResumeLayout(false);
            grpEditar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private ComboBox cboFormato;
        private ComboBox cboPelicula;
        private TextBox txtSala;
        private TextBox txtFecha;
        private Label lblSala;
        private Label lblFormato;
        private Label lblFecha;
        private Label lblPelicula;
        private Button btnEditar;
        private GroupBox grpEditar;
    }
}