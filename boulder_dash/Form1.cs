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
        const int highscore_len = 19;
        Level_form form2;
        List<KeyValuePair<int, string>> highscores;
        BinaryFormatter formatter;
        public Menu()
        {
            InitializeComponent();
            //Cursor.Hide();
            Start_screen();

        }

        void Start_screen()
        {
            highscores = new List<KeyValuePair<int, string>>();
            formatter = new BinaryFormatter();
            for (int i=1; i<6; i++)
            {
                list_levels.Items.Add("level " + i.ToString());
            }
            list_levels.SelectedItems.Add(list_levels.Items[0]);
            tb_playername.Text = "Player1";
            
            //deserialize highscores
            if (File.Exists("highscore_list.txt"))
            {
                if (new FileInfo("highscore_list.txt").Length != 0)
                {
                    using (FileStream fs = new FileStream("highscore_list.txt", FileMode.OpenOrCreate))
                    {
                        highscores = (List<KeyValuePair<int,string>>)formatter.Deserialize(fs);

                        //fill list_records
                        foreach (KeyValuePair<int, string> p in highscores)
                        {
                            int tmp = highscore_len - (p.Value.Length + p.Key.ToString().Length);

                            string t = p.Value + new string('.', tmp) + p.Key.ToString();
                            list_records.Items.Add(t);
                        }
                    }
                }
            }
        }

        void Update_highscore()
        {

            highscores.Add(new KeyValuePair<int,string>(form2.Return_diamond, tb_playername.Text));
            list_records.Items.Clear();

            highscores = highscores.OrderByDescending(pair => pair.Key).ToList();

            for (int i = 0; i < Math.Min(highscores.Count,5); i++)
            {
                int tmp = highscore_len - (highscores[i].Value.Length + highscores[i].Key.ToString().Length);
                string t = highscores[i].Value + new string('.', tmp) + highscores[i].Key.ToString();
                list_records.Items.Add(t);
            }

            //serialize
            using (FileStream fs = new FileStream("highscore_list.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, highscores);
            }

            
        }

        void list_levels_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                form2 = new Level_form(list_levels.SelectedItem.ToString());
                this.Visible = false;
                form2.ShowDialog();
                this.Visible = true;
                Update_highscore();
            }
        }

        
    }
}
