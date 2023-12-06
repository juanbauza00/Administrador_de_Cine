namespace TPI_Cine_Frontend
{
    partial class FrmConsultarTicket
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
            dgvTickets = new DataGridView();
            colFecha = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colFormaPago = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colModificar = new DataGridViewButtonColumn();
            colBorrar = new DataGridViewButtonColumn();
            gpClientConsult = new GroupBox();
            checkFiltrar = new CheckBox();
            btnConsultar = new Button();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTickets).BeginInit();
            gpClientConsult.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTickets
            // 
            dgvTickets.AllowUserToAddRows = false;
            dgvTickets.AllowUserToDeleteRows = false;
            dgvTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTickets.Columns.AddRange(new DataGridViewColumn[] { colFecha, colCliente, colFormaPago, colEstado, colModificar, colBorrar });
            dgvTickets.Location = new Point(12, 109);
            dgvTickets.Name = "dgvTickets";
            dgvTickets.ReadOnly = true;
            dgvTickets.RowHeadersWidth = 51;
            dgvTickets.RowTemplate.Height = 25;
            dgvTickets.Size = new Size(629, 205);
            dgvTickets.TabIndex = 11;
            dgvTickets.CellContentClick += dgvConsultarTickets_CellContentClickAsync;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            colFecha.SortMode = DataGridViewColumnSortMode.NotSortable;
            colFecha.Width = 125;
            // 
            // colCliente
            // 
            colCliente.HeaderText = "Cliente";
            colCliente.MinimumWidth = 6;
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            colCliente.SortMode = DataGridViewColumnSortMode.NotSortable;
            colCliente.Width = 125;
            // 
            // colFormaPago
            // 
            colFormaPago.HeaderText = "FomaPago";
            colFormaPago.MinimumWidth = 6;
            colFormaPago.Name = "colFormaPago";
            colFormaPago.ReadOnly = true;
            colFormaPago.SortMode = DataGridViewColumnSortMode.NotSortable;
            colFormaPago.Width = 85;
            // 
            // colEstado
            // 
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            colEstado.SortMode = DataGridViewColumnSortMode.NotSortable;
            colEstado.Width = 75;
            // 
            // colModificar
            // 
            colModificar.HeaderText = "Modificar";
            colModificar.MinimumWidth = 6;
            colModificar.Name = "colModificar";
            colModificar.ReadOnly = true;
            colModificar.Width = 80;
            // 
            // colBorrar
            // 
            colBorrar.HeaderText = "Borrar";
            colBorrar.MinimumWidth = 6;
            colBorrar.Name = "colBorrar";
            colBorrar.ReadOnly = true;
            colBorrar.Width = 85;
            // 
            // gpClientConsult
            // 
            gpClientConsult.BackColor = SystemColors.ActiveCaption;
            gpClientConsult.Controls.Add(checkFiltrar);
            gpClientConsult.Controls.Add(btnConsultar);
            gpClientConsult.Controls.Add(dtpHasta);
            gpClientConsult.Controls.Add(dtpDesde);
            gpClientConsult.Location = new Point(12, 12);
            gpClientConsult.Name = "gpClientConsult";
            gpClientConsult.Size = new Size(629, 83);
            gpClientConsult.TabIndex = 10;
            gpClientConsult.TabStop = false;
            gpClientConsult.Text = "Filtros de busqueda";
            // 
            // checkFiltrar
            // 
            checkFiltrar.AutoSize = true;
            checkFiltrar.Location = new Point(22, 21);
            checkFiltrar.Name = "checkFiltrar";
            checkFiltrar.Size = new Size(56, 19);
            checkFiltrar.TabIndex = 12;
            checkFiltrar.Text = "Filtrar";
            checkFiltrar.UseVisualStyleBackColor = true;
            checkFiltrar.CheckedChanged += checkFiltrar_CheckedChanged;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(259, 50);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(75, 23);
            btnConsultar.TabIndex = 4;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(140, 50);
            dtpHasta.Margin = new Padding(4, 3, 4, 3);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(93, 23);
            dtpHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(22, 50);
            dtpDesde.Margin = new Padding(4, 3, 4, 3);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(93, 23);
            dtpDesde.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(560, 319);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmConsultarTicket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(654, 346);
            Controls.Add(btnCancelar);
            Controls.Add(dgvTickets);
            Controls.Add(gpClientConsult);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmConsultarTicket";
            Text = "Consultar Tickets";
            Load += FrmConsultarTicket_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTickets).EndInit();
            gpClientConsult.ResumeLayout(false);
            gpClientConsult.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTickets;
        private GroupBox gpClientConsult;
        private Button btnConsultar;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private CheckBox checkFiltrar;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colFormaPago;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewButtonColumn colModificar;
        private DataGridViewButtonColumn colBorrar;
        private Button btnCancelar;
    }
}