using System;
using System.Collections.Generic;
using System.Threading;
using CodingChallenge.Data.Classes;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        /*
         * FIGURAS BASE
            {1, "Cuadrado" },
            {2, "TrianguloEquilatero" },
            {3, "Circulo" },

         * IDIOMAS BASE
            {1, "Castellano" },
            {2, "Ingles" },
            {3, "Aleman"},
         */

        [TestCase]
        public void TestAgregarNuevoIdioma()
        {
            var nuevoIdioma = "Ruso"; //escribir nuevo idioma
            Assert.AreEqual("Castellano Ingles Aleman " + nuevoIdioma + " ", Idioma.Agregar(nuevoIdioma));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnAleman()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenAleman()
        {
            var cuadrados = new List<FormaGeometrica> { new FormaGeometrica(1, 5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, 3);

            Assert.AreEqual("<h1>Formenbericht</h1>1 Quadrat | Bereich 25 | Perimeter 20 <br/>TOTAL:<br/>1 Formen Perimeter 20 Bereich 25", resumen);
        }

        [TestCase]
        public void TestAgregarNuevaForma()
        {
            var nuevaForma = "Trapecio/Rectangulo"; //escribir nueva forma
            Assert.AreEqual("Cuadrado TrianguloEquilatero Circulo " + nuevaForma + " ", FormaGeometrica.Agregar(nuevaForma));
        }

        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        
        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new FormaGeometrica(1, 5)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, 1);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        
        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(1, 5), //cuadrado
                new FormaGeometrica(1, 1),
                new FormaGeometrica(1, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, 2);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }
        
        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(1, 5),
                new FormaGeometrica(3, 3),
                new FormaGeometrica(2, 4),
                new FormaGeometrica(1, 2),
                new FormaGeometrica(2, 9),
                new FormaGeometrica(3, 2.75m),
                new FormaGeometrica(2, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, 2);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(1, 5),
                new FormaGeometrica(3, 3),
                new FormaGeometrica(2, 4),
                new FormaGeometrica(1, 2),
                new FormaGeometrica(2, 9),
                new FormaGeometrica(3, 2.75m),
                new FormaGeometrica(2, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, 1);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
        
        
    }
}
