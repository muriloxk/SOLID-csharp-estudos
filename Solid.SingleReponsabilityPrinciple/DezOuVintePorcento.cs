namespace Solid.SingleReponsabilityPrinciple
{
    public class DezOuVintePorcento : IRegraCalculaSalario
    {
        public double Calcula(Funcionario funcionario)
        {
            if (funcionario.SalarioBase > 3000.0)
                return funcionario.SalarioBase * 0.8;

            return funcionario.SalarioBase * 0.9;
        }
    }
}
