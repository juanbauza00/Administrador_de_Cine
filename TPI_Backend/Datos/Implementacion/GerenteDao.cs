using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_Backend.Datos.Interfaz;
using TPI_Backend.Entidades;
using System.Diagnostics;
namespace TPI_Backend.Datos.Implementacion
{
    public class GerenteDao : IGerenteDao
    {
        public List<Gerente> GetGerentes() {
            List<Gerente> gerentes = new List<Gerente>();
            DataTable tablaGerentes = HelperDao.ObtenerInstancia().Consultar("sp_get_gerentes");

            if (tablaGerentes.Rows.Count > 0)
            {
                foreach (DataRow row in tablaGerentes.Rows)
                {
                    Gerente nuevoGerente = new Gerente();
                    nuevoGerente.Nombre = row[0].ToString();
                    nuevoGerente.Apellido = row[1].ToString();
                    nuevoGerente.Email = row[2].ToString();
                    gerentes.Add(nuevoGerente);
                }
                
            }
            
            return gerentes;
        }

        public int validarPassword(string email, string password) {
            int success;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@email", email));
            parametros.Add(new Parametro("@passwordParam", password));

            success = HelperDao.ObtenerInstancia().ConsultarEscalar("sp_validar_gerente", "@validado", parametros);
            return success;
        }

        
    }
}
