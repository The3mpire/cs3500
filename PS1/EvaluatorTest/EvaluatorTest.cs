using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaEvaluator;

namespace EvaluatorTest
{
    class EvaluatorTest
    {
        static void Main(string[] args)
        {
            String s = "Hello\t I am              a \tdog\n.";
            Console.WriteLine(s);
            Console.Read();
            s = s.Replace(" ", String.Empty);
            s = s.Replace("\t", String.Empty);
            s = s.Replace("\n", String.Empty);
            Console.WriteLine(s);
            Console.Read();
            Console.Read();

        }
    }
}
