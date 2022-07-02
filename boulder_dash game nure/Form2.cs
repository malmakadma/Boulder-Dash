using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace boulder_dash
{
    
    public partial class Level_form : Form
    {
        Field field;
        List<List<Label>> game_field;
        int return_diamond;

        public Level_form(string lvl)
        {
            InitializeComponent();
            lb_level.Text = lvl;
            this.Text = lvl;
            field = new Field(int.Parse(lvl[lvl.Length - 1].ToString()));
            draw_field();
            
        }

        public int Return_diamond
        {
            get => return_diamond;
        }
        

        private void draw_field()
        {
            
            //form size
            this.Width = 800; 
            this.Height = 620;

            game_field = new List<List<Label>>();

            for (int i = 0; i < field.Width; i++)
            {
                game_field.Add(new List<Label>());
                for (int j = 0; j < field.Height; j++)
                {
                    Label tmp = new Label()
                    {
                        Location = new Point( 5 + i * 30, 40 + j * 30),
                        AutoSize = false,
                        Width = 30,
                        Height = 30,
                        BorderStyle = BorderStyle.None,
                        //заповнення зображенням
                        Image = (Bitmap)Resource1.ResourceManager.GetObject(field.Get_field[i][j].Path())
                    };

                    game_field[i].Add(tmp);
                    Controls.Add(tmp);
                }
            }
        }

        void draw_changes(Dictionary<Point,string> change_list)
        {
            foreach (var t in change_list)
            {
                game_field[t.Key.X][t.Key.Y].Image = (Bitmap)Resource1.ResourceManager.GetObject(t.Value);
            }
            score.Text = $"Score: {field.Diamonds().ToString()}";
        }

        private void Level_form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                this.Close();
                return;
            }
            Dictionary<Keys, Point> updatedCoords = new Dictionary<Keys, Point>();
            updatedCoords.Add(Keys.Up, new Point(0, -1));
            updatedCoords.Add(Keys.Down, new Point(0, 1));
            updatedCoords.Add(Keys.Right, new Point(1, 0));
            updatedCoords.Add(Keys.Left, new Point(-1, 0));
            

            draw_changes(field.Moving(updatedCoords[e.KeyCode]));
            draw_changes( field.General_gravity());

            return_diamond = field.Diamonds();

            if (!field.Game_end())
            {
                MessageBox.Show("You Lost!");
                this.Close();
                return;
            }

            if (field.Is_win())
            {
                MessageBox.Show("You win!");
                this.Close();
                return;
            }
            

        }

    }
}
