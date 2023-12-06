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
using TPI_Backend.Entidades;
using TPI_Cine_Frontend.HTTP;
using static TPI_Backend.Entidades.Funcion;

namespace TPI_Cine_Frontend
{
    public partial class FrmActualizarFuncion : Form
    {
        List<Pelicula> peliculas;
        Funcion funcion = new Funcion();
        List<FormatoFuncion> listaformatos;
        public FrmActualizarFuncion(Funcion funcion)
        {
            InitializeComponent();
            this.funcion = funcion;
        }

        private void FrmActualizarFuncion_Load(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            cboFormato.Enabled = false;
            cboPelicula.Enabled = false;
            txtFecha.Enabled = false;
            txtSala.Enabled = false;
            LoadFilmsAsync();
            txtFecha.Text = funcion.FechaHora.ToString(); ;
            txtSala.Text = funcion.Sala.TipoSala.ToString();
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnAceptar.Enabled = true;
            cboPelicula.Enabled = true;
            cboFormato.Enabled = true;

        }

        private async void LoadFilmsAsync()
        {

            string url = "https://localhost:7282/api/Funcion/Peliculas";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Pelicula>>(result);

            peliculas = lst;
            cboPelicula.DataSource = null;
            cboPelicula.DataSource = peliculas;
            cboPelicula.DisplayMember = "Nombre";
            cboPelicula.DropDownStyle = ComboBoxStyle.DropDownList;
            int conteo = 0;
            foreach (Pelicula p in lst)
            {
                if (p.Id_Pelicula == funcion.PeliculaFuncion.Id_Pelicula)
                {
                    break;
                }
                conteo++;
            }
            cboPelicula.SelectedIndex = conteo;
            LoadFormatsAsync();
        }
        private async void LoadFormatsAsync()
        {
            string url = "https://localhost:7282/api/Funcion/Formatos_funciones";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<FormatoFuncion>>(result);
            listaformatos = lst;
            cboFormato.DataSource = lst;
            cboFormato.SelectedItem = funcion.Formato;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {

            Funcion nuevafuncion = new Funcion(
                funcion.NroFuncion,
                funcion.FechaHora,
                (Pelicula)cboPelicula.SelectedItem,
                funcion.Sala,
                (FormatoFuncion)cboFormato.SelectedItem
                );
            string bodyContent = JsonConvert.SerializeObject(nuevafuncion);
            string url = string.Format("https://localhost:7282/api/Funcion/PutFuncion");
            var result = await ClientSingleton.GetInstance().PutAsync(url, bodyContent);
            if (result.Equals("true"))
            {
                MessageBox.Show("La funcion se actualizo con exito", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("La funcion no pudo ser actualizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
