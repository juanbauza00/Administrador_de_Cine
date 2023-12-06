using TPI_Cine_Frontend.HTTP;
using TPI_Cine_Frontend.Presentacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TPI_Backend.Entidades.Cliente;
using TPI_Backend.Entidades;
using System.Diagnostics;

namespace TPI_Cine_Frontend
{
    public partial class FrmAltaCliente : Form
    {
        Cliente client = new Cliente();
        public FrmAltaCliente()
        {
            InitializeComponent();

        }

        private void FrmAltaCliente_Load(object sender, EventArgs e)
        {
            TemasColores.ViewClientConsult(this, Color.WhiteSmoke, FormBorderStyle.Fixed3D);
            LoadDocTypeAsync();
        }

        private async void LoadDocTypeAsync()
        {
            string url = "https://localhost:7282/api/Cliente/tiposDocumentos";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<tipoDocumentoCliente>>(result);
            cboTipoDocumento.DataSource = lst;
            //cboTipoDocumento.DisplayMember = "id_tipo_documento";
            //cboTipoDocumento.ValueMember = "tipo_documento";
            cboTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private async Task InsertClientAsync()
        {
            client.Nombre = txtNombre.Text;
            client.Apellido = txtApellido.Text;
            client.TipoDocumento = (tipoDocumentoCliente)cboTipoDocumento.SelectedItem;
            client.Documento = Convert.ToInt32(txtDni.Text);
            string bodyContent = JsonConvert.SerializeObject(client);

            string url = "https://localhost:7282/api/Cliente";
            var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);

            if (result.Equals("true"))
            {
                MessageBox.Show("El cliente se registro correctamente", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("El cliente NO se pudo registrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || int.TryParse(txtNombre.Text, out _))
            {
                MessageBox.Show("Debe ingresar el nombre correctamente", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Clear();
                return;
            }
            if (string.IsNullOrEmpty(txtApellido.Text) || int.TryParse(txtApellido.Text, out _))
            {
                MessageBox.Show("Debe ingresar el apellido correctamente", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApellido.Clear();
                return;
            }
            if (cboTipoDocumento.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!int.TryParse(txtDni.Text, out _) || txtDni.Text.Length < 4)
            {
                MessageBox.Show("Debe ingresar el dni correctamente", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDni.Clear();
                return;
            }

            await InsertClientAsync();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}
