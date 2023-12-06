namespace TPI_Cine_Frontend
{
    partial class FrmActualizarTicket
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
            lblCodigoTicket = new Label();
            btnEditar = new Button();
            txtCodigoTicket = new TextBox();
            lblCliente = new Label();
            lblFormaPago = new Label();
            cboCliente = new ComboBox();
            cboFormaPago = new ComboBox();
            label1 = new Label();
            dtpFecha = new DateTimePicker();
            lblFecha = new Label();
            btnCancelar = new Button();
            gpActualizarTicket = new GroupBox();
            cboPagado = new ComboBox();
            btnAceptar = new Button();
            gpActualizarTicket.SuspendLayout();
            SuspendLayout();
            // 
            // lblCodigoTicket
            // 
            lblCodigoTicket.AutoSize = true;
            lblCodigoTicket.Location = new Point(21, 31);
            lblCodigoTicket.Name = "lblCodigoTicket";
            lblCodigoTicket.Size = new Size(80, 15);
            lblCodigoTicket.TabIndex = 0;
            lblCodigoTicket.Text = "Codigo Ticket";
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(119, 292);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // txtCodigoTicket
            // 
            txtCodigoTicket.Location = new Point(107, 31);
            txtCodigoTicket.Name = "txtCodigoTicket";
            txtCodigoTicket.Size = new Size(125, 23);
            txtCodigoTicket.TabIndex = 3;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(57, 78);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 4;
            lblCliente.Text = "Cliente";
            // 
            // lblFormaPago
            // 
            lblFormaPago.AutoSize = true;
            lblFormaPago.Location = new Point(30, 125);
            lblFormaPago.Name = "lblFormaPago";
            lblFormaPago.Size = new Size(71, 15);
            lblFormaPago.TabIndex = 6;
            lblFormaPago.Text = "Forma Pago";
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(107, 77);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(125, 23);
            cboCliente.TabIndex = 7;
            // 
            // cboFormaPago
            // 
            cboFormaPago.FormattingEnabled = true;
            cboFormaPago.Location = new Point(107, 123);
            cboFormaPago.Name = "cboFormaPago";
            cboFormaPago.Size = new Size(125, 23);
            cboFormaPago.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 172);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 9;
            label1.Text = "Estado";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(107, 215);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(125, 23);
            dtpFecha.TabIndex = 11;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(63, 219);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 12;
            lblFecha.Text = "Fecha";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(223, 292);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // gpActualizarTicket
            // 
            gpActualizarTicket.BackColor = SystemColors.ActiveCaption;
            gpActualizarTicket.Controls.Add(cboPagado);
            gpActualizarTicket.Controls.Add(lblFecha);
            gpActualizarTicket.Controls.Add(dtpFecha);
            gpActualizarTicket.Controls.Add(label1);
            gpActualizarTicket.Controls.Add(cboFormaPago);
            gpActualizarTicket.Controls.Add(cboCliente);
            gpActualizarTicket.Controls.Add(lblFormaPago);
            gpActualizarTicket.Controls.Add(lblCliente);
            gpActualizarTicket.Controls.Add(txtCodigoTicket);
            gpActualizarTicket.Controls.Add(lblCodigoTicket);
            gpActualizarTicket.ForeColor = SystemColors.ControlText;
            gpActualizarTicket.Location = new Point(12, 12);
            gpActualizarTicket.Name = "gpActualizarTicket";
            gpActualizarTicket.Size = new Size(286, 264);
            gpActualizarTicket.TabIndex = 15;
            gpActualizarTicket.TabStop = false;
            gpActualizarTicket.Text = "Actualizar Ticket";
            gpActualizarTicket.Enter += gpActualizarTicket_Enter;
            // 
            // cboPagado
            // 
            cboPagado.FormattingEnabled = true;
            cboPagado.Location = new Point(106, 169);
            cboPagado.Name = "cboPagado";
            cboPagado.Size = new Size(126, 23);
            cboPagado.TabIndex = 13;
            cboPagado.SelectedIndexChanged += cboPagado_SelectedIndexChanged;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(12, 292);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 16;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FrmActualizarTicket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(310, 325);
            Controls.Add(btnAceptar);
            Controls.Add(gpActualizarTicket);
            Controls.Add(btnCancelar);
            Controls.Add(btnEditar);
            Name = "FrmActualizarTicket";
            Text = "Modificacion de Ticket";
            Load += FrmActualizarTicket_Load;
            gpActualizarTicket.ResumeLayout(false);
            gpActualizarTicket.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblCodigoTicket;
        private Button btnEditar;
        private TextBox txtCodigoTicket;
        private Label lblCliente;
        private Label lblFormaPago;
        private ComboBox cboCliente;
        private ComboBox cboFormaPago;
        private Label label1;
        private DateTimePicker dtpFecha;
        private Label lblFecha;
        private Button btnCancelar;
        private GroupBox gpActualizarTicket;
        private Button btnAceptar;
        private ComboBox cboPagado;
    }
}