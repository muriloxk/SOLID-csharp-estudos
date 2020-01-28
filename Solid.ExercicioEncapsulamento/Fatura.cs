using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Solid.ExercicioEncapsulamento
{
    public class Fatura
    {
        public string Cliente { get; private set; }
        public double Valor { get; set; }
        public double ValorPago { get; private set; }
        public bool Pago
        {
            get
            {
                return ValorPago >= Valor;
            }

            private set { }
        }

        public IList<Pagamento> _pagamentos;

        public IReadOnlyCollection<Pagamento> Pagamentos
        {
            get
            {
                return new ReadOnlyCollection<Pagamento>(_pagamentos);
            }
        }

        public Fatura(string cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
            _pagamentos = new List<Pagamento>();
            Pago = false;
        }

        public void AdicionarPagamento(double valor, MeioDePagamento forma)
        {
            _pagamentos.Add(new Pagamento(valor, forma));
            ValorPago += valor;
        }
    }
}
