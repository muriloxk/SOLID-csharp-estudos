using System;

namespace Solid.OpenClosePrinciple
{
    class Program
    {
        static void Main(string[] args)
        { 
            ITabelaPreco tabelaPreco = new TabelaDePrecoPadrao(new DescontoAcimaDeCincoMil());
            IFrete transportadora = new Frete();

            var calculadoraDePrecos = new CalculadoraDePrecos(tabelaPreco, transportadora);
            Console.WriteLine(calculadoraDePrecos.Calcula(new Compra("Maringá", 500)));

            Console.ReadKey();
        }
    }
}
