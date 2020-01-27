namespace Solid.InterfaceSegregationPrinciple
{
    public class NotaFiscal
    {
        public double ValorBruto { get; private set; }
        public double Impostos { get; private set; }
        public double ValorLiquido
        {
            get
            {
                return this.ValorBruto - this.Impostos;
            }

        }

        public NotaFiscal(double valorBruto, double impostos)
        {
            // TODO: Complete member initialization
            this.ValorBruto = valorBruto;
            this.Impostos = impostos;
        }
    }
}
