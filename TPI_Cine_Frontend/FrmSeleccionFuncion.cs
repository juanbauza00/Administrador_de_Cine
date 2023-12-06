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
using TPI_Backend.Datos;
using TPI_Backend.Entidades;
using TPI_Cine_Frontend.HTTP;
using static System.Net.WebRequestMethods;

namespace TPI_Cine_Frontend
{
    public partial class FrmSeleccionFuncion : Form
    {
        public Ticket ticket = new Ticket();
        private List<Pelicula> listaPeliculas = new List<Pelicula>();
        private List<Funcion> listaFunciones = new List<Funcion>();
        public FrmSeleccionFuncion()
        {
            InitializeComponent();
        }


        private void FrmSeleccionFuncion_Load(object sender, EventArgs e)
        {

            dgvFunciones.AllowUserToAddRows = false;


        }
        private void lblFechaHasta_Click(object sender, EventArgs e)
        {

        }



        private async void btnFiltrar_Click(object sender, EventArgs e)
        {


            dgvFunciones.Rows.Clear();

            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show("Periodo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //se agregan 24 horas para contemplar las funciones que ocurriran el dia de hoy


           DateTime fechaHastaDTPvalue = dtpFechaHasta.Value.AddHours(24);

            
            string fecha_desde = Uri.EscapeDataString(dtpFechaDesde.Value.ToString("yyyy/MM/dd"));
            string fecha_hasta = Uri.EscapeDataString(fechaHastaDTPvalue.ToString("yyyy/MM/dd"));



            obtenerFunciones(fecha_desde, fecha_hasta);

        }

        private async void obtenerFunciones(string fecha_desde, string fecha_hasta)
        {
            string url = String.Format("https://localhost:7282/api/Funcion/Funciones?fecha_desde={0}&fecha_hasta={1}", fecha_desde, fecha_hasta);

            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var jsonList = JsonConvert.DeserializeObject<List<Funcion>>(result);
            listaFunciones = jsonList;

            foreach (Funcion funcion in listaFunciones)
            {
                dgvFunciones.Rows.Add(
                    funcion.PeliculaFuncion.Nombre,
                    funcion.FechaHora,
                    funcion.Formato,
                    funcion.Sala,
                    "Comprar"
                    );
            }

        }

        private void dgvFunciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFunciones.CurrentCell.ColumnIndex == 4)
            {

                //Como las funciones se agregan al DGV desde la listaFunciones
                //los indices del DGV y de la lista seran los mismos
                //de esta forma podemos encontrar la funcion seleccionada con la lista y el index del dgv
                int functionIndex = dgvFunciones.CurrentCell.RowIndex;
                Funcion selectedFunction = listaFunciones[functionIndex];

                if ((selectedFunction.FechaHora.Hour < DateTime.Today.Hour && selectedFunction.FechaHora.Date < DateTime.Today) ||
                    (selectedFunction.FechaHora.Hour < DateTime.Today.Hour && selectedFunction.FechaHora.Date == DateTime.Today))
                {
                    MessageBox.Show("Esa funcion ya ha concluido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                else if (selectedFunction.FechaHora < DateTime.Today)
                {
                    MessageBox.Show("Esa funcion ya ha concluido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else { new FrmAltaTicket(selectedFunction).ShowDialog(); this.Dispose(); }

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            dgvFunciones.Rows.Clear();
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today;
        }
    }
}
