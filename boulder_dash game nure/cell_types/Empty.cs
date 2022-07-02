using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boulder_dash
{
    
        class Empty : Cell
        {
            public override string Type()
            {
                return " ";
            }
        public override string Path()
        {
            return "Empty";
        }
    }

}
