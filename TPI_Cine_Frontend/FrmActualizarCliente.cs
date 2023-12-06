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
using TPI_Cine_Frontend.HTTP;

namespace TPI_Cine_Frontend
{
    public partial class FrmActualizarCliente : Form
    {
        Cliente client = new Cliente();
        public FrmActualizarCliente(Cliente clienteAModificar)
        {
            client = clienteAModificar;
            InitializeComponent();
        }

        private async void btnCargarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || int.TryParse(txtNombre.Text, out _))
            {
                MessageBox.Show("Debe ingresar un nombre correcto", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Clear();
                return;
            }
            if (string.IsNullOrEmpty(txtApellido.Text) || int.TryParse(txtApellido.Text, out _))
            {
                MessageBox.Show("Debe ingresar un apellido correcto", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApellido.Clear();
                return;
            }
            if (cboTipoDoc.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!int.TryParse(txtDNI.Text, out _) || txtDNI.Text.Length < 4)
            {
                MessageBox.Show("Debe ingresar el dni correctamente", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDNI.Clear();
                return;
            }
            await UpdateClienteAsync();
        }

        private void FrmActualizarCliente_Load(object sender, EventArgs e)
        {
            LoadTipoDocu();
            txtApellido.Enabled = false;
            txtNombre.Enabled = false;
            txtDNI.Enabled = false;
            cboTipoDoc.Enabled = false;

            txtNombre.Text = client.Nombre;
            txtApellido.Text = client.Apellido;
            cboTipoDoc.SelectedItem = client.TipoDocumento;
            txtDNI.Text = client.Documento.ToString();
        }

        private async void LoadTipoDocu()
        {
            string url = "https://localhost:7282/api/Cliente/tiposDocumentos";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<tipoDocumentoCliente>>(result);
            cboTipoDoc.DataSource = lst;
            cboTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seguro que quieres salir?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                return;
            }
        }

        private async Task UpdateClienteAsync()
        {
            client.IdCliente = client.IdCliente;
            client.Nombre = txtNombre.Text;
            client.Apellido = txtApellido.Text;
            client.TipoDocumento = (tipoDocumentoCliente)cboTipoDoc.SelectedItem;
            client.Documento = Convert.ToInt32(txtDNI.Text);
            string bodyContent = JsonConvert.SerializeObject(client);

            string url = "https://localhost:7282/api/Cliente/Cliente"; //CAMBIO 1
            var result = await ClientSingleton.GetInstance().PutAsync(url, bodyContent);

            if (result.Equals("true"))
            {
                MessageBox.Show("El cliente se actualizo correctamente", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("El cliente NO se pudo actualizar correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtApellido.Enabled = true;
            txtNombre.Enabled = true;
            txtDNI.Enabled = true;
            cboTipoDoc.Enabled = true;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}
