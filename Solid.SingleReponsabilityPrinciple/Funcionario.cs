namespace Solid.SingleReponsabilityPrinciple
{
    public class Funcionario
    {
        public Funcionario(Cargo cargo, double salarioBase)
        {
            Cargo = cargo;
            SalarioBase = salarioBase;
        }

        public Cargo Cargo { get; set; }
        public double SalarioBase { get; set; }

        public double CalcularSalario()
        {
            return Cargo.RegraCalcularSalario.Calcula(this);
        }
    }
}
