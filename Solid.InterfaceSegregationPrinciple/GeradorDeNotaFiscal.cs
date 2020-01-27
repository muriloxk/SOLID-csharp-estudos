using System.Collections.Generic;

namespace Solid.InterfaceSegregationPrinciple
{
    public class GeradorDeNotaFiscal
    {
        private IList<IAcaoAposGerarNota> AcoesAposGerarNota { get; set; }

        public GeradorDeNotaFiscal(IList<IAcaoAposGerarNota> acoesAposGerarNotas)
        {
            AcoesAposGerarNota = acoesAposGerarNotas;
        }

        public NotaFiscal Gera(Fatura fatura)
        {
            double valor = fatura.ValorMensal;
            NotaFiscal nf = new NotaFiscal(valor, ImpostoSimplesSobreO(valor));
            ExecutarAcoesAposGerarNota(nf);

            return nf;
        }

        private void ExecutarAcoesAposGerarNota(NotaFiscal nf)
        {
            foreach (var acao in AcoesAposGerarNota)
            {
                acao.Executa(nf);
            }
        }

        private double ImpostoSimplesSobreO(double valor)
        {
            return valor * 0.06;
        }
    }
}
