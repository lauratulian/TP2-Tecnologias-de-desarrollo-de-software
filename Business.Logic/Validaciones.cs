using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Business.Logic
{
    public class Validaciones: BusinessLogic
    {
        #region Metodos
        public static Boolean EsMailValido(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static Boolean EsContraseniaValida(String contrasenia)
        {
            if (contrasenia.Length >= 8)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static Boolean EsNumeroValido(string numero)
        {
            int i = 0;
            bool result = int.TryParse(numero, out i);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean EsNotaValida(string nota)
        {
            if (EsNumeroValido(nota))
            {

                if (int.Parse(nota) > 0 && int.Parse(nota) <= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
