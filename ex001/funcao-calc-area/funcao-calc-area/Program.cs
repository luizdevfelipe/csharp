using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funcao_calc_area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opc;
            float lado, alt_tri, base_tri, area;
            string leitura;
            
            Console.WriteLine("1 - Calcular a área do quadrado.");
            Console.WriteLine("2 - Calcular a área do triângulo.");
            Console.Write("Sua opção (1/2) : ");
            leitura = Console.ReadLine();
            opc = int.Parse(leitura);

            if (opc == 1) {
                Console.Write("Digite o lado do quadrado: ");
                leitura = Console.ReadLine();
                lado = int.Parse(leitura);
                area = calc_area_quad(lado);
            } else if (opc == 2) {
                Console.Write("Digite a base do triângulo: ");
                leitura = Console.ReadLine();
                base_tri = int.Parse(leitura);

                Console.Write("Digite a altura do triângulo: ");
                leitura = Console.ReadLine();
                alt_tri = int.Parse(leitura);

                area = calc_area_tria(base_tri, alt_tri);

            } else {
                Console.WriteLine("Opção digitada inválida!");
                return;
            }

            Console.WriteLine("A área é de " + Math.Round(area, 1));
        }

        static float calc_area_quad(float lado) 
        {
            return lado * lado;
        }

        static float calc_area_tria(float base_tri, float alt_tri)
        {
            return base_tri * alt_tri / 2;
        }
    }
}
