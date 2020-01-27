namespace Solid.OpenClosePrinciple
{
    public class Compra
    {
        public Compra(string cidade, double valor)
        {
            Cidade = cidade;
            Valor = valor;
        }

        public string Cidade { get; set; }
        public double Valor { get; set; }
    }
}
