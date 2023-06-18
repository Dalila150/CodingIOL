using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    /*
    #region Idiomas
    public const int Castellano = 1;
    public const int Ingles = 2;
    #endregion
    */

    public class Idioma
    {
        static Dictionary<int, string> Idiomas = new Dictionary<int, string>()
        {
            {1, "Castellano" },
            {2, "Ingles" },
            {3, "Aleman" }
        };

        public static string obtenerNombreIdioma(int Key)
        {
            string nombreIdioma;

            try
            {
                nombreIdioma = Idiomas[Key];
            }
            catch (Exception)
            {
                throw new Exception("Idioma inexistente");
            }
             
            return nombreIdioma;
        }
        
        
        private static int GenerarKey()
        {
            int ultimoKey = Idiomas.LastOrDefault().Key;
            return ultimoKey + 1;
        }

        private static bool Existe(string nombreArg)
        {
            var idioma = Idiomas.Where(nombre => nombre.Value == nombreArg).FirstOrDefault().Value;
            if(String.IsNullOrEmpty(idioma))
                return false;
            else
                return true;
        }

        public static string Agregar(string idiomaArg)
        {
            var sb = new StringBuilder();

            if (!Existe(idiomaArg))
            {
                int nuevoKey = GenerarKey();
                Idiomas.Add(nuevoKey, idiomaArg);

                foreach (var item in Idiomas)
                {
                    sb.Append(item.Value.ToString() + " ");
                }
                return sb.ToString();
            }
            else
            {
                throw new Exception("El idioma que intenta agregar ya existe");
            }
        }
    }
}
