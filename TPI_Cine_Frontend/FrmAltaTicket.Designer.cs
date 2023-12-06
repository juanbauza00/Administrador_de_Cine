namespace TPI_Cine_Frontend
{
    partial class FrmAltaTicket
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
            lblFormaDePago = new Label();
            lblDescuento = new Label();
            lblEstado = new Label();
            lblCantidadButacas = new Label();
            lblButacasDisponibles = new Label();
            cboFormasPago = new ComboBox();
            groupBox1 = new GroupBox();
            cboCliente = new ComboBox();
            dtpFecha = new DateTimePicker();
            dtpHora = new DateTimePicker();
            txtDocumento = new TextBox();
            txtPelicula = new TextBox();
            lblFecha = new Label();
            lblHora = new Label();
            lblPelicula = new Label();
            lblDocumento = new Label();
            lblCliente = new Label();
            groupBox2 = new GroupBox();
            txtDescuento = new TextBox();
            chkPagarAhora = new CheckBox();
            btnButacas = new Button();
            lblSeleccionarButacas = new Label();
            txtButacasSelec = new TextBox();
            txtCantidadButacas = new TextBox();
            txtButacasDisponibles = new TextBox();
            lblButacasSeleccionadas = new Label();
            btnCancelar = new Button();
            btnConfirmar = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblFormaDePago
            // 
            lblFormaDePago.AutoSize = true;
            lblFormaDePago.Location = new Point(5, 30);
            lblFormaDePago.Name = "lblFormaDePago";
            lblFormaDePago.Size = new Size(90, 15);
            lblFormaDePago.TabIndex = 0;
            lblFormaDePago.Text = "Forma de Pago:";
            // 
            // lblDescuento
            // 
            lblDescuento.AutoSize = true;
            lblDescuento.Location = new Point(5, 73);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(66, 15);
            lblDescuento.TabIndex = 1;
            lblDescuento.Text = "Descuento:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(11, 118);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "Estado:";
            // 
            // lblCantidadButacas
            // 
            lblCantidadButacas.AutoSize = true;
            lblCantidadButacas.Location = new Point(287, 72);
            lblCantidadButacas.Name = "lblCantidadButacas";
            lblCantidadButacas.Size = new Size(102, 15);
            lblCantidadButacas.TabIndex = 4;
            lblCantidadButacas.Text = "Cantidad Butacas:";
            // 
            // lblButacasDisponibles
            // 
            lblButacasDisponibles.AutoSize = true;
            lblButacasDisponibles.Location = new Point(271, 30);
            lblButacasDisponibles.Name = "lblButacasDisponibles";
            lblButacasDisponibles.Size = new Size(115, 15);
            lblButacasDisponibles.TabIndex = 5;
            lblButacasDisponibles.Text = "Butacas Disponibles:";
            // 
            // cboFormasPago
            // 
            cboFormasPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormasPago.FormattingEnabled = true;
            cboFormasPago.Location = new Point(108, 30);
            cboFormasPago.Margin = new Padding(3, 2, 3, 2);
            cboFormasPago.Name = "cboFormasPago";
            cboFormasPago.Size = new Size(133, 23);
            cboFormasPago.TabIndex = 6;
            cboFormasPago.SelectedIndexChanged += cboFormasPago_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(cboCliente);
            groupBox1.Controls.Add(dtpFecha);
            groupBox1.Controls.Add(dtpHora);
            groupBox1.Controls.Add(txtDocumento);
            groupBox1.Controls.Add(txtPelicula);
            groupBox1.Controls.Add(lblFecha);
            groupBox1.Controls.Add(lblHora);
            groupBox1.Controls.Add(lblPelicula);
            groupBox1.Controls.Add(lblDocumento);
            groupBox1.Controls.Add(lblCliente);
            groupBox1.Location = new Point(17, 10);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(668, 110);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cliente / Funcion";
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(66, 27);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(259, 23);
            cboCliente.TabIndex = 16;
            cboCliente.SelectedIndexChanged += cboCliente_SelectedIndexChanged;
            // 
            // dtpFecha
            // 
            dtpFecha.Enabled = false;
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(542, 70);
            dtpFecha.Margin = new Padding(3, 2, 3, 2);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(109, 23);
            dtpFecha.TabIndex = 15;
            // 
            // dtpHora
            // 
            dtpHora.Enabled = false;
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.Location = new Point(389, 70);
            dtpHora.Margin = new Padding(3, 2, 3, 2);
            dtpHora.Name = "dtpHora";
            dtpHora.Size = new Size(92, 23);
            dtpHora.TabIndex = 14;
            // 
            // txtDocumento
            // 
            txtDocumento.Enabled = false;
            txtDocumento.Location = new Point(429, 27);
            txtDocumento.Margin = new Padding(3, 2, 3, 2);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.ReadOnly = true;
            txtDocumento.Size = new Size(222, 23);
            txtDocumento.TabIndex = 13;
            txtDocumento.TextChanged += txtDocumento_TextChanged;
            // 
            // txtPelicula
            // 
            txtPelicula.Enabled = false;
            txtPelicula.Location = new Point(75, 70);
            txtPelicula.Margin = new Padding(3, 2, 3, 2);
            txtPelicula.Name = "txtPelicula";
            txtPelicula.ReadOnly = true;
            txtPelicula.Size = new Size(245, 23);
            txtPelicula.TabIndex = 12;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(493, 70);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha:";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(345, 70);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(36, 15);
            lblHora.TabIndex = 3;
            lblHora.Text = "Hora:";
            // 
            // lblPelicula
            // 
            lblPelicula.AutoSize = true;
            lblPelicula.Location = new Point(5, 70);
            lblPelicula.Name = "lblPelicula";
            lblPelicula.Size = new Size(51, 15);
            lblPelicula.TabIndex = 2;
            lblPelicula.Text = "Pelicula:";
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(345, 27);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(73, 15);
            lblDocumento.TabIndex = 1;
            lblDocumento.Text = "Documento:";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(5, 27);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ActiveCaption;
            groupBox2.Controls.Add(txtDescuento);
            groupBox2.Controls.Add(chkPagarAhora);
            groupBox2.Controls.Add(btnButacas);
            groupBox2.Controls.Add(lblSeleccionarButacas);
            groupBox2.Controls.Add(txtButacasSelec);
            groupBox2.Controls.Add(txtCantidadButacas);
            groupBox2.Controls.Add(txtButacasDisponibles);
            groupBox2.Controls.Add(lblButacasSeleccionadas);
            groupBox2.Controls.Add(lblButacasDisponibles);
            groupBox2.Controls.Add(lblEstado);
            groupBox2.Controls.Add(cboFormasPago);
            groupBox2.Controls.Add(lblCantidadButacas);
            groupBox2.Controls.Add(lblDescuento);
            groupBox2.Controls.Add(lblFormaDePago);
            groupBox2.Location = new Point(17, 124);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(668, 184);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pago / Butacas";
            // 
            // txtDescuento
            // 
            txtDescuento.Enabled = false;
            txtDescuento.Location = new Point(108, 73);
            txtDescuento.Margin = new Padding(3, 2, 3, 2);
            txtDescuento.Name = "txtDescuento";
            txtDescuento.ReadOnly = true;
            txtDescuento.Size = new Size(133, 23);
            txtDescuento.TabIndex = 17;
            // 
            // chkPagarAhora
            // 
            chkPagarAhora.AutoSize = true;
            chkPagarAhora.Location = new Point(108, 118);
            chkPagarAhora.Name = "chkPagarAhora";
            chkPagarAhora.Size = new Size(94, 19);
            chkPagarAhora.TabIndex = 16;
            chkPagarAhora.Text = " Pagar Ahora";
            chkPagarAhora.UseVisualStyleBackColor = true;
            // 
            // btnButacas
            // 
            btnButacas.Location = new Point(403, 111);
            btnButacas.Margin = new Padding(3, 2, 3, 2);
            btnButacas.Name = "btnButacas";
            btnButacas.Size = new Size(124, 22);
            btnButacas.TabIndex = 15;
            btnButacas.Text = "Butacas";
            btnButacas.UseVisualStyleBackColor = true;
            btnButacas.Click += btnButacas_Click;
            // 
            // lblSeleccionarButacas
            // 
            lblSeleccionarButacas.AutoSize = true;
            lblSeleccionarButacas.Location = new Point(273, 113);
            lblSeleccionarButacas.Name = "lblSeleccionarButacas";
            lblSeleccionarButacas.Size = new Size(114, 15);
            lblSeleccionarButacas.TabIndex = 14;
            lblSeleccionarButacas.Text = "Seleccionar Butacas:";
            // 
            // txtButacasSelec
            // 
            txtButacasSelec.Enabled = false;
            txtButacasSelec.Location = new Point(403, 148);
            txtButacasSelec.Margin = new Padding(3, 2, 3, 2);
            txtButacasSelec.Name = "txtButacasSelec";
            txtButacasSelec.ReadOnly = true;
            txtButacasSelec.Size = new Size(204, 23);
            txtButacasSelec.TabIndex = 13;
            // 
            // txtCantidadButacas
            // 
            txtCantidadButacas.Location = new Point(403, 73);
            txtCantidadButacas.Margin = new Padding(3, 2, 3, 2);
            txtCantidadButacas.Name = "txtCantidadButacas";
            txtCantidadButacas.Size = new Size(133, 23);
            txtCantidadButacas.TabIndex = 12;
            txtCantidadButacas.TextChanged += txtCantidadButacas_TextChanged;
            // 
            // txtButacasDisponibles
            // 
            txtButacasDisponibles.Enabled = false;
            txtButacasDisponibles.Location = new Point(403, 30);
            txtButacasDisponibles.Margin = new Padding(3, 2, 3, 2);
            txtButacasDisponibles.Name = "txtButacasDisponibles";
            txtButacasDisponibles.ReadOnly = true;
            txtButacasDisponibles.Size = new Size(133, 23);
            txtButacasDisponibles.TabIndex = 11;
            // 
            // lblButacasSeleccionadas
            // 
            lblButacasSeleccionadas.AutoSize = true;
            lblButacasSeleccionadas.Location = new Point(257, 150);
            lblButacasSeleccionadas.Name = "lblButacasSeleccionadas";
            lblButacasSeleccionadas.Size = new Size(128, 15);
            lblButacasSeleccionadas.TabIndex = 7;
            lblButacasSeleccionadas.Text = "Butacas Seleccionadas:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(602, 316);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(471, 315);
            btnConfirmar.Margin = new Padding(3, 2, 3, 2);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(82, 22);
            btnConfirmar.TabIndex = 13;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // FrmAltaTicket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(700, 338);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmAltaTicket";
            Text = "Alta ticket";
            Load += FrmAltaDetallesTicket_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblFormaDePago;
        private Label lblDescuento;
        private Label lblEstado;
        private Label lblCantidadButacas;
        private Label lblButacasDisponibles;
        private ComboBox cboFormasPago;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lblButacasSeleccionadas;
        private Label lblSeleccionarButacas;
        private TextBox txtButacasSelec;
        private TextBox txtCantidadButacas;
        private TextBox txtButacasDisponibles;
        private Label lblFecha;
        private Label lblHora;
        private Label lblPelicula;
        private Label lblDocumento;
        private Label lblCliente;
        private Button btnButacas;
        private Button btnCancelar;
        private Button btnConfirmar;
        private TextBox txtDocumento;
        private TextBox txtPelicula;
        private DateTimePicker dtpFecha;
        private DateTimePicker dtpHora;
        private ComboBox cboCliente;
        private CheckBox chkPagarAhora;
        private TextBox txtDescuento;
    }
}