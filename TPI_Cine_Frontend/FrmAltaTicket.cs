using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using TPI_Backend.Datos;
using TPI_Backend.Entidades;
using TPI_Cine_Frontend.HTTP;
using static TPI_Backend.Entidades.Cliente;
using static TPI_Backend.Entidades.Ticket;

namespace TPI_Cine_Frontend
{
    public partial class FrmAltaTicket : Form
    {
        private int ticketNro; //Atributo TicketNro
        private FrmSeleccionButacas frmButacas;
        public Funcion funcion { get; set; }
        public List<Butaca> ButacasFuncion { get; set; }
        public List<Butaca> ButacasSeleccionadas { get; set; }
        Ticket ticket;
        private List<FormaPagoTicket> formasPago;
        private Dictionary<int, double> descuento;
        private List<Cliente> listaClientes = new List<Cliente>();

        //decimal Precio_Unitario)> lDetalles = new List<(Dictionary<int, float>, decimal)>();
        // se utiliza una tupla para poder almacenar un conjunto de elementos
        // de diferentes tipos para un objeto


        //Constructor de ALTA TICKET
        public FrmAltaTicket(Funcion funcionSeleccionada)
        {
            funcion = funcionSeleccionada;
            ButacasFuncion = new List<Butaca>();
            formasPago = new List<FormaPagoTicket>();
            InitializeComponent();
        }

        //Constructor de MODIFICAR TICKET
        public FrmAltaTicket(Funcion funcionSeleccionada, Ticket oTicket)
        {
            ticket = oTicket;
            funcion = funcionSeleccionada;

            ButacasFuncion = new List<Butaca>();
            formasPago = new List<FormaPagoTicket>();
            InitializeComponent();
        }


        private void cboFormasPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmAltaDetallesTicket_Load(object sender, EventArgs e)
        {
            txtPelicula.Text = funcion.PeliculaFuncion.Nombre;

            //Load con modificacion
            if (ticket != null)
            {
                ButacasSeleccionadas = new List<Butaca>();
                foreach (DetalleTicket d in ticket.Detalle)
                {
                    ButacasSeleccionadas.Add(d.Butaca);
                }
                //----------------------------------------------------REVISAR!!!!!!!!!
                string butacaFilaColumna = "";
                foreach (Butaca bt in ButacasSeleccionadas)
                {
                    butacaFilaColumna += "F" + bt.Fila.ToString() + "C" + bt.Columna.ToString() + " ; ";
                }
                txtButacasSelec.Text = butacaFilaColumna;
            }

            CargarValores();
        }

        private async void CargarValores()
        {
            await CargarDescuentosAsync();
            await CargarButacasAsync();
            CargarFormasPago();
            await CargarClientesAsync();
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
                    cboCliente.SelectedValue = ticket.ClienteTicket;
                }
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

            cboFormasPago.DataSource = formasPagoArray;
            cboFormasPago.DisplayMember = "ToString";

            if (ticket != null)
            {
                cboFormasPago.DisplayMember = ticket.FormaPago.ToString();
            }

        }


