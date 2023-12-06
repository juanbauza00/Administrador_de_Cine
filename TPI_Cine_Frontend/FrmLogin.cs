using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TPI_Backend.Datos;
using TPI_Backend.Entidades;
using TPI_Cine_Frontend.HTTP;

namespace TPI_Cine_Frontend
{
    public partial class FrmLogin : Form
    {
        string validatedString;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

            cargarComboGerentes();
            txtPassword.Enabled = false;
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Convert.ToInt32(validatedString) != 1)
            {
                MessageBox.Show("Debe iniciar sesion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Cancel = true;
            }
        }

        private async void cargarComboGerentes()
        {
            string url = "https://localhost:7282/gerentes";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var jsonGerente = JsonConvert.DeserializeObject<List<Gerente>>(result);
            List<Gerente> listaGerente = jsonGerente;
            cboGerentes.DataSource = listaGerente;
            cboGerentes.DisplayMember = "email";
            cboGerentes.ValueMember = "email";
            cboGerentes.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPassword.Enabled = true;
            lblCargando.Text = "";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Ingrese una contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string email = cboGerentes.GetItemText(cboGerentes.SelectedItem);
                string password = txtPassword.Text;
                string url = string.Format("https://localhost:7282/gerentes/validar?email={0}&password={1}", email, password);
                var validated = await ClientSingleton.GetInstance().GetAsync(url);

                validatedString = validated;

                if (Convert.ToInt32(validatedString) == 1)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta");
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
