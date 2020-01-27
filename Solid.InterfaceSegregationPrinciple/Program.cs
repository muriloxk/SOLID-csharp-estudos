using System;
using System.Collections.Generic;

namespace Solid.InterfaceSegregationPrinciple
{
    public class Program
    {
        static void Main(string[] args)
        {
            var geradorNf = new GeradorDeNotaFiscal(new List<IAcaoAposGerarNota>()
            {
                new NotaFiscalDao(),
                new EnviadorDeEmail()
            });

            geradorNf.Gera(new Fatura(300, "Murilo"));

            Console.ReadKey();
        }
    }
}
