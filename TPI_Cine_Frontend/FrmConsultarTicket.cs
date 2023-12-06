using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_Backend.Entidades;
using TPI_Cine_Frontend.HTTP;
using static System.Net.WebRequestMethods;

namespace TPI_Cine_Frontend
{
    public partial class FrmConsultarTicket : Form
    {
        private List<Ticket> listaTickets;
        public FrmConsultarTicket()
        {
            listaTickets = new List<Ticket>();
            InitializeComponent();
        }

        private void FrmConsultarTicket_Load(object sender, EventArgs e)
        {
            checkFiltrar.Checked = false;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;

        }


        private async Task CargarTicketsAsync()
        {
            listaTickets.Clear();
            if (checkFiltrar.Checked)
            {
                String fecDesde, fecHasta;
                fecDesde = Uri.EscapeDataString(dtpDesde.Value.ToString("yyyy/MM/dd"));
                fecHasta = Uri.EscapeDataString(dtpHasta.Value.ToString("yyyy/MM/dd"));
                string url = String.Format("https://localhost:7282/TicketsConParam?fechaDesde={0}&fechaHasta={1}", fecDesde, fecHasta); //COMPLETAR GET TICKETS

                var result = await ClientSingleton.GetInstance().GetAsync(url);
                var lst = JsonConvert.DeserializeObject<List<Ticket>>(result);
                listaTickets = lst;
            }
            else
            {
                string url = "https://localhost:7282/Tickets"; //COMPLETAR GET TICKETS
                var result = await ClientSingleton.GetInstance().GetAsync(url);
                var lst = JsonConvert.DeserializeObject<List<Ticket>>(result);
                listaTickets = lst;
            }

            dgvTickets.Rows.Clear();

            if (listaTickets != null)
            {
                foreach (Ticket t in listaTickets)
                {
                    dgvTickets.Rows.Add(new object[] {
                        t.Fecha,
                        t.ClienteTicket.ToString(),
                        t.FormaPago,
                        parseEstadoTicket(t.Pagado),
                        "Modificar",
                        "Borrar"
                    });
                }
            }
            else
            {
                MessageBox.Show("Sin datos de funciones para las fechas ingresadas", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }

        private string parseEstadoTicket(int estado)
        {
            if (estado == 1)
            {
                return "Pagado";
            }
            else
            {
                return "No pagado";
            }
        }
        private async void dgvConsultarTickets_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            // cada ticket en el DGV proviene de la listaTickets
            //por lo tanto los index coinciden
            Ticket ticketSeleccinado = listaTickets[dgvTickets.CurrentCell.RowIndex];

            //BOTON MODIFICAR
            if (dgvTickets.CurrentCell.ColumnIndex == 4)
            {
                Funcion funcionDelTicket;
                string url = string.Format("https://localhost:7282/api/Funcion/FuncionesIdFuncionButaca?idFuncionButaca={0}", ticketSeleccinado.Detalle[0].Butaca.IdFuncionButaca);
                //Solicitar funcion del ticket  {    linea de abajo   } //COMPLETAR GET FUCCION CON IdDetalleTicket
                var result = await ClientSingleton.GetInstance().GetAsync(url);
                var resultJSON = JsonConvert.DeserializeObject<Funcion>(result);
                Funcion funcion = resultJSON;
                new FrmActualizarTicket(funcion, ticketSeleccinado).ShowDialog();
                CargarTicketsAsync();


            }

            //BOTON ELIMINAR
            if (dgvTickets.CurrentCell.ColumnIndex == 5)
            {
                DialogResult = MessageBox.Show("Esta seguro/a que quiere borrar este ticket?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    string url = string.Format("https://localhost:7282/api/Ticket/DeleteTicket?idTicket={0}", ticketSeleccinado.NroTicket); // COMPLETAR ELIMINAR TICKET
                    var result = await ClientSingleton.GetInstance().DeleteAsync(url);

                    bool success = Convert.ToBoolean(result);
                    if (success)
                    {
                        MessageBox.Show("El ticket fue eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No pudo eliminarse el ticket", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dgvTickets.Rows.RemoveAt(dgvTickets.CurrentCell.RowIndex);
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarTicketsAsync();
        }

        private void checkFiltrar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFiltrar.Enabled)
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
