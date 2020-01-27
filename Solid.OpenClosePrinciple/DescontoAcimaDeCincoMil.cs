namespace Solid.OpenClosePrinciple
{
    public class DescontoAcimaDeCincoMil : IRegraDeDesconto
    {
        public double CalcularDesconto(double valor)
        {
            if (valor > 5000)
                return 0.03;

            return 0;
        }
    }
}