        private async Task CargarButacasAsync()
        {
            string url = String.Format("https://localhost:7282/Butacas?id_funcion={0}", funcion.NroFuncion);

            try
            {
                var result = await ClientSingleton.GetInstance().GetAsync(url);
                var butacas = JsonConvert.DeserializeObject<List<Butaca>>(result);
                ButacasFuncion = butacas;

                int butacasDisponibles = ButacasFuncion.Count(but => but.Estado == Butaca.EstadoButaca.Desocupada);
                txtButacasDisponibles.Text = butacasDisponibles.ToString();
            }
            catch (Exception ex)
            {
                // Manejar la excepción de alguna manera
                MessageBox.Show($"Error al cargar butacas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async Task CargarDescuentosAsync()
        {
            string url = String.Format("https://localhost:7282/Descuentos?numero_semana={0}", (int)funcion.FechaHora.DayOfWeek);

            try
            {
                var result = await ClientSingleton.GetInstance().GetAsync(url);
                var descuentos = JsonConvert.DeserializeObject<Dictionary<int, double>>(result);

                descuento = descuentos;
                txtDescuento.Text = descuentos.First().Value.ToString() + " %";
            }
            catch (Exception ex)
            {
                // Manejar la excepción de alguna manera
                MessageBox.Show($"Error al cargar descuentos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //INSERTAR TICKET------------------------------------------------
        private async Task TaskInsertTicketAsync()
        {
            //Datos ticket
            ticket.ClienteTicket = (Cliente)cboCliente.SelectedItem;
            if (chkPagarAhora.Checked)
            {
                ticket.Pagado = 1;
            }
            else
            {
                ticket.Pagado = 0;
            }
            ticket.FormaPago = (FormaPagoTicket)cboFormasPago.SelectedItem;
            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;
            ticket.Fecha = fecha.Add(hora);

            string url = "https://localhost:7282/ticket";
            string bodyContent = JsonConvert.SerializeObject(ticket);
            var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);
            bool resultado = Convert.ToBoolean(result);
            if (resultado)
            {
                MessageBox.Show("El ticket registro correctamente", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("El ticket NO se pudo registrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //---------------------------------------------------------


        //Cargar Butacas
        private void btnButacas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidadButacas.Text))
            {
                MessageBox.Show("Debe colocar la cantidad de butacas que desea comprar", "Aviso", MessageBoxButtons.OK);
                return;
            }
            if (int.TryParse(txtCantidadButacas.Text, out int cantidadButacas) && int.TryParse(txtButacasDisponibles.Text, out int butacasDisponibles))
            {
                // Ahora, puedes comparar los valores enteros
                if (cantidadButacas > butacasDisponibles)
                {
                    MessageBox.Show("Seleccionó una cantidad de butacas mayor a la disponible", "Aviso", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos en ambos campos", "Aviso", MessageBoxButtons.OK);
                return;
            }
            if (int.Parse(txtCantidadButacas.Text) <= 0)
            {
                MessageBox.Show("Debe colocar una cantidad de butacas mayor a 0", "Aviso", MessageBoxButtons.OK);
                return;
            }

            else
            {
                //frmButacas se debe iniciar con el parametro de IdFuncion y con la Cantidad de butacas compradas
                frmButacas = new FrmSeleccionButacas(funcion.NroFuncion, int.Parse(txtCantidadButacas.Text), ButacasFuncion, ButacasSeleccionadas);
                DialogResult result = frmButacas.ShowDialog();

                if (result == DialogResult.OK)
                {
                    ButacasSeleccionadas = frmButacas.ObtenerButacasSeleccionadas();
                }

                string butacaFilaColumna = "";
                if (ButacasSeleccionadas == null)
                {
                    MessageBox.Show("No selecciono ninguna butaca", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (Butaca bt in ButacasSeleccionadas)
                {
                    butacaFilaColumna += "F" + bt.Fila.ToString() + "C" + bt.Columna.ToString() + " ; ";
                }
                txtButacasSelec.Text = butacaFilaColumna;
            }
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            //validaciones
            if (ticket != null)
            {
                int nroTicket = ticket.NroTicket;
                ticket = new Ticket();
                ticket.NroTicket = nroTicket;
                CrearDetalles();

                await TaskUpdateTicketAsync();
                return;
            }

            ticket = new Ticket();
            CrearDetalles();

            await TaskInsertTicketAsync();
        }

        //ACTUALIZAR TICKET----------------------------------------------
        private async Task TaskUpdateTicketAsync()
        {
            //Datos ticket
            ticket.ClienteTicket = (Cliente)cboCliente.SelectedItem;
            if (chkPagarAhora.Checked)
            {
                ticket.Pagado = 1;
            }
            else
            {
                ticket.Pagado = 0;
            }
            ticket.FormaPago = (FormaPagoTicket)cboFormasPago.SelectedItem;
            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;
            ticket.Fecha = fecha.Add(hora);



            string url = "";
            string bodyContent = JsonConvert.SerializeObject(ticket);
            var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);
            bool resultado = Convert.ToBoolean(result);
            if (resultado)
            {
                MessageBox.Show("El ticket actualizo correctamente", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("El ticket NO se pudo actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
        //---------------------------------------------------------

        private void CrearDetalles()
        {
            foreach (Butaca but in ButacasSeleccionadas)
            {
                DetalleTicket d = new DetalleTicket();
                d.Butaca = but;
                d.Precio_Unitario = funcion.Sala.Precio;
                d.Descuento = descuento;
                ticket.Detalle.Add(d);
            };
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente c = (Cliente)cboCliente.SelectedItem;
            txtDocumento.Text = c.Documento.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void txtCantidadButacas_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
