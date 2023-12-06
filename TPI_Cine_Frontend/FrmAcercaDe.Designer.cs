namespace TPI_Cine_Frontend
{
    partial class FrmAcercaDe
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(165, 9);
            label1.Name = "label1";
            label1.Size = new Size(420, 20);
            label1.TabIndex = 0;
            label1.Text = "Programacion II - Trabajo Practico Integrador";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(30, 61);
            label2.Name = "label2";
            label2.Size = new Size(198, 25);
            label2.TabIndex = 1;
            label2.Text = "Integrantes del grupo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Silver;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(28, 96);
            label3.Name = "label3";
            label3.Size = new Size(191, 21);
            label3.TabIndex = 2;
            label3.Text = " 404994 Bauza Juan Pablo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Silver;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(30, 131);
            label4.Name = "label4";
            label4.Size = new Size(189, 21);
            label4.TabIndex = 3;
            label4.Text = "406030 Consigli  Santino ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Silver;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(30, 168);
            label5.Name = "label5";
            label5.Size = new Size(246, 21);
            label5.TabIndex = 4;
            label5.Text = "404874 Rearte Ariza César Rafael ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Silver;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(30, 202);
            label6.Name = "label6";
            label6.Size = new Size(193, 21);
            label6.TabIndex = 5;
            label6.Text = "405067 Solis Luna Ignacio";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Silver;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(30, 239);
            label7.Name = "label7";
            label7.Size = new Size(230, 20);
            label7.TabIndex = 6;
            label7.Text = "405865 Ontivero David Alejandro";
            // 
            // FrmAcercaDe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.UTN_logo;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(737, 345);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "FrmAcercaDe";
            Text = "Acerca de";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}