using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace boulder_dash
{
    class Field
    {
        List<List<Cell>> field;
        int width, height;
        Point playerPoint; 
        Player player;
        bool isGameContinue; 
        int generalDiamonds; 

        public Field(int l = 1)
        {
            field = new List<List<Cell>>();
            
            generalDiamonds = 0;
            
            player = new Player();
            playerPoint = new Point(0, 6);
            generateLvl(l); 
            isGameContinue = true;

        }

        public Point PlayerPoint { 
            get => playerPoint; 
        }

        public int Width
        {
            get => width;
        }

        public int Height
        {
            get => height;
        }

        public List<List<Cell>> accessToField 
        {
            get => field;
        }

        public int Diamonds()
        {
            return player.DiamondCount;
        }



        private void generateLvl(int l) 
        {
            List<string> lvlField = new List<string>(); 
            string lvl = "level" + l.ToString() + ".txt";
            if (File.Exists(lvl))
            {
                if (new FileInfo(lvl).Length != 0)
                {
                    using (StreamReader streamReader = new StreamReader(lvl))
                    {
                        string line;
                        while ((line = streamReader.ReadLine())!= null) {
                            lvlField.Add(line);
                        }
                    }
                }
            }

            width = lvlField.Count;
            height = lvlField[0].Length;

            for (int i = 0; i < width; i++)
            {
                field.Add(new List<Cell>());
                for (int j = 0; j < height; j++)
                {

                    field[i].Add(new Empty());
                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    switch (lvlField[i][j])
                    {
                        case 'o':
                            field[i][j] = new Rock();
                            break;
                        case ' ':
                            field[i][j] = new Empty();
                            break;
                        case 'D':
                            field[i][j] = new Diamond(i, j);
                            generalDiamonds++;
                            break;
                        case '.':
                            field[i][j] = new Sand();
                            break;
                    }
                }
            }
            field[PlayerPoint.X][PlayerPoint.Y] = player; 
        }

        public Dictionary<Point,string> Moving(Point direction)
        {
            Dictionary<Point, string> changedList = new Dictionary<Point, string>(); 
            playerPoint = player.Move(field, direction, playerPoint,changedList);
            
            
            return changedList;
        }
        public Dictionary<Point, string> generalGravity()
        {
            Dictionary<Point, string> changedList = new Dictionary<Point, string>(); 
            for (int i = width - 1; i >= 0; i--)
            {
                for (int j = height - 2; j >= 0; j--)
                {
                    if (field[i][j].Type() == "o")
                    {
                        if (Rock.Gravity(new Point(i,j), field, changedList)) 
                        {
                            isGameContinue = false;
                        }
                    }
                }
            }
            return changedList;
        }

        public bool isWin()
        {
            return generalDiamonds == player.DiamondCount; 
        }

        public bool isLose()
        {
            return isGameContinue;
        }
    }
}
