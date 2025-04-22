using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace calculo_preco_fabrica_paralelo
{
    internal class Program
    {
        private static double val_ipi;
        private static double val_distr;
        static void Main(string[] args)
        {
            double prc_fabr, prc_total;
            Console.Write("Informe o preço de fábrica: ");
            prc_fabr = double.Parse(Console.ReadLine());

            var t1 = new Thread(() => calc_ipi(prc_fabr));
            var t2 = new Thread(() => calc_distr(prc_fabr));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            prc_total = prc_fabr + val_ipi + val_distr;

            Console.WriteLine("O valor total do veículo é de R$" + Math.Round(prc_total, 2));
            Console.WriteLine("O valor ao distribuidor é de  R$" + Math.Round(val_distr, 2));
            Console.WriteLine("O valor relativo ao IPI é de  R$" + Math.Round(val_ipi, 2));
        }
        private static void calc_ipi(double prc_fabr)
        {
            if (prc_fabr <= 200000.00)
            {
                val_ipi = 0.00;
            }
            else if (prc_fabr <= 400000.00)
            {
                val_ipi = prc_fabr * 0.15;
            }
            else
            {
                val_ipi = prc_fabr * 0.20;
            }
        }

        private static void calc_distr(double prc_fabr)
        {
            if (prc_fabr <= 150000.00)
            {
                val_distr = prc_fabr * 0.03;
            }
            else if (prc_fabr <= 350000.00)
            {
                val_distr = prc_fabr * 0.08;
            }
            else
            {
                val_distr = prc_fabr * 0.12;
            }
        }
    }
}