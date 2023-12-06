namespace TPI_Cine_Frontend
{
    partial class FrmSeleccionFuncion
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
            groupBox2 = new GroupBox();
            dtpFechaHasta = new DateTimePicker();
            btnLimpiarFiltros = new Button();
            btnFiltrar = new Button();
            dtpFechaDesde = new DateTimePicker();
            lblFechaHasta = new Label();
            lblFecha = new Label();
            dgvFunciones = new DataGridView();
            colPelicula = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colFormato = new DataGridViewTextBoxColumn();
            colSala = new DataGridViewTextBoxColumn();
            colAcciones = new DataGridViewButtonColumn();
            btnSalir = new Button();
            label1 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFunciones).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ActiveCaption;
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(dtpFechaHasta);
            groupBox2.Controls.Add(btnLimpiarFiltros);
            groupBox2.Controls.Add(btnFiltrar);
            groupBox2.Controls.Add(dtpFechaDesde);
            groupBox2.Controls.Add(lblFechaHasta);
            groupBox2.Controls.Add(lblFecha);
            groupBox2.Controls.Add(dgvFunciones);
            groupBox2.Location = new Point(9, 11);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(745, 331);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Funciones";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(381, 54);
            dtpFechaHasta.Margin = new Padding(3, 2, 3, 2);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(117, 23);
            dtpFechaHasta.TabIndex = 10;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(573, 68);
            btnLimpiarFiltros.Margin = new Padding(3, 2, 3, 2);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(98, 22);
            btnLimpiarFiltros.TabIndex = 9;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(573, 38);
            btnFiltrar.Margin = new Padding(3, 2, 3, 2);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(98, 22);
            btnFiltrar.TabIndex = 8;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(129, 54);
            dtpFechaDesde.Margin = new Padding(3, 2, 3, 2);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(117, 23);
            dtpFechaDesde.TabIndex = 6;
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Location = new Point(291, 54);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(74, 15);
            lblFechaHasta.TabIndex = 5;
            lblFechaHasta.Text = "Fecha Hasta:";
            lblFechaHasta.Click += lblFechaHasta_Click;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(48, 54);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(75, 15);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha desde:";
            // 
            // dgvFunciones
            // 
            dgvFunciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFunciones.Columns.AddRange(new DataGridViewColumn[] { colPelicula, colFecha, colFormato, colSala, colAcciones });
            dgvFunciones.Location = new Point(45, 106);
            dgvFunciones.Margin = new Padding(3, 2, 3, 2);
            dgvFunciones.Name = "dgvFunciones";
            dgvFunciones.RowHeadersWidth = 51;
            dgvFunciones.RowTemplate.Height = 29;
            dgvFunciones.Size = new Size(644, 195);
            dgvFunciones.TabIndex = 2;
            dgvFunciones.CellContentClick += dgvFunciones_CellContentClick;
            // 
            // colPelicula
            // 
            colPelicula.HeaderText = "Pelicula";
            colPelicula.MinimumWidth = 6;
            colPelicula.Name = "colPelicula";
            colPelicula.SortMode = DataGridViewColumnSortMode.NotSortable;
            colPelicula.Width = 200;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha y Hora";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.SortMode = DataGridViewColumnSortMode.NotSortable;
            colFecha.Width = 95;
            // 
            // colFormato
            // 
            colFormato.HeaderText = "Formato";
            colFormato.MinimumWidth = 6;
            colFormato.Name = "colFormato";
            colFormato.SortMode = DataGridViewColumnSortMode.NotSortable;
            colFormato.Width = 85;
            // 
            // colSala
            // 
            colSala.HeaderText = "Sala";
            colSala.MinimumWidth = 6;
            colSala.Name = "colSala";
            colSala.SortMode = DataGridViewColumnSortMode.NotSortable;
            colSala.Width = 85;
            // 
            // colAcciones
            // 
            colAcciones.HeaderText = "Acciones";
            colAcciones.MinimumWidth = 6;
            colAcciones.Name = "colAcciones";
            colAcciones.Width = 125;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(672, 346);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(82, 22);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(28, 28, 28);
            label1.Location = new Point(45, 303);
            label1.Name = "label1";
            label1.Size = new Size(651, 15);
            label1.TabIndex = 11;
            label1.Text = "Aclaración: Seleccione 2 fechas para filtrar funciones, luego haga click en \"Comprar\" para ingresar a la pantalla de compra.";
            // 
            // FrmSeleccionFuncion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(766, 367);
            Controls.Add(btnSalir);
            Controls.Add(groupBox2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmSeleccionFuncion";
            Text = "Seleccion de Funcion";
            Load += FrmSeleccionFuncion_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFunciones).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox2;
        private DateTimePicker dtpFechaDesde;
        private Label lblFechaHasta;
        private Label lblFecha;
        private DataGridView dgvFunciones;
        private Button btnSalir;
        private Button btnLimpiarFiltros;
        private Button btnFiltrar;
        private DateTimePicker dtpFechaHasta;
        private DataGridViewTextBoxColumn colPelicula;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colFormato;
        private DataGridViewTextBoxColumn colSala;
        private DataGridViewButtonColumn colAcciones;
        private Label label1;
    }
}