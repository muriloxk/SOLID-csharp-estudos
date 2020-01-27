namespace Solid.OpenClosePrinciple
{
    public class CalculadoraDePrecos
    {
        private ITabelaPreco TabelaPreco { get; set; }
        private IFrete Frete { get; set; }

        public CalculadoraDePrecos(ITabelaPreco tabelaPreco, IFrete frete)
        {
            TabelaPreco = tabelaPreco;
            Frete = frete;
        }

        public double Calcula(Compra produto)
        {
            double desconto = TabelaPreco.DescontoPara(produto.Valor);
            double frete = Frete.Para(produto.Cidade);

            return produto.Valor * (1 - desconto) + frete;
        }
    }
}
