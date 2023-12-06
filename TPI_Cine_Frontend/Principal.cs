namespace TPI_Cine_Frontend
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void altaTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmSeleccionFuncion().ShowDialog();
        }

        private void altaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAltaCliente().ShowDialog();
        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConsultarCliente().ShowDialog();
        }

        private void altaFuncionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAltaFuncion().ShowDialog();
        }

        private void consultaFuncionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConsultarFuncion().ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            new FrmLogin().ShowDialog();
        }

        private void consultarReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmReportTicket().ShowDialog();
        }

        private void consultarTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConsultarTicket().ShowDialog();
        }

        private void informacionDelProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAcercaDe().ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Esta seguro/a que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}