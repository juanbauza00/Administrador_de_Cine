namespace TPI_Cine_Frontend
{
    partial class FrmSeleccionButacas
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
            grpSalaCine = new GroupBox();
            txtPantalla = new TextBox();
            btnF2C3 = new Button();
            btnF2C2 = new Button();
            btnF2C1 = new Button();
            btnF1C3 = new Button();
            btnF1C2 = new Button();
            btnF1C1 = new Button();
            btnAceptar = new Button();
            grpSalaCine.SuspendLayout();
            SuspendLayout();
            // 
            // grpSalaCine
            // 
            grpSalaCine.BackColor = Color.FromArgb(0, 0, 64);
            grpSalaCine.Controls.Add(txtPantalla);
            grpSalaCine.Controls.Add(btnF2C3);
            grpSalaCine.Controls.Add(btnF2C2);
            grpSalaCine.Controls.Add(btnF2C1);
            grpSalaCine.Controls.Add(btnF1C3);
            grpSalaCine.Controls.Add(btnF1C2);
            grpSalaCine.Controls.Add(btnF1C1);
            grpSalaCine.ForeColor = SystemColors.ControlLightLight;
            grpSalaCine.Location = new Point(10, 9);
            grpSalaCine.Margin = new Padding(3, 2, 3, 2);
            grpSalaCine.Name = "grpSalaCine";
            grpSalaCine.Padding = new Padding(3, 2, 3, 2);
            grpSalaCine.Size = new Size(287, 224);
            grpSalaCine.TabIndex = 0;
            grpSalaCine.TabStop = false;
            grpSalaCine.Text = "Sala Cine";
            // 
            // txtPantalla
            // 
            txtPantalla.BackColor = SystemColors.InactiveCaption;
            txtPantalla.Location = new Point(24, 20);
            txtPantalla.Margin = new Padding(3, 2, 3, 2);
            txtPantalla.Name = "txtPantalla";
            txtPantalla.Size = new Size(239, 23);
            txtPantalla.TabIndex = 6;
            txtPantalla.Text = "PANTALLA";
            txtPantalla.TextAlign = HorizontalAlignment.Center;
            // 
            // btnF2C3
            // 
            btnF2C3.Image = Properties.Resources.butaca;
            btnF2C3.Location = new Point(211, 156);
            btnF2C3.Margin = new Padding(3, 2, 3, 2);
            btnF2C3.Name = "btnF2C3";
            btnF2C3.Size = new Size(43, 35);
            btnF2C3.TabIndex = 5;
            btnF2C3.UseVisualStyleBackColor = true;
            // 
            // btnF2C2
            // 
            btnF2C2.Image = Properties.Resources.butaca;
            btnF2C2.Location = new Point(122, 156);
            btnF2C2.Margin = new Padding(3, 2, 3, 2);
            btnF2C2.Name = "btnF2C2";
            btnF2C2.Size = new Size(43, 35);
            btnF2C2.TabIndex = 4;
            btnF2C2.UseVisualStyleBackColor = true;
            // 
            // btnF2C1
            // 
            btnF2C1.Image = Properties.Resources.butaca;
            btnF2C1.Location = new Point(32, 156);
            btnF2C1.Margin = new Padding(3, 2, 3, 2);
            btnF2C1.Name = "btnF2C1";
            btnF2C1.Size = new Size(43, 35);
            btnF2C1.TabIndex = 3;
            btnF2C1.UseVisualStyleBackColor = true;
            // 
            // btnF1C3
            // 
            btnF1C3.Image = Properties.Resources.butaca;
            btnF1C3.Location = new Point(211, 94);
            btnF1C3.Margin = new Padding(3, 2, 3, 2);
            btnF1C3.Name = "btnF1C3";
            btnF1C3.Size = new Size(43, 35);
            btnF1C3.TabIndex = 2;
            btnF1C3.UseVisualStyleBackColor = true;
            // 
            // btnF1C2
            // 
            btnF1C2.Image = Properties.Resources.butaca;
            btnF1C2.Location = new Point(122, 94);
            btnF1C2.Margin = new Padding(3, 2, 3, 2);
            btnF1C2.Name = "btnF1C2";
            btnF1C2.Size = new Size(43, 35);
            btnF1C2.TabIndex = 1;
            btnF1C2.UseVisualStyleBackColor = true;
            // 
            // btnF1C1
            // 
            btnF1C1.Image = Properties.Resources.butaca;
            btnF1C1.Location = new Point(32, 94);
            btnF1C1.Margin = new Padding(3, 2, 3, 2);
            btnF1C1.Name = "btnF1C1";
            btnF1C1.Size = new Size(43, 35);
            btnF1C1.TabIndex = 0;
            btnF1C1.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(215, 237);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(82, 22);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FrmSeleccionButacas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(308, 268);
            Controls.Add(btnAceptar);
            Controls.Add(grpSalaCine);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmSeleccionButacas";
            Text = "Seleccion de Butacas";
            Load += FrmSeleccionButacas_Load;
            grpSalaCine.ResumeLayout(false);
            grpSalaCine.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpSalaCine;
        private Button btnF1C1;
        private Button btnAceptar;
        private Button btnF2C3;
        private Button btnF2C2;
        private Button btnF2C1;
        private Button btnF1C3;
        private Button btnF1C2;
        private TextBox txtPantalla;
    }
}