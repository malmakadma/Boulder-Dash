﻿using System;
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

        //method moving Player
        public Point Move(List<List<Cell>> field, Point direction, Point cur_point, Dictionary <Point,string> changed_list)
        {
            //перевірка щоб не вийти за межі поля вліво/вправо
            if ((cur_point.X + direction.X >= field.Count) || (cur_point.X + direction.X < 0))
            {
                return cur_point;
            }
            //вгору/вниз
            if ((cur_point.Y + direction.Y >= field[0].Count) || (cur_point.Y + direction.Y < 0))
            {
                return cur_point;
            }
            
            Point pre_point = cur_point;
            cur_point.X += direction.X;
            cur_point.Y += direction.Y;
            
            if (field[cur_point.X][cur_point.Y].Type()=="D")
            {
                diamond_count++;
            }
            else
            {
                if (field[cur_point.X][cur_point.Y].Type() == "o")
                {
                    //перевірка виходу впаво/вліво
                    if ((cur_point.X + direction.X >= field.Count) || (cur_point.X + direction.X < 0))
                    {
                        return pre_point;
                    }
                    //вгору вниз
                    if ((cur_point.Y + direction.Y >= field[0].Count) || (cur_point.Y + direction.Y < 0))
                    {
                        return pre_point;
                    }
                    //якщо наступна клітинка вільна, штовхає каміння
                    if (field[cur_point.X + direction.X][cur_point.Y + direction.Y].Type() == " ")
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
            // додаємо в лист зі змінними клітинок координати гравця та стр "Player"
            changed_list.Add(cur_point, this.Path());
            // додаємо мтнулі координати гравця та стр пустої клітинки,
            changed_list.Add(pre_point, new Empty().Path());
            //clear the cell after Player
            field[pre_point.X][pre_point.Y] = new Empty();

            field[cur_point.X][cur_point.Y] = new Player();

            return cur_point;
        }
    }
}