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
    
    
  # Open/close Principle e Dependency inversion principle  

No projeto de open/close principle é refatorado o codigo abaixo e acabamos utilizando o principio de inversão de depêndencia também. 
    
    public class Compra
    {
        public string Cidade { get; set; }
        public double Valor { get; set; }
    }

    public class CalculadoraDePrecos
    {
        public double Calcula(Compra produto)
        {
            TabelaDePrecoPadrao tabela = new TabelaDePrecoPadrao();
            Frete correios = new Frete();

            double desconto = tabela.DescontoPara(produto.Valor);
            double frete = correios.Para(produto.Cidade);

            return produto.Valor * (1 - desconto) + frete;
        }
    }
     public class TabelaDePrecoPadrao
    {
        public double DescontoPara(double valor)
        {
            if(valor>5000) return 0.03;
            if(valor>1000) return 0.05;
            return 0;
        }
    }

    public class Frete
    {
        public double Para(string cidade)
        {

            if ("SAO PAULO".Equals(cidade.ToUpper()))
            {
                return 15;
            }
            return 30;
        }
    }

  # Open/close Encapsulamento 

No projeto exercicio encapsulamento, refatoramos esse código encapsulando regras e propriedades
    

     public class ProcessadorDeBoletos
    {
         public void Processa(List<Boleto> boletos, Fatura fatura) 
         {
            double total = 0;

            foreach(Boleto boleto in boletos) {
                Pagamento pagamento = new Pagamento(boleto.Valor, MeioDePagamento.BOLETO);
                fatura.Pagamentos.Add(pagamento);

                total += boleto.Valor;
            }

            if(total >= fatura.Valor) {
                fatura.Pago = true;
            }
        }
    }

    public class Boleto
    {
        public double Valor { get; private set; }

        public Boleto(double valor)
        {
            this.Valor = valor;
        }
    }

    public class Fatura
    {
        public string Cliente { get; private set; }
        public double Valor { get; set; }
        public List<Pagamento> Pagamentos { get; private set; }
        public bool Pago { get; set; }

        public Fatura(string cliente,double valor)
        {
            this.Cliente = cliente;
            this.Valor = valor;
            this.Pagamentos = new List<Pagamento>();
            this.Pago = false;
        }
    }

    public enum MeioDePagamento
    {
        BOLETO,
        CARTAO
    }

    public class Pagamento
    {
        public double Valor { get; private set; }
        public MeioDePagamento Forma { get; private set; }

        public Pagamento(double valor, MeioDePagamento forma)
        {
            // TODO: Complete member initialization
            this.Valor = valor;
            this.Forma = forma;
        }
    }
    
    
   # Liskov substitution principle 
   
  No projeto de Liskov Substitution principle, temos que refatorar esse código para que o código do main não seja quebrado por uma herança mal feita.
    
    public class ProcessadorDeInvestimentos {

    static void Main(string[] args)
        {
            IList<ContaComum> contas = ContasDoBanco();

            foreach (ContaComum conta in contas)
            {
                conta.somaInvestimento();

                Console.WriteLine("Novo saldo: " + conta.Saldo );
            }

            Console.ReadLine();
        }

        private static IList<ContaComum> ContasDoBanco() {
            List<ContaComum> contas = new List<ContaComum>();
            contas.Add(umaContaComum(100));
            contas.Add(umaContaComum(150));
            contas.Add(umaContaEstudante(100));
            return contas;
        }

        private static ContaEstudante umaContaEstudante(double saldo)
        {
            ContaEstudante conta = new ContaEstudante();
            conta.Deposita(saldo);
            return conta;
        }

        private static ContaComum umaContaComum(double saldo)
        {
            ContaComum conta = new ContaComum();
            conta.Deposita(saldo);
            return conta;
        }
}

      class ContaEstudante : ContaComum
    {
        public int Milhas { get; private set; }

        public override void Deposita(double valor)
        {
            base.Deposita(valor);
            this.Milhas += (int)valor;
            throw new ArgumentException();
        }
    }

      class ContaComum
    {
        public double Saldo { get; private set; }

        public ContaComum()
        {
            this.Saldo = 0;
        }

        public virtual void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public void Saca(double valor)
        {
            if (valor <= this.Saldo)
            {
                this.Saldo -= valor;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void somaInvestimento()
        {
            this.Saldo += this.Saldo * 0.01;
        }
    }

