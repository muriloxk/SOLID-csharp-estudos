# SOLID-csharp-estudos
Estudos dos principios SOLID em C#

    # Single Responsability Principle 

No projeto de Single Responsability Principle, vamos refatorar essa classe em outras classes dividindo suas responsabilidades e ganhando coesão no código, aqui ainda não vamos nos atentar aos outros principios. 

    public class CalculadoraDeSalario
    {
        public double calcula(Funcionario funcionario)
        {
            if (funcionario.Cargo is Desenvolvedor)
            {
                return dezOuVintePorcento(funcionario);
            }

            if (funcionario.Cargo is Dba || funcionario.Cargo is Tester)
            {
                return quinzeOuVinteCincoPorcento(funcionario);
            }

            throw new Exception("funcionario invalido");
        }

        private double dezOuVintePorcento(Funcionario funcionario)
        {
            if (funcionario.SalarioBase > 3000.0)
            {
                return funcionario.SalarioBase * 0.8;
            }
            else
            {
                return funcionario.SalarioBase * 0.9;
            }
        }

        private double quinzeOuVinteCincoPorcento(Funcionario funcionario)
        {
            if (funcionario.SalarioBase > 2000.0)
            {
                return funcionario.SalarioBase * 0.75;
            }
            else
            {
                return funcionario.SalarioBase * 0.85;
            }
        }
    }
    
      # Interface Segregation Principle

No projeto de Interface Segregation, refatoro o código abaixo utilizando o principio e o design pattern Observer. 

    
    
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

        public interface IAcaoAposGerarNota
    {
        void Executa(NotaFiscal nf);
    }

    public class Fatura
    {
        public double ValorMensal { get; set; }
        public string Cliente { get; private set; }

        public Fatura(double valorMensal, string cliente)
        {
            this.ValorMensal = valorMensal;
            this.Cliente = cliente;
        }
    }

        public class EnviadorDeEmail : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Enviando email");
        }
    }


    public class NotaFiscalDao : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Persistindo nota");
        }
    }

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


