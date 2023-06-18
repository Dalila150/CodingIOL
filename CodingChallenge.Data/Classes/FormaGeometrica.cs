/*
 * Se agregó funcionalidad para poder agregar nuevas figuras para la eleccion del usuario, por lo que el desarrollador solo debería agregar
   las formulas correspondientes para calcular area y perimetro.
 
 * Se implementó el idioma Aleman, y funcionalidad para poder agregar nuevos idiomas, por lo que el desarrollador solo debería encargarse
   de implementar las traducciones en el lugar correspondiente. (Para este ejemplo puntual las traducciones estan establecidas de forma tal
   que son strings aislados, aunque para un proyecto escalable lo ideal seria crear un espacio en el proyecto en el cual se va a agregar un
   "diccionario" por cada lenguaje que tengamos y dichos archivos por lenguaje deberian de tener todos los strings que se utilizan en el workspace.)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        //Deberian almacenarse todas las figuras acá
        static readonly Dictionary<int, string> Formas = new Dictionary<int, string>()
        {
            {1, "Cuadrado" },
            {2, "TrianguloEquilatero" },
            {3, "Circulo" },
        };

        private readonly decimal _lado;
        public int Tipo { get; set; }


        public FormaGeometrica(int tipo, decimal lado)
        {
            Tipo = tipo; //key
            _lado = lado;
        }

        private static int GenerarKey()
        {
            int ultimoKey = Formas.LastOrDefault().Key;
            return ultimoKey + 1;
        }
        private static bool Existe(string nombreArg)
        {
            var forma = Formas.Where(nombre => nombre.Value == nombreArg).FirstOrDefault().Value;
            if(String.IsNullOrEmpty(forma))
                return false;
            else
                return true;
        }
        public static string Agregar(string formaArg)
        {
            var sb = new StringBuilder();

            if (!Existe(formaArg))
            {
                int nuevoKey = GenerarKey();
                Formas.Add(nuevoKey, formaArg);

                foreach (var item in Formas)
                {
                    sb.Append(item.Value.ToString() + " ");
                }
                return sb.ToString();
                
            }
            else
            {
                return "Error";
            }
        }

        private static string RedactarHeader(int idioma, bool listaVacia)
        {
            string nombreIdioma = Idioma.obtenerNombreIdioma(idioma);
            switch (nombreIdioma)
            {
                case "Castellano":
                    if (listaVacia)
                        return "<h1>Lista vacía de formas!</h1>";
                    else
                        return "<h1>Reporte de Formas</h1>";

                case "Ingles":
                    if (listaVacia)
                        return "<h1>Empty list of shapes!</h1>";
                    else
                        return "<h1>Shapes report</h1>";
                    
                case "Aleman":
                    if (listaVacia)
                        return "<h1>Leere Formenliste!</h1>";
                    else
                        return "<h1>Formenbericht</h1>";
                    
                default:
                    throw new Exception("Idioma no soportado.");
                    
            }
        }
        
        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {

            //validar si la forma es valida
            var sb = new StringBuilder();
            Dictionary<int, int> cantidadesFormas = new Dictionary<int, int>();
            Dictionary<int, decimal> areasFormas = new Dictionary<int, decimal>();
            Dictionary<int, decimal> perimetrosFormas = new Dictionary<int, decimal>();

            string nombreIdioma = Idioma.obtenerNombreIdioma(idioma);

            if (formas.Any())
            {
                //redactar header
                sb.Append(RedactarHeader(idioma, false));

                foreach (FormaGeometrica item in formas)
                {
                    if(cantidadesFormas.ContainsKey(item.Tipo))
                        cantidadesFormas[item.Tipo]++;
                    else
                        cantidadesFormas[item.Tipo] = 1;

                    if (areasFormas.ContainsKey(item.Tipo))
                        areasFormas[item.Tipo] += item.CalcularArea();
                    else
                        areasFormas[item.Tipo] = item.CalcularArea();

                    if (perimetrosFormas.ContainsKey(item.Tipo))
                        perimetrosFormas[item.Tipo] += item.CalcularPerimetro();
                    else
                        perimetrosFormas[item.Tipo] = item.CalcularPerimetro();
                }

                foreach (var item in cantidadesFormas)
                {
                    int tipoForma = item.Key;
                    int cantidad = item.Value;
                    decimal area = areasFormas[tipoForma];
                    decimal perimetro = perimetrosFormas[tipoForma];

                    sb.Append(ObtenerLinea(cantidad, area, perimetro, tipoForma, idioma));
                }

                sb.Append("TOTAL:<br/>");
                sb.Append(cantidadesFormas.Values.Sum());
                
                switch (nombreIdioma)
                {
                    case "Castellano":
                        sb.Append(" formas Perimetro ");
                        break;
                    case "Ingles":
                        sb.Append(" shapes Perimeter ");
                        break;
                    case "Aleman":
                        sb.Append(" Formen Perimeter ");
                        break;

                    default:
                        throw new Exception("Idioma no soportado.");
                        

                }

                sb.Append((perimetrosFormas.Values.Sum()).ToString("#.##") + " ");

                switch (nombreIdioma)
                {
                    case "Castellano":
                        sb.Append("Area ");
                        break;
                    case "Ingles":
                        sb.Append("Area ");
                        break;
                    case "Aleman":
                        sb.Append("Bereich ");
                        break;
                    default:
                        throw new Exception("Idioma no soportado.");
                        
                }
                sb.Append((areasFormas.Values.Sum()).ToString("#.##"));

            }
            else
            {
                sb.Append(RedactarHeader(idioma, true));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            string nombreIdioma = Idioma.obtenerNombreIdioma(idioma);

            if (cantidad > 0)
            {
                switch (nombreIdioma)
                {
                    case "Castellano":
                        return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
                        
                    case "Ingles":
                        return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
                        
                    case "Aleman":
                        return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Bereich {area:#.##} | Perimeter {perimetro:#.##} <br/>";
                        
                    default:
                        throw new Exception("Idioma no soportado.");
                       
                }
            }
            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            string nombreIdioma = Idioma.obtenerNombreIdioma(idioma);

            switch (tipo)
            {
                case 1:
                    switch (nombreIdioma)
                    {
                        case "Castellano":
                            return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                            
                        case "Ingles":
                            return cantidad == 1 ? "Square" : "Squares";
                            
                        case "Aleman":
                            return cantidad == 1 ? "Quadrat" : "Quadrate";
                            
                        default:
                            throw new Exception("Idioma no soportado.");
                            
                    }
                    
                case 2:
                    switch (nombreIdioma)
                    {
                        case "Castellano":
                            return cantidad == 1 ? "Triángulo" : "Triángulos";
                            
                        case "Ingles":
                            return cantidad == 1 ? "Triangle" : "Triangles";
                            
                        case "Aleman":
                            return cantidad == 1 ? "Dreieck" : "Dreiecke";
                            
                        default:
                            throw new Exception("Idioma no soportado.");
                            
                    }
                    
                    
                case 3:
                    switch (nombreIdioma)
                    {
                        case "Castellano":
                            return cantidad == 1 ? "Círculo" : "Círculos";
                            
                        case "Ingles":
                            return cantidad == 1 ? "Circle" : "Circles";
                            
                        case "Aleman":
                            return cantidad == 1 ? "Kreis" : "Kreise";
                            
                        default:
                            throw new Exception("Idioma no soportado.");
                            
                    }
                    
            }

            return string.Empty;
        }

        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case 1: return _lado * _lado;
                case 2: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                case 3: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case 1: return _lado * 4;
                case 2: return _lado * 3;
                case 3: return (decimal)Math.PI * _lado;
                
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
