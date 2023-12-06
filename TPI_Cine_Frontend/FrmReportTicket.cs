using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using TPI_Backend.Datos;

namespace TPI_Cine_Frontend
{
    public partial class FrmReportTicket : Form
    {
        public FrmReportTicket()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmReportTicket_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-60);
            dtpHasta.Value = DateTime.Now;

            RVReporte.LocalReport.ReportEmbeddedResource = "TPI_Cine_Frontend.Report.ReportTicket.rdlc";
            //RVReporte.RefreshReport();
        }

        private void rbtSalir_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void RbtGenerar_Click(object sender, EventArgs e)
        {
            HelperDao helper = HelperDao.ObtenerInstancia();
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha_desde", dtpDesde.Value));
            lst.Add(new Parametro("@fecha_hasta", dtpHasta.Value));
            DataTable dt = helper.Consultar("SP_REPORTE_TICKETS", lst);
            RVReporte.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));
            RVReporte.RefreshReport();
        }
    }
}
