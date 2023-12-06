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
using TPI_Backend.Entidades;
using TPI_Cine_Frontend.HTTP;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static TPI_Backend.Entidades.Cliente;
using static TPI_Backend.Entidades.Ticket;

namespace TPI_Cine_Frontend
{
    public partial class FrmActualizarTicket : Form
    {
        Funcion funcion;
        Ticket ticket;
        List<Cliente> listaClientes = new List<Cliente>();
        public FrmActualizarTicket(Funcion funcion, Ticket ticket)
        {
            InitializeComponent();
            this.funcion = funcion;
            this.ticket = ticket;
        }

        private void FrmActualizarTicket_Load(object sender, EventArgs e)
        {
            txtCodigoTicket.Enabled = false;
            txtCodigoTicket.Text = ticket.NroTicket.ToString();
            cboCliente.Enabled = false;
            cboPagado.Enabled = false;
            dtpFecha.Enabled = false;
            cboFormaPago.Enabled = false;


            CargarEstado();

            CargarFormasPago();
            CargarClientesAsync();

        }

        private void CargarEstado()
        {
            List<string> estados = new List<string>();
            estados.Add("No pagado");
            estados.Add("Pagado");
            cboPagado.DataSource = estados;
            cboPagado.SelectedIndex = 0;
            cboPagado.SelectedIndexChanged += cboPagado_SelectedIndexChanged;
            cboPagado.SelectedIndex = ticket.Pagado;
        }
        private async Task CargarClientesAsync()
        {
            string url = "https://localhost:7282/api/Cliente/Clientes_no_param";

            try
            {
                var result = await ClientSingleton.GetInstance().GetAsync(url);
                var clientes = JsonConvert.DeserializeObject<List<Cliente>>(result);

                listaClientes.Clear();
                listaClientes = clientes;

                cboCliente.DataSource = null;
                cboCliente.DataSource = listaClientes;


                if (ticket != null)
                {
                    cboCliente.SelectedItem = ticket.ClienteTicket;
                }

                int conteo = 0;
                foreach (Cliente c in listaClientes)
                {
                    if (c.IdCliente == ticket.ClienteTicket.IdCliente)
                    {
                        break;
                    }
                    conteo++;
                }
                cboCliente.SelectedIndex = conteo;
            }
            catch (Exception ex)
            {
                // Manejar la excepción de alguna manera
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarFormasPago()
        {
            FormaPagoTicket[] formasPagoArray = (FormaPagoTicket[])Enum.GetValues(typeof(FormaPagoTicket));

            cboFormaPago.DataSource = formasPagoArray;
            cboFormaPago.DisplayMember = "ToString";
            cboFormaPago.DisplayMember = ticket.FormaPago.ToString();
            cboFormaPago.SelectedItem = ticket.FormaPago;



        }
        private void gpActualizarTicket_Enter(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cboCliente.Enabled = true;
            cboFormaPago.Enabled = true;
            if (ticket.Pagado == 0)
            {
                cboPagado.Enabled = true;
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            ticket.ClienteTicket = (Cliente)cboCliente.SelectedItem;
            ticket.FormaPago = (FormaPagoTicket)cboFormaPago.SelectedItem;
            Debug.Write(cboPagado.SelectedIndex);

            ticket.Pagado = cboPagado.SelectedIndex;


            string url = "https://localhost:7282/ticket";
            string bodyContent = JsonConvert.SerializeObject(ticket);

            var result = await ClientSingleton.GetInstance().PutAsync(url, bodyContent);
            if (result.Equals("true"))
            {
                MessageBox.Show("El ticket se actualizo con exito", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("El ticket no pudo ser actualizado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cboPagado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
