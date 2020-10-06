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
    internal abstract class BaseNode
    {
        protected string name;
        protected double opValue;
   
        //method for name manipulation
        public double OpValue
        {
            get { return opValue; }
            set
            {
                if (opValue == value)
                    return;

                opValue = value;
            }
        }
        //method for name manipulation
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                    return;

                name = value;
            }
        }

    }
}
