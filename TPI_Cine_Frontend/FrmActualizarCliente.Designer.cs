namespace TPI_Cine_Frontend
{
    partial class FrmActualizarCliente
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
            gpActualizarCliente = new GroupBox();
            txtDNI = new TextBox();
            txtApellido = new TextBox();
            lblDNI = new Label();
            cboTipoDoc = new ComboBox();
            lblTipoDocumento = new Label();
            lblApellido = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            btnCargarCliente = new Button();
            btnCancelar = new Button();
            btnEditar = new Button();
            gpActualizarCliente.SuspendLayout();
            SuspendLayout();
            // 
            // gpActualizarCliente
            // 
            gpActualizarCliente.BackColor = SystemColors.ActiveCaption;
            gpActualizarCliente.Controls.Add(txtDNI);
            gpActualizarCliente.Controls.Add(txtApellido);
            gpActualizarCliente.Controls.Add(lblDNI);
            gpActualizarCliente.Controls.Add(cboTipoDoc);
            gpActualizarCliente.Controls.Add(lblTipoDocumento);
            gpActualizarCliente.Controls.Add(lblApellido);
            gpActualizarCliente.Controls.Add(txtNombre);
            gpActualizarCliente.Controls.Add(lblNombre);
            gpActualizarCliente.ForeColor = SystemColors.ControlText;
            gpActualizarCliente.Location = new Point(12, 12);
            gpActualizarCliente.Name = "gpActualizarCliente";
            gpActualizarCliente.Size = new Size(334, 264);
            gpActualizarCliente.TabIndex = 21;
            gpActualizarCliente.TabStop = false;
            gpActualizarCliente.Text = "Actualizar Cliente";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(149, 202);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(121, 23);
            txtDNI.TabIndex = 12;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(149, 94);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(121, 23);
            txtApellido.TabIndex = 11;
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Location = new Point(46, 210);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(27, 15);
            lblDNI.TabIndex = 9;
            lblDNI.Text = "DNI";
            // 
            // cboTipoDoc
            // 
            cboTipoDoc.FormattingEnabled = true;
            cboTipoDoc.Location = new Point(149, 150);
            cboTipoDoc.Name = "cboTipoDoc";
            cboTipoDoc.Size = new Size(121, 23);
            cboTipoDoc.TabIndex = 8;
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Location = new Point(46, 153);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(96, 15);
            lblTipoDocumento.TabIndex = 6;
            lblTipoDocumento.Text = "Tipo Documento";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(46, 97);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(149, 40);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(121, 23);
            txtNombre.TabIndex = 3;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(46, 40);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // btnCargarCliente
            // 
            btnCargarCliente.Location = new Point(113, 291);
            btnCargarCliente.Name = "btnCargarCliente";
            btnCargarCliente.Size = new Size(135, 23);
            btnCargarCliente.TabIndex = 25;
            btnCargarCliente.Text = "Cargar Cliente";
            btnCargarCliente.UseVisualStyleBackColor = true;
            btnCargarCliente.Click += btnCargarCliente_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(271, 291);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 24;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(12, 291);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 22;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // FrmActualizarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(361, 325);
            Controls.Add(btnCargarCliente);
            Controls.Add(btnCancelar);
            Controls.Add(btnEditar);
            Controls.Add(gpActualizarCliente);
            Name = "FrmActualizarCliente";
            Text = "Modificacion de cliente";
            Load += FrmActualizarCliente_Load;
            gpActualizarCliente.ResumeLayout(false);
            gpActualizarCliente.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpActualizarCliente;
        private TextBox txtDNI;
        private TextBox txtApellido;
        private Label lblDNI;
        private ComboBox cboTipoDoc;
        private Label lblTipoDocumento;
        private Label lblApellido;
        private TextBox txtNombre;
        private Label lblNombre;
        private Button btnCargarCliente;
        private Button btnCancelar;
        private Button btnEditar;
    }
}