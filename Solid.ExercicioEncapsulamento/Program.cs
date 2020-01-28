using System;
using System.Collections.Generic;

namespace Solid.ExercicioEncapsulamento
{
    class Program
    {
        static void Main(string[] args)
        {
            var boletos = new List<Boleto>()
            {
                new Boleto(300),
                new Boleto(400),
                new Boleto(500),
            };

            var fatura = new Fatura("Murilo", 3000);
            fatura.AdicionarPagamento(1000, MeioDePagamento.BOLETO);
            Console.WriteLine("Boleto está pago? " + fatura.Pago);
            fatura.AdicionarPagamento(3000, MeioDePagamento.BOLETO);
            Console.WriteLine("Boleto está pago? " + fatura.Pago);

            Console.ReadKey();
        }
    }
}
