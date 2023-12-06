using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_Backend.Entidades;
using TPI_Backend.Datos.Interfaz;
using System.Diagnostics;

namespace TPI_Backend.Datos.Implementacion
{
    public class TicketDao : ITicketDao
    {
        public bool ActualizarTicket(Ticket oTicket)
        {
            bool ok = true;
            SqlConnection cnn = HelperDao.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_MODIFICAR_MAESTRO_TICKET";
                cmd.CommandType = CommandType.StoredProcedure;
                //añadir los parametros
                //Parametros input
                cmd.Parameters.AddWithValue("@id_ticket", oTicket.NroTicket);
                cmd.Parameters.AddWithValue("@id_cliente", oTicket.ClienteTicket.IdCliente);
                cmd.Parameters.AddWithValue("@id_forma_pago", (int)oTicket.FormaPago);
                cmd.Parameters.AddWithValue("@estado", oTicket.Pagado);
                cmd.Parameters.AddWithValue("@fecha", oTicket.Fecha);
                cmd.ExecuteNonQuery();

                SqlCommand cmdDetalle;
                int idTicket = oTicket.NroTicket;
                foreach (DetalleTicket dt in oTicket.Detalle)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE_TICKET", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    //Parametros input
                    cmdDetalle.Parameters.AddWithValue("@id_ticket", idTicket);
                    cmdDetalle.Parameters.AddWithValue("@id_funcion_butaca", dt.Butaca.IdFuncionButaca);
                    cmdDetalle.Parameters.AddWithValue("@precio_unitario", dt.Precio_Unitario);
                    cmdDetalle.Parameters.AddWithValue("@id_promocion", dt.Descuento.First().Key);
                    cmdDetalle.Parameters.AddWithValue("@descuento", dt.Descuento.First().Value);

                    cmdDetalle.ExecuteNonQuery();

                }
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }

        public bool BorrarTicket(int nro)
        {

            string spDetalle = "SP_ELIMINAR_DETALLE_TICKET";
            List<Parametro> lstD = new List<Parametro>();
            lstD.Add(new Parametro("@idTicket", nro));

            int afectadasD = HelperDao.ObtenerInstancia().EjecutarSQL(spDetalle, lstD);
            string spMaestro = "SP_ELIMINAR_TICKET";
            List<Parametro> lstPM = new List<Parametro>();

            lstPM.Add(new Parametro("@id_ticket", nro));
            int afectadasT = HelperDao.ObtenerInstancia().EjecutarSQL(spMaestro, lstPM);
            return afectadasD + afectadasT > 0;
        }

        public bool CrearTicket(Ticket oTicket)
        {
            bool resultado = true;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand("SP_INSERTAR_MAESTRO_TICKET", conexion, t);
                comando.CommandType = CommandType.StoredProcedure;

                //Parametros input
                comando.Parameters.AddWithValue("@id_cliente", oTicket.ClienteTicket.IdCliente);
                comando.Parameters.AddWithValue("@id_forma_pago", (int)oTicket.FormaPago);
                comando.Parameters.AddWithValue("@estado", oTicket.Pagado);

                //Parametro output
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@id_ticket";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                int ticketNro = (int)parametro.Value;
                //int detalleNro = 1; --ID DETALLE ES IDENTITY
                SqlCommand cmdDetalle;

                foreach (DetalleTicket dt in oTicket.Detalle)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE_TICKET", conexion, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    //Parametros input
                    cmdDetalle.Parameters.AddWithValue("@id_ticket", ticketNro);
                    //cmdDetalle.Parameters.AddWithValue("@id_detalle", detalleNro); --ID DETALLE ES IDENTITY
                    cmdDetalle.Parameters.AddWithValue("@id_funcion_butaca", dt.Butaca.IdFuncionButaca);
                    cmdDetalle.Parameters.AddWithValue("@precio_unitario", dt.Precio_Unitario);
                    cmdDetalle.Parameters.AddWithValue("@id_promocion", dt.Descuento.First().Key);
                    cmdDetalle.Parameters.AddWithValue("@descuento", dt.Descuento.First().Value);

                    cmdDetalle.ExecuteNonQuery();
                    // detalleNro++; --ID DETALLE ES IDENTITY
                }

                t.Commit();

