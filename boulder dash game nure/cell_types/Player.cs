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
        int diamondCount; 
        public Player(){ }

        public override string Type()
        {
            return "I";
        }

        public int DiamondCount
        {
            get => diamondCount; 
        }
        public override string Path()
        {
            return "Player";
        }

        //method moving Player
        public Point Move(List<List<Cell>> field, Point direction, Point curPoint, Dictionary <Point,string> changedList) 
        {
            int widthField = field.Count;
            int heightField = field[0].Count;

            //перевірка щоб не вийти за межі поля вліво/вправо
            if ((curPoint.X + direction.X >= widthField) || (curPoint.X + direction.X < 0)) 
            {
                return curPoint;
            }
            //вгору/вниз
            if ((curPoint.Y + direction.Y >= heightField) || (curPoint.Y + direction.Y < 0)) 
            {
                return curPoint;
            }
            
            Point prePoint = curPoint; 
            curPoint.X += direction.X;
            curPoint.Y += direction.Y;
            
            if (field[curPoint.X][curPoint.Y].Type() == "D")
            {
                diamondCount++;
            }
            else
            {
                if (field[curPoint.X][curPoint.Y].Type() == "o")
                {
                    //перевірка виходу впаво/вліво
                    if ((curPoint.X + direction.X >= widthField) || (curPoint.X + direction.X < 0))
                    {
                        return prePoint;
                    }
                    //вгору вниз
                    if ((curPoint.Y + direction.Y >= heightField) || (curPoint.Y + direction.Y < 0))
                    {
                        return prePoint;
                    }
                    //якщо наступна клітинка вільна, штовхає каміння
                    if (field[curPoint.X + direction.X][curPoint.Y + direction.Y].Type() == " ")
                    {
                        field[curPoint.X + direction.X][curPoint.Y + direction.Y] = new Rock();
                        changedList.Add(new Point(curPoint.X + direction.X, curPoint.Y + direction.Y), new Rock().Path());
                    }
                    else
                    {
                        return prePoint;
                    }
                }
            }
            // додаємо в лист зі змінними клітинок координати гравця та стр "Player"
            changedList.Add(curPoint, this.Path());
            // додаємо минулі координати гравця та стр пустої клітинки,
            changedList.Add(prePoint, new Empty().Path());
            //clear the cell after Player
            field[prePoint.X][prePoint.Y] = new Empty();

            field[curPoint.X][curPoint.Y] = new Player();

            return curPoint;
        }
    }
}
