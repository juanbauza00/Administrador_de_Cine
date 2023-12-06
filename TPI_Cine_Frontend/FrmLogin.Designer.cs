namespace TPI_Cine_Frontend
{
    partial class FrmLogin
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
            cboGerentes = new ComboBox();
            txtPassword = new TextBox();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            lblCargando = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cboGerentes
            // 
            cboGerentes.FormattingEnabled = true;
            cboGerentes.Location = new Point(70, 195);
            cboGerentes.Name = "cboGerentes";
            cboGerentes.Size = new Size(171, 23);
            cboGerentes.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(70, 253);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(171, 23);
            txtPassword.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(123, 295);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Ingresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.login_size;
            pictureBox1.Location = new Point(80, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(161, 161);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lblCargando
            // 
            lblCargando.AutoSize = true;
            lblCargando.Location = new Point(120, 228);
            lblCargando.Name = "lblCargando";
            lblCargando.Size = new Size(68, 15);
            lblCargando.TabIndex = 4;
            lblCargando.Text = "Cargando...";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 341);
            Controls.Add(lblCargando);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(txtPassword);
            Controls.Add(cboGerentes);
            Name = "FrmLogin";
            Text = "Login";
            FormClosing += FrmLogin_FormClosing;
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboGerentes;
        private TextBox txtPassword;
        private Button button1;
        private PictureBox pictureBox1;
        private Label lblCargando;
    }
}