                return resultado;
            }
            catch
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return resultado;
        }


        public List<Butaca> ObtenerButacas(int id_funcion)
        {
            List<Butaca> lButacas = new List<Butaca>();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@id_funcion", id_funcion));

            DataTable tablaButacas = HelperDao.ObtenerInstancia().Consultar("SP_BUTACAS_POR_FUNCION", parametros);

            foreach (DataRow dr in tablaButacas.Rows)
            {
                Butaca butaca = new Butaca();
                butaca.IdFuncionButaca = int.Parse(dr["id_funcion_butaca"].ToString());
                butaca.IdButaca = int.Parse(dr["id_butaca"].ToString());
                butaca.Fila = int.Parse(dr["fila"].ToString());
                butaca.Columna = int.Parse(dr["columna"].ToString());
                string estado = dr["Estado"].ToString();
                if (estado == "desocupada")
                {
                    butaca.Estado = Butaca.EstadoButaca.Desocupada;
                }
                else
                {
                    butaca.Estado = Butaca.EstadoButaca.Ocupada;
                }
                lButacas.Add(butaca);
            }
            return lButacas;
        }

        public Dictionary<int, int> ObtenerDescuento(int dia_semana)
        {
            int dia_descuento = 0;
            int procentaje = 0;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@dia_semana", dia_semana));

            DataTable dt = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_PROMOCION", parametros);

            foreach (DataRow dr in dt.Rows)
            {
                dia_descuento = int.Parse(dr["dia_promocion"].ToString());
                procentaje = int.Parse(dr["porcentaje"].ToString());
            }

            Dictionary<int, int> descuento = new Dictionary<int, int>();
            descuento.Add(dia_descuento, procentaje);
            return descuento;

        }

        public List<Ticket.FormaPagoTicket> ObtenerFormasPago()
        {
            throw new NotImplementedException();
        }


        public int ObtenerProximoTicket()
        {
            return HelperDao.ObtenerInstancia().ConsultarEscalar("SP_PROXIMO_TICKET (esta hecho?)", "@next");
        }

        public List<Ticket> ObtenerTicketsPorFiltros(List<Parametro> lFiltros)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> TraerTickets()
        {
            DataTable dtSoloTickets;
            dtSoloTickets = HelperDao.ObtenerInstancia().Consultar("SP_TRAER_TICKETS_CLIENTES");
            List<Ticket> listaTickets;
            listaTickets = DetallarYMapearTickets(dtSoloTickets);
            return listaTickets;
        }

        public List<Ticket> TraerTicketsConFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Parametro> paramsFunciones = new List<Parametro>();
            paramsFunciones.Add(new Parametro("@fecha_desde", fechaDesde));
            paramsFunciones.Add(new Parametro("@fecha_hasta", fechaHasta));

            DataTable tablaTickets = HelperDao.ObtenerInstancia().Consultar("SP_TRAER_TICKETS_CLIENTES_CON_PARAM", paramsFunciones);


            List<Ticket> listaTickets;
            listaTickets = DetallarYMapearTickets(tablaTickets);
            return listaTickets;
        }

        private List<Ticket> DetallarYMapearTickets(DataTable tablaTickets)
        {
            List<Ticket> listaTickets = new List<Ticket>();
            try
            {
                foreach (DataRow drTicket in tablaTickets.Rows)
                {
                    //MAPEAR CLIENTE
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = int.Parse(drTicket["id_cliente"].ToString());
                    cliente.Nombre = drTicket["nom_cliente"].ToString();
                    cliente.Apellido = drTicket["ape_cliente"].ToString();
                    cliente.Documento = int.Parse(drTicket["documento"].ToString());
                    cliente.TipoDocumento = (Cliente.tipoDocumentoCliente)int.Parse(drTicket["id_tipo_documento"].ToString());


                    //MAPEAR TICKET
                    Ticket ticket = new Ticket();
                    ticket.NroTicket = int.Parse(drTicket["id_ticket"].ToString());
                    ticket.Fecha = Convert.ToDateTime(drTicket["fecha"].ToString());
                    if (Convert.ToBoolean(drTicket["estado"].ToString()))
                    {
                        ticket.Pagado = 1;
                    }
                    if (!Convert.ToBoolean(drTicket["estado"].ToString()))
                    {
                        ticket.Pagado = 0;
                    }
                    ticket.FormaPago = (Ticket.FormaPagoTicket)int.Parse(drTicket["id_forma_pago"].ToString());
                    ticket.ClienteTicket = cliente;



                    List<Parametro> param = new List<Parametro>();
                    param.Add(new Parametro("@id_ticket", ticket.NroTicket));

                    //MAPEAR CADA BUTACA y DETALLE
                    DataTable dtDetalles = HelperDao.ObtenerInstancia().Consultar("SP_TRAER_DETALLES_TICKETS_Y_BUTACAS", param);
                    foreach (DataRow drDetalle in dtDetalles.Rows)
                    {
                        //MAPEAR BUTACA
                        Butaca butaca = new Butaca();
                        butaca.IdFuncionButaca = int.Parse(drDetalle["id_funcion_butaca"].ToString());
                        butaca.IdButaca = int.Parse(drDetalle["id_butaca"].ToString());
                        butaca.Fila = int.Parse(drDetalle["fila"].ToString());
                        butaca.Columna = int.Parse(drDetalle["columna"].ToString());


                        //MAPEAR DETALLE
                        DetalleTicket detalle = new DetalleTicket();
                        //detalle.Butaca = new Butaca();
                        detalle.Descuento = new Dictionary<int, double>();
                        detalle.IdDetalleTicket = int.Parse(drDetalle["id_detalle"].ToString());
                        detalle.Precio_Unitario = double.Parse(drDetalle["precio_unitario"].ToString());
                        int diaDescuento = int.Parse(drDetalle["dia_promocion"].ToString());
                        double descuento;
                        if (string.IsNullOrEmpty(drDetalle["descuento"].ToString()))
                        {
                            descuento = 0;
                        }
                        else
                        {
                            descuento = double.Parse(drDetalle["descuento"].ToString());
                        }
                        detalle.Descuento.Add(diaDescuento, descuento);
                        detalle.Butaca = butaca;

                        ticket.AgregarDetalle(detalle);
                    }
                    listaTickets.Add(ticket);



                }
                return listaTickets;
            }
            catch (FormatException fex){
                Debug.Write(fex.Source);
            }
            return listaTickets;
            }
        

        //vamos a usar el ObtenerTicketPorFiltros()

        //public Ticket ObtenerTicketPorCliente(string cliente)
        //{
        //    //hace falta? para que era?
        //    Ticket ticket = new Ticket();
        //    string sp = "SP_CONSULTAR_DETALLES_TICKET"; //esta hecho?
        //    List<Parametro> lst = new List<Parametro>();
        //    lst.Add(new Parametro("@cliente", cliente));

        //    DataTable dt = HelperDao.ObtenerInstancia().Consultar(sp, lst);
        //    bool primero = true;

        //    foreach (DataRow fila in dt.Rows)
        //    {
        //        if (primero)
        //        {
        //            //presupuesto.Cliente = fila["cliente"].ToString();
        //            //presupuesto.Fecha = DateTime.Parse(fila["fecha"].ToString());
        //            //presupuesto.Descuento = Double.Parse(fila["descuento"].ToString());
        //            //hacer el mapeo
        //            primero = false;
        //        }
        //        //int nroProducto = int.Parse(fila["id_producto"].ToString());
        //        //string nombre = fila["n_producto"].ToString();
        //        //double precio = double.Parse(fila["precio"].ToString());
        //        //Producto producto = new Producto(nroProducto, nombre, precio);
        //        //int cantidad = int.Parse(fila["cantidad"].ToString());
        //        DetalleTicket detalle = new DetalleTicket(/*producto, cantidad*/);
        //        ticket.AgregarDetalle(detalle);
        //    }
        //    return ticket;
        //}

        //public List<Ticket> ObtenerTicketsPorFiltros(List<Parametro> lFiltros)
        //{
        //    //hace falta? para que era?
        //    List<Ticket> tickets = new List<Ticket>();
        //    string sp = "SP_CONSULTAR_TICKETS"; //esta hecho?
        //    List<Parametro> lst = new List<Parametro>();
        //    lst.Add(new Parametro("@fecha_desde", desde));
        //    lst.Add(new Parametro("@fecha_hasta", hasta));
        //    lst.Add(new Parametro("@cliente", cliente));
        //    DataTable dt = HelperDao.ObtenerInstancia().Consultar(sp, lst);

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        Ticket ticket = new Ticket();
        //        //hacer el mapeo
        //        tickets.Add(ticket);
        //    }

        //    return tickets;
        //}
    }
}
