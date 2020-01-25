namespace Solid.SingleReponsabilityPrinciple
{
    public abstract class Cargo
    {
        protected Cargo(IRegraCalculaSalario regra)
        {
            RegraCalcularSalario = regra;
        }

        public IRegraCalculaSalario RegraCalcularSalario { get; private set; }
    }
}
