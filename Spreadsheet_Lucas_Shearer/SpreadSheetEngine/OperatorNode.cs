/*Lucas Shearer
10956939
321
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    internal class OperatorNode : BaseNode
    {//this class is for our operator nodes of type basenode

        private char op;
        private BaseNode left, right;

        public OperatorNode(char Op, BaseNode Left, BaseNode Right)
        {
            op = Op;
            left = Left;
            right = Right;
        }


        public BaseNode Left
        {
            get { return left; }
        }
        public BaseNode Right
        {
            get { return right; }
        }
   
        public char Op
        {
            get { return op; }
        }

    }
}
