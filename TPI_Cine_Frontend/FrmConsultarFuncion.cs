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
using TPI_Backend.Entidades;
using TPI_Cine_Frontend.HTTP;
using TPI_Cine_Frontend.Presentacion;

namespace TPI_Cine_Frontend
{
    public partial class FrmConsultarFuncion : Form
    {
        List<Funcion> listaFunciones = new List<Funcion>();

        public FrmConsultarFuncion()
        {
            InitializeComponent();
        }

        private void FrmConsultarFuncion_Load(object sender, EventArgs e)
        {
            TemasColores.ViewClientConsult(this, Color.WhiteSmoke, FormBorderStyle.Fixed3D);
            dgvConsultarFunciones.AllowUserToAddRows = false;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (checkFiltrar.Checked)
            {
                if (dtpDesde.Value > dtpHasta.Value)
                {
                    MessageBox.Show("Periodo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                String fecDesde, fecHasta, cliente;
                // se añaden horas para que contemple las funciones que pasaran el dia de hoy
                DateTime fechaHastaDTP = dtpHasta.Value.AddHours(24);
                fecDesde = Uri.EscapeDataString(dtpDesde.Value.ToString("yyyy/MM/dd"));
                fecHasta = Uri.EscapeDataString(fechaHastaDTP.ToString("yyyy/MM/dd"));
                LoadFunctions(fecDesde, fecHasta);

            }

            else
            {
                loadFunctionsNoParam();
            }
        }

        private async void loadFunctionsNoParam()
        {
            string url = "https://localhost:7282/api/Funcion/FuncionesNoParam";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Funcion>>(result);
            listaFunciones.Clear();
            listaFunciones = lst;
            dgvConsultarFunciones.Rows.Clear();

            if (listaFunciones != null)
            {
                foreach (Funcion f in listaFunciones)
                {
                    dgvConsultarFunciones.Rows.Add(new object[] {
                        f.PeliculaFuncion.Nombre,
                        f.FechaHora,
                        f.Formato,
                        f.Sala.TipoSala.ToString(),
                        "Modificar",
                        "Borrar"

                    }); ;
                }
            }
            else
            {
                MessageBox.Show("Sin datos de funciones para las fechas ingresadas", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        private async void LoadFunctions(string fecDesde, string fecHasta)
        {
            string url = String.Format("https://localhost:7282/api/Funcion/Funciones?fecha_desde={0}&fecha_hasta={1}", fecDesde, fecHasta);
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Funcion>>(result);
            listaFunciones.Clear();
            listaFunciones = lst;

            dgvConsultarFunciones.Rows.Clear();

            if (lst != null)
            {
                foreach (Funcion f in lst)
                {
                    dgvConsultarFunciones.Rows.Add(new object[] {
                        f.PeliculaFuncion.Nombre,
                        f.FechaHora,
                        f.Formato,
                        f.Sala.TipoSala.ToString(),
                        "Modificar",
                        "Borrar"

                    }); ;
                }
            }
            else
            {
                MessageBox.Show("Sin datos de funciones para las fechas ingresadas", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void dgvConsultarFunciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvConsultarFunciones.CurrentCell.ColumnIndex == 4)
            {
                Funcion funcionSeleccionada = listaFunciones[dgvConsultarFunciones.CurrentCell.RowIndex];
                new FrmActualizarFuncion(funcionSeleccionada).ShowDialog();
                
            }
            if (dgvConsultarFunciones.CurrentCell.ColumnIndex == 5)
            {
                DialogResult = MessageBox.Show("Esta seguro/a que quiere borrar esta funcion?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    Funcion funcionSeleccionada = listaFunciones[dgvConsultarFunciones.CurrentCell.RowIndex];
                    string url = string.Format("https://localhost:7282/TieneButaca?idFuncion={0}", funcionSeleccionada.NroFuncion);
                    var result = await ClientSingleton.GetInstance().GetAsync(url);

                    int tieneButacas = int.Parse(result);
                    if (tieneButacas == 1)
                    {
                        MessageBox.Show("No se puede eliminar esa funcion ya que tiene butacas compradas ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        url = string.Format("https://localhost:7282/api/Funcion/DeleteFuncion?idFuncion={0}", funcionSeleccionada.NroFuncion);
                        result = await ClientSingleton.GetInstance().DeleteAsync(url);

                        bool sucess = bool.Parse(result);
                        if (sucess)
                        {
                            MessageBox.Show("la funcion fue eliminada exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("la funcion no se pudo eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        dgvConsultarFunciones.Rows.RemoveAt(dgvConsultarFunciones.CurrentCell.RowIndex);
                    }
                
                }


            }
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void checkFiltrar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFiltrar.Enabled)
            {
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
            }
        }
    }
}
