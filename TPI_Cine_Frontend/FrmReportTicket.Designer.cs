namespace TPI_Cine_Frontend
{
    partial class FrmReportTicket
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
            RVReporte = new Microsoft.Reporting.WinForms.ReportViewer();
            label1 = new Label();
            label2 = new Label();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            RbtGenerar = new Button();
            rbtSalir = new Button();
            SuspendLayout();
            // 
            // RVReporte
            // 
            RVReporte.Location = new Point(12, 79);
            RVReporte.Name = "ReportViewer";
            RVReporte.ServerReport.BearerToken = null;
            RVReporte.Size = new Size(684, 290);
            RVReporte.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 1;
            label1.Text = "Fecha Desde:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(300, 32);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 2;
            label2.Text = "Fecha Hasta:";
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(94, 26);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(200, 23);
            dtpDesde.TabIndex = 0;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(380, 26);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(200, 23);
            dtpHasta.TabIndex = 3;
            // 
            // RbtGenerar
            // 
            RbtGenerar.Location = new Point(607, 24);
            RbtGenerar.Name = "RbtGenerar";
            RbtGenerar.Size = new Size(75, 23);
            RbtGenerar.TabIndex = 4;
            RbtGenerar.Text = "Generar";
            RbtGenerar.UseVisualStyleBackColor = true;
            RbtGenerar.Click += RbtGenerar_Click;
            // 
            // rbtSalir
            // 
            rbtSalir.Location = new Point(619, 381);
            rbtSalir.Name = "rbtSalir";
            rbtSalir.Size = new Size(75, 23);
            rbtSalir.TabIndex = 5;
            rbtSalir.Text = "Salir";
            rbtSalir.UseVisualStyleBackColor = true;
            rbtSalir.Click += rbtSalir_Click;
            // 
            // FrmReportTicket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(716, 416);
            Controls.Add(rbtSalir);
            Controls.Add(RbtGenerar);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(RVReporte);
            Name = "FrmReportTicket";
            Text = "Reporte Tickets";
            Load += FrmReportTicket_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RVReporte;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button RbtGenerar;
        private Button rbtSalir;
    }
}