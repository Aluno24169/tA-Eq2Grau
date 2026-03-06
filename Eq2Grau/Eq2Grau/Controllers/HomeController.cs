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
        /// <param name="A">parâmetro do x^2</param>
        /// <param name="B">parâmetro do x</param>
        /// <param name="C">parâmetro independente</param>
        /// <returns>vista</returns>
        public IActionResult Index(float A, float B, float C)
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

            if (Request.Method == "POST")
            {
                //2.2
                if (A == 0)
                {
                    ViewBag.Erro = "Parâmetro A não pode ser zero!";
                    return View();
                }

                //3.1
                float delta = B * B - 4 * A * C;

                //3.2
                if (delta >= 0)
                {
                    //3.2.1
                    double x1 = (-B + Math.Sqrt(delta)) / (2 * A);
                    double x2 = (-B - Math.Sqrt(delta)) / (2 * A);

                    //3.4
                    ViewBag.X1 = "X1 = " + x1;
                    ViewBag.X2 = "X2 = " + x2;
                }
                //3.3
                else
                {
                    double x_r = -B / (2 * A);
                    double x_i = Math.Sqrt((delta * (-1))) / (2 * A);

                    ViewBag.Erro = "Raizes complexas";
                    ViewBag.X1 = "X1 = " + x_r + "-" + x_i + "i";
                    ViewBag.X2 = "X2 = " + x_r + "+" + x_i + "i";
                }

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
