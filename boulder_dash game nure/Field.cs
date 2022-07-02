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
    [Serializable]
    class Field
    {
        List<List<Cell>> field;
        int width, height;
        Point player_point;
        Player player;
        bool game_state;
        int general_diamonds;

        public Field(int l = 1)
        {
            field = new List<List<Cell>>();
            
            
            general_diamonds = 0;
            
            player = new Player();
            player_point = new Point(0, 6);
            generate_lvl(l);
            game_state = true;

        }

        public Point Player_point { 
            get => player_point; 
        }

        public int Width
        {
            get => width;
        }

        public int Height
        {
            get => height;
        }

        public List<List<Cell>> Get_field
        {
            get => field;
        }

        public int Diamonds()
        {
            return player.Diamond_count;
        }


        private void generate_lvl(int l)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<List<char>> tmp_field;
            string lvl = "level" + l.ToString() + ".txt";
            if (File.Exists(lvl))
            {
                if (new FileInfo(lvl).Length != 0)
                {
                    using (FileStream fs = new FileStream(lvl, FileMode.OpenOrCreate))
                    {
                        tmp_field = (List<List<char>>)formatter.Deserialize(fs);
                        width = tmp_field.Count;
                        height = tmp_field[0].Count;

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
                                switch (tmp_field[i][j])
                                {
                                    case 'o':
                                        field[i][j] = new Rock();
                                        break;
                                    case ' ':
                                        field[i][j] = new Empty();
                                        break;
                                    case 'D':
                                        field[i][j] = new Diamond(i,j);
                                        general_diamonds++;
                                        break;
                                    case '.':
                                        field[i][j] = new Sand();
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            
            field[Player_point.X][Player_point.Y] = player;
        }

        public Dictionary<Point,string> Moving(Point direction)
        {
            Dictionary<Point, string> changed_list = new Dictionary<Point, string>();
            player_point = player.Move(field, direction, player_point,changed_list);
            
            
            return changed_list;
        }
        public Dictionary<Point, string> General_gravity()
        {
            Dictionary<Point, string> changed_list = new Dictionary<Point, string>();
            for (int i = width - 1; i >= 0; i--)
            {
                for (int j = height - 2; j >= 0; j--)
                {
                    if (field[i][j].Type()=="o")
                    {
                        if (new Rock().Gravity(new Point(i,j), field, changed_list))
                        {
                            game_state = false;
                        }
                    }
                }
            }
            return changed_list;
        }

        public bool Is_win()
        {
            return general_diamonds == player.Diamond_count;
        }

        public bool Game_end()
        {
            return game_state;
        }
    }
}
