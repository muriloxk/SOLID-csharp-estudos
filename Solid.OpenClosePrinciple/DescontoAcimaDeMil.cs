namespace Solid.OpenClosePrinciple
{
    public class DescontoAcimaDeMil : IRegraDeDesconto
    {
        public double CalcularDesconto(double valor)
        {
            if (valor > 1000)
                return 0.03;

            return 0;
        }
    }
}
