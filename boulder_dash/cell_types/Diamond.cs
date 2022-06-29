using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boulder_dash
{
    class Diamond : Cell
    {
        int x, y;

        public Diamond(int i,int j)
        {
            x = i;
            y = j;
        }
        public override string Type()
        {
            return "D";
        }
        public override string Path()
        {
            return "Diamond";
        }
    }
}
