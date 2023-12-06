namespace TPI_Cine_Frontend
{
    partial class FrmAltaCliente
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
            lblNroPresupuesto = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            lblTipoDocumento = new Label();
            lblDni = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            cboTipoDocumento = new ComboBox();
            groupBox1 = new GroupBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblNroPresupuesto
            // 
            lblNroPresupuesto.AutoSize = true;
            lblNroPresupuesto.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNroPresupuesto.Location = new Point(16, 19);
            lblNroPresupuesto.Margin = new Padding(4, 0, 4, 0);
            lblNroPresupuesto.Name = "lblNroPresupuesto";
            lblNroPresupuesto.Size = new Size(171, 20);
            lblNroPresupuesto.TabIndex = 1;
            lblNroPresupuesto.Text = "Registro De Cliente:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(27, 64);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(27, 113);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido";
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Location = new Point(27, 162);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(96, 15);
            lblTipoDocumento.TabIndex = 4;
            lblTipoDocumento.Text = "Tipo Documento";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(27, 211);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(27, 15);
            lblDni.TabIndex = 5;
            lblDni.Text = "DNI";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(134, 64);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(134, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(134, 112);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(134, 23);
            txtApellido.TabIndex = 7;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(134, 208);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(134, 23);
            txtDni.TabIndex = 8;
            // 
            // cboTipoDocumento
            // 
            cboTipoDocumento.FormattingEnabled = true;
            cboTipoDocumento.Location = new Point(134, 160);
            cboTipoDocumento.Name = "cboTipoDocumento";
            cboTipoDocumento.Size = new Size(134, 23);
            cboTipoDocumento.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(lblNroPresupuesto);
            groupBox1.Controls.Add(cboTipoDocumento);
            groupBox1.Controls.Add(lblNombre);
            groupBox1.Controls.Add(txtDni);
            groupBox1.Controls.Add(lblApellido);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(lblTipoDocumento);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(lblDni);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(309, 253);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sucursal De Cine";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(75, 271);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 11;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(180, 271);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmAltaCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(333, 298);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(groupBox1);
            ForeColor = SystemColors.ControlText;
            Name = "FrmAltaCliente";
            Text = "Alta Cliente";
            Load += FrmAltaCliente_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblNroPresupuesto;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblTipoDocumento;
        private Label lblDni;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDni;
        private ComboBox cboTipoDocumento;
        private GroupBox groupBox1;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}