using System.Collections.Generic;

namespace Solid.ExercicioEncapsulamento
{
    public class ProcessadorDeBoletos
    {
        public void Processa(List<Boleto> boletos, Fatura fatura)
        {
            foreach (Boleto boleto in boletos)
            {
                fatura.AdicionarPagamento(boleto.Valor, MeioDePagamento.BOLETO);
            }
        }
    }
}
