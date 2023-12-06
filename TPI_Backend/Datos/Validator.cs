using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TPI_Backend.Datos
{
    public class Validator
    {
        private bool ValidarTexto(string texto, string patron)
        {
            // Se utiliza Regex para verificar si el texto coincide con el patrón
            return Regex.IsMatch(texto, patron);
        }

        // Método para validar y mostrar un mensaje de error
        public void ValidarYMostrarMensaje(string texto, string patron, string mensajeError)
        {
            if (!ValidarTexto(texto, patron))
            {
                Console.WriteLine($"{mensajeError} - Texto: {texto}");
            }
        }

        public static void Main(string[] args)
        {
            Validator validador = new Validator();

            // Validar el contenido del texto de números
            validador.ValidarYMostrarMensaje("123", @"^-?\d+$", "Por favor, ingrese solo números en este campo.");

            // Validar el contenido del texto de letras
            validador.ValidarYMostrarMensaje("abc", @"^[a-zA-Z]+$", "Por favor, ingrese solo letras en este campo.");
        }
    }
}
