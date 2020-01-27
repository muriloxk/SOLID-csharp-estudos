namespace Solid.OpenClosePrinciple
{
    public class Frete : IFrete
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
}
