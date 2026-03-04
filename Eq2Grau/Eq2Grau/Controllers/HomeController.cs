using Eq2Grau.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eq2Grau.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// calcula das raízes de uma eq. 2º Grau
        /// </summary>
        /// <param name="a">parâmetro do x^2</param>
        /// <param name="b">parâmetro do x</param>
        /// <param name="c">parâmetro independente</param>
        /// <returns>vista</returns>
        public IActionResult Index(String a, String b, String c)
        {
            /*
                Algoritmo:
                1 - ler os parâmetros A,B,C
                2 - validar se os parâmetros são válidos
                    2.1 - A,B e C são números
                    2.2 - A!=0
                3 - se tudo estiver bem, posso fazer o cálculo
                    3.1 - Calcular o DELTA
                    3.2 - se DELTA >=0, raízes reais
                        3.2.1 - calcular raízes reais
                    3.3 - se DELTA <0, raízes complexas conjugadas
                        3.3.1 - calcular as raízes complexas
                    3.4 - Informar o utilizador das raízes calculadas
                    Senão, notificar o utilizador de como corrigir o problema



             */

            //2.1
            if (!float.TryParse(a, out float A))
            {
                // A não é número
                // falta ainda gerar a mensagem de erro, para ajudar o utilizador a corrigir o problema
                return View();
            }

            if (!float.TryParse(b, out float B))
            {
                // B não é número
                // falta ainda gerar a mensagem de erro, para ajudar o utilizador a corrigir o problema
                return View();
            }

            if (!float.TryParse(c, out float C))
            {
                // C não é número
                // falta ainda gerar a mensagem de erro, para ajudar o utilizador a corrigir o problema
                return View();
            }

            //2.2
            if(A == 0)
            {
                return View();
            }

            //3.1
            float delta = B * B - 4 * A * C;

            //3.2
            if (delta >= 0)
            {
                //3.2.1
                double x1 = (-B + Math.Sqrt(delta))/(2*A);
                double x2 = (-B - Math.Sqrt(delta)) / (2 * A);

                //3.4
                ViewBag.X1 = x1;
                ViewBag.X2 = x2;
            }

            //3.3
            if (delta < 0)
            {

            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
