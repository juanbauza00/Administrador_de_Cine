using TPI_Cine_Frontend.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using TPI_Backend.Entidades;
using TPI_Cine_Frontend.HTTP;
using System.Diagnostics;
using static System.Net.WebRequestMethods;
using System.ComponentModel.Design;

namespace TPI_Cine_Frontend
{
    public partial class FrmConsultarCliente : Form

    {
        List<Cliente> listaClientes = new List<Cliente>();
        public FrmConsultarCliente()
        {
            InitializeComponent();

        }

        private void FrmConsultarCliente_Load(object sender, EventArgs e)
        {
            TemasColores.ViewClientConsult(this, Color.WhiteSmoke, FormBorderStyle.Fixed3D);
            dgvClientes.AllowUserToAddRows = false;
            checkFilter.Checked = true;
        }
        private void btnConsultar_Click_1(object sender, EventArgs e)
        {



            if (checkFilter.Checked)
            {
                if (dtpDesde.Value > dtpHasta.Value)
                {
                    MessageBox.Show("Periodo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string fecDesde = Uri.EscapeDataString(dtpDesde.Value.ToString("yyyy/MM/dd"));
                string fecHasta = Uri.EscapeDataString(dtpHasta.Value.ToString("yyyy/MM/dd"));
                LoadClientsWithParam(fecDesde, fecHasta);
            }
            else
            {
                LoadClientsNoParam();
            }
        }

        private async void LoadClientsNoParam()
        {
            string url = "https://localhost:7282/api/Cliente/Clientes_no_param";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Cliente>>(result);
            dgvClientes.Rows.Clear();
            listaClientes.Clear();
            listaClientes = lst;
            foreach (Cliente cliente in listaClientes)
            {
                dgvClientes.Rows.Add(
                    cliente.Nombre, cliente.Apellido, cliente.Documento, "Modificar", "Eliminar");
            }

        }

        private async void LoadClientsWithParam(string fecha_desde, string fecha_hasta)
        {

            string url = String.Format("https://localhost:7282/api/Cliente/Clientes?fecha_desde={0}&fecha_hasta={1}", fecha_desde, fecha_hasta);
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Cliente>>(result);
            dgvClientes.Rows.Clear();
            listaClientes.Clear();
            listaClientes = lst;
            foreach (Cliente cliente in listaClientes)
            {
                dgvClientes.Rows.Add(
                    cliente.Nombre, cliente.Apellido, cliente.Documento, "Modificar", "Eliminar");
            }


        }



        private void gpClientConsult_Enter(object sender, EventArgs e)
        {

        }

        private async void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // cada cliente en el DGV proviene de la listaClientes
            //por lo tanto los index coinciden
            Cliente clienteSeleccinado = listaClientes[dgvClientes.CurrentCell.RowIndex];
            if (dgvClientes.CurrentCell.ColumnIndex == 3)
            {
                new FrmActualizarCliente(clienteSeleccinado).ShowDialog();

            }
            if (dgvClientes.CurrentCell.ColumnIndex == 4)
            {
                string url = string.Format("https://localhost:7282/TieneTicket?idCliente={0}", clienteSeleccinado.IdCliente);
                var result = await ClientSingleton.GetInstance().GetAsync(url);

                int tieneTicket = int.Parse(result);

                if (tieneTicket == 1)
                {
                    MessageBox.Show("No se puede eliminar ese cliente porque figura en al menos un ticket", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    url = string.Format("https://localhost:7282/api/Cliente/DeleteCliente?idcliente={0}", clienteSeleccinado.IdCliente);
                    result = await ClientSingleton.GetInstance().DeleteAsync(url);

                    bool success = Convert.ToBoolean(result);
                    if (success)
                    {
                        MessageBox.Show("El cliente fue eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No pudo eliminarse el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dgvClientes.Rows.RemoveAt(dgvClientes.CurrentCell.RowIndex);
                }

            }
        }

        private void checkFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkFilter.Checked)
            {
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
            }
            else
            {
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
            }
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
