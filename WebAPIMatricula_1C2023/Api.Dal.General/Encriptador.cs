using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dal.General
{
    public class Encriptador
    {
        public static string Desencriptar(string pTexto)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(pTexto);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }


        public static string Encriptar(string pTexto)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(pTexto);
            result = Convert.ToBase64String(encryted);
            return result;
        }
    }
}
