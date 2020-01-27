using System;

namespace Solid.OpenClosePrinciple
{
    public class TabelaDePrecoPadrao : ITabelaPreco
    {
        private IRegraDeDesconto RegraDeDesconto { get; set; }

        public TabelaDePrecoPadrao(IRegraDeDesconto regraDeDesconto)
        {
            if (regraDeDesconto == null)
                throw new ArgumentNullException("Regra de desconto não pode ser nulo!");

            RegraDeDesconto = regraDeDesconto;
        }

        public double DescontoPara(double valor)
        {
            return RegraDeDesconto.CalcularDesconto(valor);
        }
    }
}
