using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace boulder_dash
{
    class Player : Cell
    {
        int diamond_count;
        public Player(){ }

        public override string Type()
        {
            return "I";
        }

        public int Diamond_count
        {
            get => diamond_count;
        }
        public override string Path()
        {
            return "Player";
        }

        //метод переміщення Player
        public Point Move(List<List<Cell>> field, Point direction, Point cur_point, Dictionary <Point,string> changed_list)
        {
            if ((cur_point.X + direction.X>= field.Count) || (cur_point.X+direction.X<0))
            {
                return cur_point;
            }
            if ((cur_point.Y + direction.Y >= field[0].Count) || (cur_point.Y + direction.Y < 0))
            {
                return cur_point;
            }
            
            Point pre_point = cur_point;
            cur_point.X+= direction.X;
            cur_point.Y+= direction.Y;
            
            if (field[cur_point.X][cur_point.Y].Type()=="D")
            {
                diamond_count++;
            }
            else
            {
                if (field[cur_point.X][cur_point.Y].Type() == "o")
                {
                    if ((cur_point.X + direction.X >= field.Count) || (cur_point.X + direction.X < 0))
                    {
                        return pre_point;
                    }
                    if ((cur_point.Y + direction.Y >= field[0].Count) || (cur_point.Y + direction.Y < 0))
                    {
                        return pre_point;
                    }
                    if (field[cur_point.X + direction.X][cur_point.Y+direction.Y].Type()==" ")
                    {
                        field[cur_point.X + direction.X][cur_point.Y + direction.Y] = new Rock();
                        changed_list.Add(new Point(cur_point.X + direction.X, cur_point.Y + direction.Y), new Rock().Path());
                    }
                    else
                    {
                        return pre_point;
                    }
                }
            }

            changed_list.Add(cur_point, this.Path());
            changed_list.Add(pre_point, new Empty().Path());
            field[pre_point.X][pre_point.Y] = new Empty();//clear the cell after Player

            field[cur_point.X][cur_point.Y] = new Player();

            return cur_point;
        }
    }
}
