using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boulder_dash
{
    abstract class Cell
    {
        abstract public string Type();
        abstract public string Path();
    }
}
