using System;

namespace Solid.InterfaceSegregationPrinciple
{
    public class EnviadorDeEmail : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Enviando email");
        }
    }
}
