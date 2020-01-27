using System;

namespace Solid.SingleReponsabilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var desenvolvedor = new Funcionario(new Desenvolvedor(), 2000);
            var dba = new Funcionario(new Dba(), 4000);
            var tester = new Funcionario(new Tester(), 2000);

            Console.WriteLine("Desenvolvedor: " + desenvolvedor.CalcularSalario());
            Console.WriteLine("Dba : " + dba.CalcularSalario());
            Console.WriteLine("Tester" + tester.CalcularSalario());

            Console.ReadKey();
        }
    }
}
