using TPI_Cine_Frontend.HTTP;
using TPI_Cine_Frontend.Presentacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_Backend.Entidades;
using System.Diagnostics;
using static TPI_Backend.Entidades.Funcion;

namespace TPI_Cine_Frontend
{
    public partial class FrmAltaFuncion : Form
    {
        List<SalaCine> listaSala = new List<SalaCine>();
        List<Pelicula> listaPeliculas = new List<Pelicula>();
        List<FormatoFuncion> listaFormatoFuncion = new List<FormatoFuncion>();
        private Funcion newFunction;
        public FrmAltaFuncion()
        {
            InitializeComponent();
            newFunction = new Funcion();

        }

        private void FrmAltaFuncion_Load(object sender, EventArgs e)
        {
            TemasColores.ViewClientConsult(this, Color.WhiteSmoke, FormBorderStyle.Fixed3D);
            LoadFilmsAsync();
            //los siguientes loads se realizan despues de la ejecucion de LoadFilmsAsync() para evitar un bug
            
            dtpHoraFuncion.Value = DateTime.Now;



        }

        private async void LoadFormatsAsync()
        {
            string url = "https://localhost:7282/api/Funcion/Formatos_funciones";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<FormatoFuncion>>(result);
            listaFormatoFuncion = lst;
            cboFormato.DataSource = lst;
        }


        private async void LoadRoomsAsync()
        {
            string url = "https://localhost:7282/api/Funcion/Tipos_salas";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<SalaCine>>(result);
            listaSala = lst;
            cboSala.DataSource = listaSala;


            cboPelicula.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadFormatsAsync();
        }

        private async void LoadFilmsAsync()
        {
            string url = "https://localhost:7282/api/Funcion/Peliculas";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Pelicula>>(result);
            listaPeliculas = lst;
            cboPelicula.DataSource = lst;
            cboPelicula.DisplayMember = "nombre";
            cboPelicula.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadRoomsAsync();
        }


        private async Task InsertFunctionAsync()
        {
            DateTime fecha = dtpFechaFuncion.Value.Date;
            TimeSpan hora = dtpHoraFuncion.Value.TimeOfDay;
            newFunction.FechaHora = fecha.Add(hora);
            newFunction.PeliculaFuncion = (Pelicula)cboPelicula.SelectedItem;
            newFunction.Formato = (FormatoFuncion)cboFormato.SelectedItem;
            newFunction.Sala = listaSala[cboSala.SelectedIndex];

            Pelicula peliculaFuncion = listaPeliculas[cboPelicula.SelectedIndex];
            newFunction.PeliculaFuncion = peliculaFuncion;


            string bodyContent = JsonConvert.SerializeObject(newFunction);

            string url = "https://localhost:7282/api/Funcion";
            var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);

            if (result.Equals("true"))
            {
                MessageBox.Show("La funcion se registro correctamente", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("La funcion NO se pudo registrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            SalaCine salaSeleccionada = (SalaCine)cboSala.SelectedItem;

            switch (salaSeleccionada.TipoSala)
            {
                case SalaCine.TipoSalaCine.IMAX:
                    txtTipoSala.Text = "IMAX";
                    break;
                case SalaCine.TipoSalaCine.Sala2D:
                    txtTipoSala.Text = "Sala 2D";
                    break;
                case SalaCine.TipoSalaCine.Sala3D:
                    txtTipoSala.Text = "Sala 3D";
                    break;
                case SalaCine.TipoSalaCine.Sala4D:
                    txtTipoSala.Text = "Sala 4D";
                    break;
                case SalaCine.TipoSalaCine.VIP:
                    txtTipoSala.Text = "Sala VIP";
                    break;
            }

        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cboPelicula.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una pelicula", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dtpFechaFuncion.Value.Day < DateTime.Today.Day)
            {
                MessageBox.Show("Debe seleccionar una fecha valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dtpHoraFuncion.Value > DateTime.Now || dtpHoraFuncion.Value == DateTime.MinValue)
            {
                MessageBox.Show("Debe seleccionar una hora valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboSala.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una sala", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            await InsertFunctionAsync();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboPelicula_SelectedIndexChanged(object sender, EventArgs e)
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
