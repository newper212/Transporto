using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transporto.Helpers
{
    public static class PasswordHelpers
    {
        public static string GeneratorPassword()
        {
            Random obj = new Random();
            string sCadena = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string sCadenaNumero = "1234567890";
            int longitud = sCadena.Length;
            int longitudNumero = sCadena.Length;
            char cletra;
            char numero;
            int nlongitud = 5;
            string sNuevacadena = string.Empty;
            for (int i = 0; i < nlongitud; i++)
            {
                cletra = sCadena[obj.Next(sCadena.Length)];
                numero = sCadenaNumero[obj.Next(sCadenaNumero.Length)];
                sNuevacadena += cletra.ToString() + numero.ToString();
            }
            return sNuevacadena;
        }

        /// Encripta una cadena
        public static string Encriptar(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }

}