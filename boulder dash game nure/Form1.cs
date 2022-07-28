using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace boulder_dash
{

    [Serializable]
    public partial class Menu : Form
    {
        const int highscoreListWidth = 19;
        Level_form form2;
        List<KeyValuePair<int, string>> highscores;
        
        public Menu()
        {
            InitializeComponent();
            
            startScreen();

        }

        private void startScreen()
        {
            highscores = new List<KeyValuePair<int, string>>();

            for (int i = 1; i < 6; i++)
            {
                list_levels.Items.Add("level " + i.ToString());
            }
            list_levels.SelectedItems.Add(list_levels.Items[0]);
            tb_playername.Text = "Player1";

            //read highscores from file
            if (File.Exists("highscore_list.txt"))
            {
                if (new FileInfo("highscore_list.txt").Length != 0)
                {
                    using (StreamReader fs = new StreamReader("highscore_list.txt"))
                    {
                        string line;
                        while ((line = fs.ReadLine()) != null)
                        {
                            highscores.Add(new KeyValuePair<int, string>(int.Parse(line.Split()[1]),line.Split()[0]));
                        }

                    }
                }
            }
            //fill list_records
            foreach (KeyValuePair<int, string> p in highscores)
            {
                string name = p.Value;
                string score = p.Key.ToString();

                int amountDots = highscoreListWidth - (name.Length + score.Length);
                string infoBestOne = name + new string('.', amountDots) + score;
                list_records.Items.Add(infoBestOne);
            }
        }

        private void updateHighscore()
        {

            highscores.Add(new KeyValuePair<int,string>(form2.returnDiamond, tb_playername.Text));
            list_records.Items.Clear();

            highscores = highscores.OrderByDescending(pair => pair.Key).ToList();

            for (int i = 0; i < Math.Min(highscores.Count,5); i++)
            {
                string name = highscores[i].Value;
                string score = highscores[i].Key.ToString();

                int amountDots = highscoreListWidth - (name.Length + score.Length);
                string infoBestOne = name + new string('.', amountDots) + score;
                list_records.Items.Add(infoBestOne);
            }

            //update file
            using (StreamWriter fs = new StreamWriter("highscore_list.txt", false))
            {
                foreach (var h in highscores)
                {
                    fs.WriteLine(h.Value + " " + h.Key.ToString());
                }
            }

            
        }

        private void list_levels_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                form2 = new Level_form(list_levels.SelectedItem.ToString());
                this.Visible = false;
                form2.ShowDialog();
                this.Visible = true;
                updateHighscore();
            }
        }

    }
}
