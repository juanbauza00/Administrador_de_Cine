namespace TPI_Cine_Frontend
{
    partial class FrmConsultarFuncion
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
            dgvConsultarFunciones = new DataGridView();
            ColPelicula = new DataGridViewTextBoxColumn();
            ColFechaHora = new DataGridViewTextBoxColumn();
            ColFormato = new DataGridViewTextBoxColumn();
            ColSala = new DataGridViewTextBoxColumn();
            colEditar = new DataGridViewButtonColumn();
            ColBorrar = new DataGridViewButtonColumn();
            gpClientConsult = new GroupBox();
            checkFiltrar = new CheckBox();
            btnConsultar = new Button();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvConsultarFunciones).BeginInit();
            gpClientConsult.SuspendLayout();
            SuspendLayout();
            // 
            // dgvConsultarFunciones
            // 
            dgvConsultarFunciones.AllowUserToAddRows = false;
            dgvConsultarFunciones.AllowUserToDeleteRows = false;
            dgvConsultarFunciones.BackgroundColor = SystemColors.ActiveBorder;
            dgvConsultarFunciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultarFunciones.Columns.AddRange(new DataGridViewColumn[] { ColPelicula, ColFechaHora, ColFormato, ColSala, colEditar, ColBorrar });
            dgvConsultarFunciones.Location = new Point(21, 123);
            dgvConsultarFunciones.Name = "dgvConsultarFunciones";
            dgvConsultarFunciones.ReadOnly = true;
            dgvConsultarFunciones.RowTemplate.Height = 25;
            dgvConsultarFunciones.Size = new Size(659, 205);
            dgvConsultarFunciones.TabIndex = 9;
            dgvConsultarFunciones.CellContentClick += dgvConsultarFunciones_CellContentClick;
            // 
            // ColPelicula
            // 
            ColPelicula.HeaderText = "Pelicula";
            ColPelicula.Name = "ColPelicula";
            ColPelicula.ReadOnly = true;
            ColPelicula.Width = 115;
            // 
            // ColFechaHora
            // 
            ColFechaHora.HeaderText = "Fecha_Hora";
            ColFechaHora.Name = "ColFechaHora";
            ColFechaHora.ReadOnly = true;
            // 
            // ColFormato
            // 
            ColFormato.HeaderText = "Formato";
            ColFormato.Name = "ColFormato";
            ColFormato.ReadOnly = true;
            // 
            // ColSala
            // 
            ColSala.HeaderText = "Sala";
            ColSala.Name = "ColSala";
            ColSala.ReadOnly = true;
            // 
            // colEditar
            // 
            colEditar.HeaderText = "Editar";
            colEditar.Name = "colEditar";
            colEditar.ReadOnly = true;
            colEditar.Resizable = DataGridViewTriState.True;
            colEditar.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // ColBorrar
            // 
            ColBorrar.HeaderText = "Borrar";
            ColBorrar.Name = "ColBorrar";
            ColBorrar.ReadOnly = true;
            // 
            // gpClientConsult
            // 
            gpClientConsult.BackColor = SystemColors.ActiveCaption;
            gpClientConsult.Controls.Add(checkFiltrar);
            gpClientConsult.Controls.Add(btnConsultar);
            gpClientConsult.Controls.Add(dtpHasta);
            gpClientConsult.Controls.Add(dtpDesde);
            gpClientConsult.Location = new Point(21, 22);
            gpClientConsult.Name = "gpClientConsult";
            gpClientConsult.Size = new Size(659, 83);
            gpClientConsult.TabIndex = 8;
            gpClientConsult.TabStop = false;
            gpClientConsult.Text = "Filtros de busqueda";
            // 
            // checkFiltrar
            // 
            checkFiltrar.AutoSize = true;
            checkFiltrar.Location = new Point(27, 22);
            checkFiltrar.Name = "checkFiltrar";
            checkFiltrar.Size = new Size(56, 19);
            checkFiltrar.TabIndex = 5;
            checkFiltrar.Text = "Filtrar";
            checkFiltrar.UseVisualStyleBackColor = true;
            checkFiltrar.CheckedChanged += checkFiltrar_CheckedChanged;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(241, 49);
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
            dtpHasta.Location = new Point(141, 47);
            dtpHasta.Margin = new Padding(4, 3, 4, 3);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(93, 23);
            dtpHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(27, 47);
            dtpDesde.Margin = new Padding(4, 3, 4, 3);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(93, 23);
            dtpDesde.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(598, 333);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmConsultarFuncion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(697, 358);
            Controls.Add(btnCancelar);
            Controls.Add(dgvConsultarFunciones);
            Controls.Add(gpClientConsult);
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmConsultarFuncion";
            Text = "Consultar Funciones";
            Load += FrmConsultarFuncion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsultarFunciones).EndInit();
            gpClientConsult.ResumeLayout(false);
            gpClientConsult.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultarFunciones;
        private GroupBox gpClientConsult;
        private Button btnConsultar;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private Button btnCancelar;
        private DataGridViewTextBoxColumn ColPelicula;
        private DataGridViewTextBoxColumn ColFechaHora;
        private DataGridViewTextBoxColumn ColFormato;
        private DataGridViewTextBoxColumn ColSala;
        private DataGridViewButtonColumn colEditar;
        private DataGridViewButtonColumn ColBorrar;
        private CheckBox checkFiltrar;
    }
}