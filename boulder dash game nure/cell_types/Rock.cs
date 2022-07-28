using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace boulder_dash
{
    class Rock : Cell
    {
        
        public override string Type()
        {
            return "o";
        }

        public override string Path()
        {
            return "Rock";
        }
        public static bool Gravity(Point coords, List<List<Cell>> field, Dictionary<Point,string> changedList)
        {
            
            int heightField = field[0].Count;
            int x = coords.X;
            int y = coords.Y;


            bool isFalling = false;
            //під камінням
            while (y + 1 < heightField && (field[x][y + 1].Type() == " "))
            {

                changedList[new Point(x, y)] = new Empty().Path();
                changedList[new Point(x, y + 1)] = new Rock().Path();
                field[x][y] = new Empty();
                field[x][y + 1] = new Rock();
                isFalling = true;
                y++;
                
            }
            //якщо каміння до цього рухалось і під ним гравець, то програш
            if (y + 1 < heightField && field[x][y + 1].Type() == "I" && isFalling)
            {
                 return true;      
            }

            return false;
        }

    }
}
