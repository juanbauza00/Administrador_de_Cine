namespace TPI_Cine_Frontend
{
    partial class FrmAltaFuncion
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
            groupBox1 = new GroupBox();
            cboFormato = new ComboBox();
            label1 = new Label();
            lblTipoSala = new Label();
            txtTipoSala = new TextBox();
            cboSala = new ComboBox();
            lblSala = new Label();
            cboPelicula = new ComboBox();
            lblPelicula = new Label();
            dtpHoraFuncion = new DateTimePicker();
            lblHorario = new Label();
            lblFecha = new Label();
            dtpFechaFuncion = new DateTimePicker();
            lblNroPresupuesto = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(224, 348);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(93, 348);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 15;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(cboFormato);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblTipoSala);
            groupBox1.Controls.Add(txtTipoSala);
            groupBox1.Controls.Add(cboSala);
            groupBox1.Controls.Add(lblSala);
            groupBox1.Controls.Add(cboPelicula);
            groupBox1.Controls.Add(lblPelicula);
            groupBox1.Controls.Add(dtpHoraFuncion);
            groupBox1.Controls.Add(lblHorario);
            groupBox1.Controls.Add(lblFecha);
            groupBox1.Controls.Add(dtpFechaFuncion);
            groupBox1.Controls.Add(lblNroPresupuesto);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(12, 24);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(378, 309);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sucursal De Cine";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // cboFormato
            // 
            cboFormato.FormattingEnabled = true;
            cboFormato.Location = new Point(123, 264);
            cboFormato.Name = "cboFormato";
            cboFormato.Size = new Size(204, 23);
            cboFormato.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 264);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 12;
            label1.Text = "Formato";
            // 
            // lblTipoSala
            // 
            lblTipoSala.AutoSize = true;
            lblTipoSala.Location = new Point(45, 214);
            lblTipoSala.Name = "lblTipoSala";
            lblTipoSala.Size = new Size(54, 15);
            lblTipoSala.TabIndex = 11;
            lblTipoSala.Text = "Tipo Sala";
            // 
            // txtTipoSala
            // 
            txtTipoSala.Enabled = false;
            txtTipoSala.Location = new Point(121, 214);
            txtTipoSala.Name = "txtTipoSala";
            txtTipoSala.Size = new Size(206, 23);
            txtTipoSala.TabIndex = 10;
            // 
            // cboSala
            // 
            cboSala.FormattingEnabled = true;
            cboSala.Location = new Point(121, 177);
            cboSala.Name = "cboSala";
            cboSala.Size = new Size(206, 23);
            cboSala.TabIndex = 9;
            cboSala.SelectedIndexChanged += cboSala_SelectedIndexChanged;
            // 
            // lblSala
            // 
            lblSala.AutoSize = true;
            lblSala.Location = new Point(45, 180);
            lblSala.Name = "lblSala";
            lblSala.Size = new Size(28, 15);
            lblSala.TabIndex = 8;
            lblSala.Text = "Sala";
            // 
            // cboPelicula
            // 
            cboPelicula.FormattingEnabled = true;
            cboPelicula.Location = new Point(121, 57);
            cboPelicula.Name = "cboPelicula";
            cboPelicula.Size = new Size(206, 23);
            cboPelicula.TabIndex = 7;
            cboPelicula.SelectedIndexChanged += cboPelicula_SelectedIndexChanged;
            // 
            // lblPelicula
            // 
            lblPelicula.AutoSize = true;
            lblPelicula.Location = new Point(44, 60);
            lblPelicula.Name = "lblPelicula";
            lblPelicula.Size = new Size(48, 15);
            lblPelicula.TabIndex = 6;
            lblPelicula.Text = "Pelicula";
            // 
            // dtpHoraFuncion
            // 
            dtpHoraFuncion.Format = DateTimePickerFormat.Time;
            dtpHoraFuncion.Location = new Point(121, 135);
            dtpHoraFuncion.Name = "dtpHoraFuncion";
            dtpHoraFuncion.Size = new Size(91, 23);
            dtpHoraFuncion.TabIndex = 5;
            dtpHoraFuncion.Value = new DateTime(2023, 11, 13, 15, 7, 0, 0);
            // 
            // lblHorario
            // 
            lblHorario.AutoSize = true;
            lblHorario.Location = new Point(44, 141);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new Size(47, 15);
            lblHorario.TabIndex = 4;
            lblHorario.Text = "Horario";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(44, 102);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha";
            // 
            // dtpFechaFuncion
            // 
            dtpFechaFuncion.Format = DateTimePickerFormat.Short;
            dtpFechaFuncion.Location = new Point(121, 102);
            dtpFechaFuncion.Name = "dtpFechaFuncion";
            dtpFechaFuncion.Size = new Size(206, 23);
            dtpFechaFuncion.TabIndex = 2;
            // 
            // lblNroPresupuesto
            // 
            lblNroPresupuesto.AutoSize = true;
            lblNroPresupuesto.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNroPresupuesto.Location = new Point(16, 19);
            lblNroPresupuesto.Margin = new Padding(4, 0, 4, 0);
            lblNroPresupuesto.Name = "lblNroPresupuesto";
            lblNroPresupuesto.Size = new Size(179, 20);
            lblNroPresupuesto.TabIndex = 1;
            lblNroPresupuesto.Text = "Registro De Funcion:";
            // 
            // FrmAltaFuncion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(403, 380);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(groupBox1);
            Name = "FrmAltaFuncion";
            Text = "Alta de Funciones";
            Load += FrmAltaFuncion_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnCancelar;
        private Button btnAceptar;
        private GroupBox groupBox1;
        private Label lblNroPresupuesto;
        private Label lblFecha;
        private DateTimePicker dtpFechaFuncion;
        private DateTimePicker dtpHoraFuncion;
        private Label lblHorario;
        private ComboBox cboSala;
        private Label lblSala;
        private ComboBox cboPelicula;
        private Label lblPelicula;
        private Label lblTipoSala;
        private TextBox txtTipoSala;
        private ComboBox cboFormato;
        private Label label1;
    }
}