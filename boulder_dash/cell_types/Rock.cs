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
        public bool Gravity(Point coords, List<List<Cell>> field, Dictionary<Point,string> changed_list)
        {
            int x = coords.X;
            int y = coords.Y;
            if (y+1 >= field[0].Count)
            {
                return false;
            }
            bool moving = false;
            while (y+1<field[0].Count && (field[x][y + 1].Type() == " " || field[x][y + 1].Type() == "I"))
            {
                if (field[x][y + 1].Type() == " " || field[x][y+1].Type()=="I")
                {
                    
                    if (field[x][y+1].Type() == "I")
                    {
                        if (moving)
                        {
                            if (changed_list.ContainsKey(new Point(x, y)))
                            {
                                changed_list[new Point(x, y)] = new Empty().Path();
                            }
                            else
                            {
                                changed_list.Add(new Point(x, y), new Empty().Path());
                            }
                            if (changed_list.ContainsKey(new Point(x, y + 1)))
                            {
                                changed_list[new Point(x, y + 1)] = new Rock().Path();
                            }
                            else
                            {
                                changed_list.Add(new Point(x, y + 1), new Rock().Path());
                            }
                            
                            return true;
                        }
                        else
                        {
                            return false;
                            
                        }
                    }
                    if (changed_list.ContainsKey(new Point(x, y)))
                    {
                        changed_list[new Point(x, y)] = new Empty().Path();
                    }
                    else
                    {
                        changed_list.Add(new Point(x, y), new Empty().Path());
                    }
                    if (changed_list.ContainsKey(new Point(x, y+1)))
                    {
                        changed_list[new Point(x, y+1)] = new Rock().Path();
                    }
                    else
                    {
                        changed_list.Add(new Point(x, y+1), new Rock().Path());
                    }
                    field[x][y] = new Empty();
                    field[x][y + 1] = new Rock();
                    moving = true;
                    y++;
                }
            }
            
            return false;
        }

    }
}
