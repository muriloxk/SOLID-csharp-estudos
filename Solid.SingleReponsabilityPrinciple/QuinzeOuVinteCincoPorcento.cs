namespace Solid.SingleReponsabilityPrinciple
{
    public class QuinzeOuVinteCincoPorcento : IRegraCalculaSalario
    {
        public double Calcula(Funcionario funcionario)
        {
            if (funcionario.SalarioBase > 2000.0)
                return funcionario.SalarioBase * 0.75;

            return funcionario.SalarioBase * 0.85;
        }
    }
}
