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
    internal class ConstantNode : BaseNode
    {
        // constant node of type base node
        public ConstantNode(double number)
        {
            opValue = number;
        }

    }
}
