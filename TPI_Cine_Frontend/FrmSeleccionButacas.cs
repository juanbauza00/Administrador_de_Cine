using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_Backend.Entidades;
using static TPI_Backend.Entidades.Cliente;
using TPI_Cine_Frontend.HTTP;

namespace TPI_Cine_Frontend
{
    public partial class FrmSeleccionButacas : Form
    {
        public int IdFuncion { get; set; }

        //Representa la cantidad de butacas compradas, este campo se va a ir modificando hasta que quede en 0
        public int CantButacas { get; set; }

        //Este valor guarda la cantidad original de butacas compradas, se utiliza al final para validar
        private int cantButacasHist;

        private List<Butaca> listaButacas = null; //La lista con todas las butacas de esta sala
        private List<Butaca> butacasSeleccionadas = null; // La lista de las butacas seleciconadas

        //Se crea un Diccionario el cual va a contener la combinación de Butaca / Botón
        private Dictionary<Butaca, Button> dicButacaBoton = new Dictionary<Butaca, Button>();

        public FrmSeleccionButacas(int idFuncion, int cantButacas, List<Butaca> lButacas, List<Butaca> butSeleccionadas)
        {
            IdFuncion = idFuncion;
            CantButacas = cantButacas;
            cantButacasHist = cantButacas;
            InitializeComponent();
            listaButacas = lButacas;
            if (butacasSeleccionadas != null)
            {
                butacasSeleccionadas.Clear();
                butacasSeleccionadas = butSeleccionadas;
            }
        }



        private void FrmSeleccionButacas_Load(object sender, EventArgs e)
        {
            CargarButacasAsync();
            MapearButacasBotones(dicButacaBoton);
            butacasSeleccionadas = new List<Butaca>();
        }


        private async void CargarButacasAsync()
        {


            AcoplarButacasABotones();
        }

        //Esta funcion asigna dentro de un diccionario Cada Butaca a su Botón correspondiente
        private void AcoplarButacasABotones()
        {
            //Se carga dentro de dicButacaBoton cada butaca con su respectivo botón
            foreach (Butaca but in listaButacas)
            {
                if (but.Fila == 1 && but.Columna == 1) dicButacaBoton.Add(but, btnF1C1);
                if (but.Fila == 1 && but.Columna == 2) dicButacaBoton.Add(but, btnF1C2);
                if (but.Fila == 1 && but.Columna == 3) dicButacaBoton.Add(but, btnF1C3);
                if (but.Fila == 2 && but.Columna == 1) dicButacaBoton.Add(but, btnF2C1);
                if (but.Fila == 2 && but.Columna == 2) dicButacaBoton.Add(but, btnF2C2);
                if (but.Fila == 2 && but.Columna == 3) dicButacaBoton.Add(but, btnF2C3);
            }
        }


        //Esta funcion se encarga de definir si la butaca(representada por un boton) está disponible para seleccionar
        private void MapearButacasBotones(Dictionary<Butaca, Button> dicButacaBoton)
        {
            foreach (KeyValuePair<Butaca, Button> butacaBoton in dicButacaBoton)
            {
                //Si la butaca tiene estado ocupada, el botón se pone rojo y se deshabilita.
                if (butacaBoton.Key.Estado == Butaca.EstadoButaca.Ocupada)
                {
                    butacaBoton.Value.BackColor = Color.Red;
                    butacaBoton.Value.Enabled = false;
                }

                //Si la butaca tiene estado desocupada, el boton se pondrá en azul,
                //  se habilitará el botón y se suscribe al evento ClickBoton
                if (butacaBoton.Key.Estado == Butaca.EstadoButaca.Desocupada)
                {
                    butacaBoton.Value.BackColor = Color.RoyalBlue;
                    butacaBoton.Value.Enabled = true;
                    butacaBoton.Value.Click += ClickBoton;
                }
                if (butacasSeleccionadas != null)
                {
                    foreach (Butaca bt in butacasSeleccionadas)
                    {
                        if (bt.IdFuncionButaca == butacaBoton.Key.IdFuncionButaca)
                        {
                            butacaBoton.Value.BackColor = Color.Magenta;
                            butacaBoton.Value.Enabled = true;
                            butacaBoton.Value.Click += ClickBoton;

                            CantButacas--;
                        }
                    }
                }
            }


        }



        //Metodo para seleccionar las butacas
        //Color: RoyalBlue = Desocupada / Red = Ocupada / Magenta = Seleccionada
        // En MapearButacasBotones, se agregó el evento click de cada butaca desocupada a este evento
        private void ClickBoton(object? sender, EventArgs e)
        {
            Button botonClicado = (Button)sender;

            //Si la butaca se encuentra seleccionada, se deselecciona y se suma un valor a cantButacas
            if (botonClicado.BackColor == Color.Magenta)
            {
                botonClicado.BackColor = Color.RoyalBlue;
                CantButacas++;
                return;
            }
            if (CantButacas > 0)
            {
                //Sila butaca no se encuentra seleccionada, se cambia a color magenta y se resta cantButacas
                if (botonClicado.BackColor == Color.RoyalBlue)
                {
                    botonClicado.BackColor = Color.Magenta;
                    CantButacas--;
                }
                return;
            }
            else
                MessageBox.Show("No es posible seleccionar mas butacas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Boton Aceptar, si todo está OK se cargará la lista de butacasSeleecionadas y cerrará el frm
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Revisamos que no queden mas butacas por seleccionar
            if (CantButacas != 0)
            {
                MessageBox.Show("Aún quedan butacas por seleccionar!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Ya se encuentran seleccionadas la misma cantidad de butacas que se compraron
            if (CantButacas == 0)
            {
                int controlCantButacas = 0;
                //Itera sobre el diccionario, si su valor = boton es magenta, su clave = butaca 
                // se ingresa a la lista de butacasSeleccionadas
                foreach (KeyValuePair<Butaca, Button> butBot in dicButacaBoton)
                {
                    if (butBot.Value.BackColor == Color.Magenta)
                    {
                        butacasSeleccionadas.Add(butBot.Key);
                        controlCantButacas++;
                    }
                }
                //Validamos nuevamente que la cantidad de butacas seleccionadas sea la misma que la cant de butacas compradas
                if (controlCantButacas == cantButacasHist)
                {
                    //Cierra el DialogResult iniciado en el FrmAltaDetallesTicket
                    this.DialogResult = DialogResult.OK;
                    //Cierra el frm
                    this.Close();
                }
            }
        }

        //Este método se utiliza únicamente para llamarlo desde frmAlataDetalleTicket
        // y obtener las butacas seleccionadas
        public List<Butaca> ObtenerButacasSeleccionadas()
        {
            return butacasSeleccionadas;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Esta seguro que desea cancelar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                //Cierra el frm
                this.Close();
            }
            else
            {
                return;
            }


        }

        private void btnF1C3_Click(object sender, EventArgs e)
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
