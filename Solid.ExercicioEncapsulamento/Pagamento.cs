namespace Solid.ExercicioEncapsulamento
{
    public class Pagamento
    {
        public double Valor { get; private set; }
        public MeioDePagamento Forma { get; private set; }

        public Pagamento(double valor, MeioDePagamento forma)
        {

            Valor = valor;
            Forma = forma;
        }
    }
}
