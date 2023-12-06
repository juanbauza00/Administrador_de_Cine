namespace TPI_Cine_Frontend
{
    partial class FrmConsultarCliente
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
            gpClientConsult = new GroupBox();
            checkFilter = new CheckBox();
            btnConsultar = new Button();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            dgvClientes = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            ColModificar = new DataGridViewButtonColumn();
            ColEliminar = new DataGridViewButtonColumn();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            gpClientConsult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // gpClientConsult
            // 
            gpClientConsult.BackColor = SystemColors.ActiveCaption;
            gpClientConsult.Controls.Add(label3);
            gpClientConsult.Controls.Add(label2);
            gpClientConsult.Controls.Add(checkFilter);
            gpClientConsult.Controls.Add(btnConsultar);
            gpClientConsult.Controls.Add(dtpHasta);
            gpClientConsult.Controls.Add(dtpDesde);
            gpClientConsult.Location = new Point(12, 12);
            gpClientConsult.Name = "gpClientConsult";
            gpClientConsult.Size = new Size(543, 95);
            gpClientConsult.TabIndex = 6;
            gpClientConsult.TabStop = false;
            gpClientConsult.Text = "Filtros de busqueda";
            gpClientConsult.Enter += gpClientConsult_Enter;
            // 
            // checkFilter
            // 
            checkFilter.AutoSize = true;
            checkFilter.Location = new Point(361, 18);
            checkFilter.Name = "checkFilter";
            checkFilter.Size = new Size(56, 19);
            checkFilter.TabIndex = 5;
            checkFilter.Text = "Filtrar";
            checkFilter.UseVisualStyleBackColor = true;
            checkFilter.CheckedChanged += checkFilter_CheckedChanged;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(361, 46);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(75, 23);
            btnConsultar.TabIndex = 4;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click_1;
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(182, 44);
            dtpHasta.Margin = new Padding(4, 3, 4, 3);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(93, 23);
            dtpHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(17, 44);
            dtpDesde.Margin = new Padding(4, 3, 4, 3);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(93, 23);
            dtpDesde.TabIndex = 2;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, ColModificar, ColEliminar });
            dgvClientes.Location = new Point(12, 142);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowTemplate.Height = 25;
            dgvClientes.Size = new Size(543, 227);
            dgvClientes.TabIndex = 7;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Apellido";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "DNI";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // ColModificar
            // 
            ColModificar.HeaderText = "Modificar";
            ColModificar.Name = "ColModificar";
            // 
            // ColEliminar
            // 
            ColEliminar.HeaderText = "Eliminar";
            ColEliminar.Name = "ColEliminar";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(473, 374);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(28, 28, 28);
            label1.Location = new Point(31, 124);
            label1.Name = "label1";
            label1.Size = new Size(502, 15);
            label1.TabIndex = 14;
            label1.Text = "Aclaración: Al filtrar se busca los clientes que compraron tickets entre las fechas seleccionadas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 19);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 6;
            label2.Text = "Fecha desde: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(182, 19);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 7;
            label3.Text = "Fecha hasta: ";
            // 
            // FrmConsultarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(572, 402);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(dgvClientes);
            Controls.Add(gpClientConsult);
            Name = "FrmConsultarCliente";
            Text = "Consultar Clientes";
            Load += FrmConsultarCliente_Load;
            gpClientConsult.ResumeLayout(false);
            gpClientConsult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gpClientConsult;
        private Button btnConsultar;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private DataGridView dgvClientes;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewButtonColumn ColModificar;
        private DataGridViewButtonColumn ColEliminar;
        private CheckBox checkFilter;
        private Button btnCancelar;
        private Label label1;
        private Label label3;
        private Label label2;
    }
}