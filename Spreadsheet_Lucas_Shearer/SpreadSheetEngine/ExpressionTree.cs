/*Lucas Shearer
10956939
321
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace CptS321
{

    public class ExpressionTree
    {//this is our expression tree class for determining cell values etc
        private BaseNode root;
        protected Dictionary<string, double> variableDict;
        public string exp;


        //Constructor that constructs an expression tree using the expression provided
        public ExpressionTree(string expression)
        {
            exp = expression;

            //Clear the dictionary when a new tree is made
            variableDict = new Dictionary<string, double>();

            //compile expression to the root node
            this.root = Compile(expression);

        }


        //Implement this member function with no parameters that evaluates the expression to a double value
        public double Eval()
        {
            if (root != null)
            {
                return Eval(root);
            }
            else
            {
                return double.NaN;
            }
        }

        //Sets the specified variable with the value in the ExpTree variables dictionary
        public void SetVar(string varName, double varValue)
        {
            variableDict[varName] = varValue;
        }

        private double Eval(BaseNode node)
        {
            //Evaluate based on the kind of node

            ConstantNode constnode = node as ConstantNode;
            if (constnode != null)
            {
                return constnode.OpValue;
            }

            VariableNode varnode = node as VariableNode;
            if (varnode != null)
            {
                // used to be a try/catch, but now we set every new variable to 0 when the tree is made, so there will always be a value to obtain.
                return variableDict[varnode.Name];
            }

            OperatorNode opnode = node as OperatorNode;
            if (opnode != null)
            {
                switch (opnode.Op)
                {
                    case '+':
                        return Eval(opnode.Left) + Eval(opnode.Right);

                    case '-':
                        return Eval(opnode.Left) - Eval(opnode.Right);

                    case '*':
                        return Eval(opnode.Left) * Eval(opnode.Right);

                    case '/':
                        return Eval(opnode.Left) / Eval(opnode.Right);
                }

            }

            return 0;
        }

        //Method to find the lowest precedence operator in the expression
        private static int GetLowOpIndex(string exp)
        {
            // need a counter for the parenthesis, if the counter isn't at 0, then we are inside a set of parenthesis
            int parenthCounter = 0;
            // index of the lowest precedence op. Initialize to -1. No op = -1
            int index = -1;

            //Start from the end of the expression and traverse
            for (int i = exp.Length - 1; i >= 0; i--)
            {
                switch (exp[i])
                {
                    case ')':
                        //closing parenthesis, decrease count
                        parenthCounter--;
                        break;
                    case '(':
                        //opening parenthesis, increase count
                        parenthCounter++;
                        break;
                    //Addition and subtraction have the same precedence
                    case '+':
                    case '-':
                        // check to see if we are in parenthesis or not, do nothing if we are
                        if (parenthCounter == 0)
                        {
                            //this is the lowest precedence op, return it's index
                            return i;
                        }
                        break;

                    // multiplication and division have the same precedence
                    case '*':
                    case '/':
                        //need the check the parenthesis counter and the index. If the index isn't -1, there is another op before this one
                        if (parenthCounter == 0 && index == -1)
                        {
                            //keep 
                            index = i;
                        }
                        break;
                }

            }
            //if the parentheses counter is not 0, we have a problem.
            if (parenthCounter != 0)
            {
                // -2 will be our indicator that there is a parentheses problem
                return -2;
            }

            //return the index of a * or / because there were no + or -
            return index;

        }

        //Build node 
        private BaseNode BuildSimple(string term)
        {
            double num;
            //if term is a number, put in a constNode
            if (double.TryParse(term, out num))
            {
                return new ConstantNode(num);
            }
            //if term is a variable, put in varNode -- will not start with a number!
            //get the entry for the variable into the dictionary and set to equal 0
            SetVar(term, 0);
            return new VariableNode(term);

        }

        //Compile function
        private BaseNode Compile(string exp)
        {
            //Remove any spaces from the expression
            exp = exp.Replace(" ", "");

            //check for the expression to be totally enclosed in ()
            if (exp[0] == '(')
            {
                //counter for parenthesis
                int counter = 1;

                for (int i = 1; i < exp.Length; i++)
                {
                    if (exp[i] == ')')
                    {
                        //deincrement counter
                        counter--;
                        //if we are not in the middle of a set of parenthesis count will be 0
                        if (counter == 0)
                        {
                            //if we are at the end of the expression
                            if (i == exp.Length - 1)
                            {
                                //call compile on the rest of the string
                                return Compile(exp.Substring(1, exp.Length - 2));
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (exp[i] == '(')
                    {
                        //increment counter
                        counter++;
                    }
                }

                //If we get to the end and the parenthesis counter is not 0, we have an odd number, do not build tree.
                if (counter != 0)
                {
                    Console.WriteLine("Imablanced parenthesis.");
                    exp = "Error";
                    return null;
                }
            }



            //Call GetLowOpIndex and build an op node for character at that index
            int index = GetLowOpIndex(exp);
            //check to make sure there is actually an operator
            if (index != -1 && index != -2)
            {
                return new OperatorNode(exp[index], Compile(exp.Substring(0, index)), Compile(exp.Substring(index + 1)));
            }
            else if (index == -2)
            {
                // There are a bad number of parenthesis
                Console.WriteLine("Imbalanced parenthesis.");
                this.exp = "Error";
                return null;
            }

            return BuildSimple(exp);

        }

        public string[] GetVariables()
        {
            return variableDict.Keys.ToArray();
        }
    }

}
