using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slot_machine
{
    public partial class Form1 : Form
    {
        Point p1;
        List<PictureBox> piclist = new List<PictureBox>();
        List<string> fruitlist = new List<string>();
        List<string> AllFruits = new List<string> { "seven.png", "cherry.png", "diamond.png", "gold.png", "lemon.png", "grape.png" };
        List<int> fruitpointer = new List<int>();
        int x = 175;
        int slots,fruits;
        int counter = 0;
        int credits = 100;
        int win = 0;
        int counterlast = 0;
        int credits_counter = 0;
        public Form1(string cb1,string cb2)
        {
            InitializeComponent();
            slots = getintegers(cb1);
            fruits = getintegers(cb2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < slots; i++)
            {
                add_slot(i);
                fruitpointer.Add(0);
            }

            getlist(fruits);
            timer2.Interval = 4600;
            timer1.Interval = 200;
            p1 = new Point((this.Width / 2)-50, 170);
            button1.Location = p1;
        }

        private void add_slot(int i)        //dynamicaly creating slots (pictureboxes)
        {
            p1 = new Point( x, 12);
            PictureBox newpic = new PictureBox();
           
            //setting Location
            newpic.Location = p1;
           
            //setting size
            newpic.Width = 100;
            newpic.Height = 100;
           
            //setting image
            newpic.BackColor = Color.SaddleBrown;
            newpic.BackgroundImage = Image.FromFile("seven.png");
            newpic.BackgroundImageLayout = ImageLayout.Stretch;

            //adjusting the spawnpoint
            x = x + 112;
            //adjusting the form
            this.Width += 112;

            //adding the picboxes in the list
            newpic.Name = i.ToString();
            piclist.Add(newpic);
            //adding the picboxes(slots) in the form
            this.Controls.Add(newpic);
        }

        private int getintegers (string cb)
        {
            return int.Parse(cb);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (credits >= 5)
            {
                timer1.Start();
                timer2.Start();
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("No more credits!!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter += 1;
            for (int i = 1; i <= slots; i++)
            {
                if (counter % i == 0)
                {
                    if (fruitpointer[i-1] == fruits) fruitpointer[i-1] = 0;
                    piclist[i - 1].BackgroundImage = Image.FromFile(fruitlist[fruitpointer[i-1]]); // 1st time same image
                    piclist[i - 1].Name = fruitlist[fruitpointer[i - 1]];
                    fruitpointer[i-1] += 1;
                }
            }
        }
        private void getlist(int i)
        {
            for (int j = 0; j < i; j++)
            {
                fruitlist.Add(AllFruits[j]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (credits_counter >= 4)
            {
                MessageBox.Show("No more free credits.");
            }
            else
            {
                credits += 100;
                credits_counter += 1;
                label1.Text = "Credits: " + credits;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            for (int i=0; i < slots-1; i++)
            {
                if (piclist[i].Name == piclist[i + 1].Name) counterlast++;
            }
            if (counterlast == slots-1)
            {
                win += 5;
                MessageBox.Show("~~~WiNNER~~");
                switch (piclist[0].Name)
                {
                    case "seven.png":
                        MessageBox.Show("!~JACKPOT~!");
                        credits = credits * 2;
                        break;
                    case "cherry.png":
                        credits += 10;
                        break;
                    case "diamond.png":
                        credits = credits + 10 * slots;
                        break;
                    case "gold.png":
                        credits += 5;
                        break;
                    case "lemon.png":
                        credits += 10;
                        break;
                    case "grape.png":
                        credits += 5;
                        break;
                }
            }
            else
            {
                credits -= 5;
            }
            label1.Text = "Credits: " + credits;
            label2.Text = "Bet: 5";
            label3.Text = "Win: " + win;
            button1.Enabled = true;
            counterlast = 0;
        }
    }
}
