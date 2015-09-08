using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormulaEvaluator
{
    /// <summary>
    /// fancy fancy
    /// </summary>
    public static class Evaluator
    {

        public delegate int Lookup(String v);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="variableEvaluator"></param>
        /// <returns></returns>
        public static int Evaluate(String exp, Lookup variableEvaluator)
        {

            Stack<int> valueStack = new Stack<int>();
            Stack<char> symbolStack = new Stack<char>();

            //removed the whitespace from the passed example
            removeWhiteSpace(exp);
            string[] substrings = Regex.Split(exp, "(\\()|(\\))|(-)|(\\+)|(\\*)|(/)");

            //loops through the entire array and analyzes the symbols to put on
            //the correct stacks
            for(int i = 0; i < substrings.Length; i++)
            {
                //variables for string
                String token = substrings[i];
                int parsedInt = 0;

                // token is an integer
                if (int.TryParse(token, out parsedInt))
                {
                    //If * or / is at the top of the operator stack, pop the value stack, pop the operator stack, 
                    //and apply the popped operator to t and the popped number. Push the result onto the value stack.

                    //Otherwise, push t onto the value stack.
                    valueStack.Push(token);
                }

                // token is a variable
                else if ()
                {
                    //Proceed as above, using the looked-up value of t instead of t
                }
                // token is a "+" or "-"
                else if (token.Equals("+") || token.Equals("-"))
                {
                    //If + or - is at the top of the operator stack, pop the value stack twice and
                    //the operator stack once. Apply the popped operator to the popped numbers. Push
                    //the result onto the value stack. Next, push t onto the operator stack
                }

                // token is a "*"
                else if (token.Equals("*"))
                {
                    symbolStack.Push('*');
                }

                // token is a "/"
                else if (token.Equals("/"))
                {
                    symbolStack.Push('/');
                }

                // token is a right parenthesis ")"
                if (token.Equals(")"))
                {
                    //If + or - is at the top of the operator stack, pop the value stack twice and the
                    //operator stack once. Apply the popped operator to the popped numbers. Push the result
                    //onto the value stack.

                    // Next, the top of the operator stack should be a (.Pop it.

                    // Finally, if *or / is at the top of the operator stack, pop the value stack twice and 
                    //the operator stack once. Apply the popped operator to the popped numbers. Push the result 
                    //onto the value stack.
                }

                // token is a left parenthesis "("
                if (token.Equals("("))
                {
                    symbolStack.Push('(');
                }

            }


            return 0;

            
            
        }

        private static void removeWhiteSpace(String s)
        {
            s = s.Replace(" ", String.Empty);
            s = s.Replace("\t", String.Empty);
            s = s.Replace("\n", String.Empty);
        }

    }
}
