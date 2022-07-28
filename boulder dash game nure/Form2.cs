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
        List<List<Label>> gameField;
        int returnDiamondScore;
        const int cellParameter = 30;
        //отступ слева
        const int cellIndentLeft = 5;
        //отступ сверху
        const int cellIndentAbove = 40;

        public Level_form(string lvl) 
        {
            InitializeComponent();
            lb_level.Text = lvl;
            this.Text = lvl;
            field = new Field(int.Parse(lvl[lvl.Length - 1].ToString()));
            drawField();
            
        }

        public int returnDiamond
        {
            get => returnDiamondScore;
        }
        

        private void drawField()
        {
            
            gameField = new List<List<Label>>();

            for (int i = 0; i < field.Width; i++)
            {
                gameField.Add(new List<Label>());
                for (int j = 0; j < field.Height; j++)
                {
                    Label label = new Label()
                    {
                        Location = new Point(cellIndentLeft + i * cellParameter, cellIndentAbove + j * cellParameter),
                        AutoSize = false,
                        Width = cellParameter,
                        Height = cellParameter,
                        BorderStyle = BorderStyle.None,
                        //заповнення зображенням
                        Image = (Bitmap)Resource1.ResourceManager.GetObject(field.accessToField[i][j].Path())
                    };

                    gameField[i].Add(label);
                    Controls.Add(label);
                }
            }
        }

        private void drawChanges(Dictionary<Point,string> changeList) 
        {
            foreach (var t in changeList)
            {
                gameField[t.Key.X][t.Key.Y].Image = (Bitmap)Resource1.ResourceManager.GetObject(t.Value);
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
            

            drawChanges(field.Moving(updatedCoords[e.KeyCode]));
            drawChanges( field.generalGravity()); 

            returnDiamondScore = field.Diamonds();

            if (!field.isLose())
            {
                MessageBox.Show("You Lost!");
                this.Close();
                return;
            }

            if (field.isWin())
            {
                MessageBox.Show("You win!");
                this.Close();
                return;
            }
            
        }

    }
}
