using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// By Karla Kraiss
/// cs3500
/// Fall 2015
/// </summary>
namespace FormulaEvaluator
{
    /// <summary>
    /// A class meant to evaluate equations placed in String form
    /// </summary>
    public static class Evaluator
    {

        /// <summary>
        /// Takes in a string, and returns an integer value associated with that string
        /// </summary>
        /// <param name="v"></param>
        /// <returns>integer value of the string</returns>
        public delegate int Lookup(string v);

        /// <summary>
        /// Evaluates an equation in string format using infix notaiton, and returns the integer value that 
        /// results from the evaluation
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="variableEvaluator"></param>
        /// <returns>the value of the infix notation equation</returns>
        public static int Evaluate(string exp, Lookup variableEvaluator)
        {
            // Stacks
            Stack<int> valueStack = new Stack<int>();
            Stack<String> symbolStack = new Stack<String>();
            // equation variables
            int firstVal;
            int secondVal;
            string op;
            int parsedInt = 0;
            Regex varCheck = new Regex(@"^[A-Za-z]+[0-9]+$");
            string token = "";


            //removed the whitespace from the passed example
            removeWhiteSpace(exp);
            string[] substrings = Regex.Split(exp, "(\\()|(\\))|(-)|(\\+)|(\\*)|(/)");

            //loops through the entire array and analyzes the symbols to put on
            //the correct stacks
            for (int i = 0; i < substrings.Length; i++)
            {
                //variables for equation
                token = substrings[i];

                // token is an integer
                if (int.TryParse(token, out parsedInt))
                {
                    if(symbolStack.Count() < 1)
                    {
                        valueStack.Push(parsedInt);
                    }
                    //If * or / is at the top of the operator stack, pop the value stack, pop the operator stack, 
                    //and apply the popped operator to t and the popped number. Push the result onto the value stack.
                    else if (symbolStack.Peek() == "*" || symbolStack.Peek() == "/")
                    {
                        // check to make sure the valueStack holds a number
                        if (valueStack.Count < 1)
                        {
                            throw new ArgumentException("division by 0");
                        }

                        // perform the equation
                        firstVal = valueStack.Pop();
                        op = symbolStack.Pop();
                        secondVal = parsedInt;

                        // multiplication
                        if (op.Equals("*"))
                        {
                            valueStack.Push(firstVal * secondVal);
                        }
                        // division
                        else
                        {
                            valueStack.Push(firstVal / secondVal);
                        }
                    }

                    //Otherwise, push t onto the value stack.
                    else
                    {
                        valueStack.Push(parsedInt);
                    }
                }

                // TODO token is a variable

                //If looking up t reveals it has no value or if the value stack is empty, a division by zero results.
                else if (varCheck.IsMatch(token))
                {
                    int stringVal;
                    try
                    {
                        stringVal = variableEvaluator(token);
                    }
                    catch
                    {
                        throw new ArgumentException();
                    }
                    
                    //Proceed as above, using the looked-up value of t instead of t
                }

                // TODO token is a "+" or "-"
                else if (token.Equals("+") || token.Equals("-"))
                {
                    //If + or - is at the top of the operator stack, pop the value stack twice and
                    //the operator stack once. Apply the popped operator to the popped numbers. Push
                    //the result onto the value stack. Next, push t onto the operator stack

                    if(valueStack.Count <= 1)
                    {
                        throw new ArgumentException();
                    }
                }

                // TODO token is a "*"
                else if (token.Equals("*"))
                {
                    symbolStack.Push(token);
                }

                //TODO  token is a "/"
                else if (token.Equals("/"))
                {
                    symbolStack.Push(token);
                }

                // TODO token is a right parenthesis ")"
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

                // TODO token is a left parenthesis "("
                if (token.Equals("("))
                {
                    symbolStack.Push(token);
                }

            }

            //Operator stack is empty but valueStack has more than one token
            if(symbolStack.Count == 0 && valueStack.Count != 1)
            {
                
                throw new ArgumentException();
            }

            //Operator stack is not empty but valueStack contains more or less than two tokens
            else if(symbolStack.Count > 0 && valueStack.Count != 2)
            {
                throw new ArgumentException();
                //There should be exactly one operator on the operator stack, and it should be either + or -. 
                //There should be exactly two values on the value stack. Apply the operator to the two values 
                //and report the result as the value of the expression
            }


            return;



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        private static void removeWhiteSpace(String s)
        {
            s = s.Replace(" ", String.Empty);
            s = s.Replace("\t", String.Empty);
            s = s.Replace("\n", String.Empty);
        }
    }
}
