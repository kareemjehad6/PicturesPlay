using PicturesPlay.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;


namespace PicturesPlay
{

    public partial class Form1 : Form
    {

        List<Button> BuutonList;
        List<Image> imageList;
        int CounterVectory = 1;
        int Click = 1;
        Button B1 = null;
        Button B2 = null;

        public Form1()
        {
            InitializeComponent();
            
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            BuutonList = new List<Button>()
            {
                btn1, btn2, btn3,
                btn4, btn5, btn6,
                btn7, btn8, btn9,
                btn10,btn11,btn12
            };

            // إغلاق جميع الأزرار عند بدء التشغيل
            foreach (Button btn in BuutonList)
            {
                btn.Enabled = false;
            }
            MakeButtonCircular(btnStart);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Click = 1;
            for (int i = 0; i < BuutonList.Count; i++)
            {
                BuutonList[i].Enabled = true;
            }


            List<Image> images = new List<Image>()
            {
               Resources.Lion,
               Resources.Camel,
               Resources.Dog,
               Resources.Cat,
               Resources.Donki,
               Resources.Sheep
            };


            imageList = new List<Image>();
            foreach(Image img in images)
            {
                imageList.Add(img);
                imageList.Add(img);
            }    

            Random rand = new Random();
            imageList = imageList.OrderBy(x => rand.Next()).ToList();

             BuutonList = new List<Button>()
            {
                btn1, btn2, btn3,
                btn4, btn5, btn6,
                btn7, btn8, btn9,
                btn10,btn11,btn12
            };

            for (int i = 0; i < BuutonList.Count; i++)
            {
                BuutonList[i].Tag = imageList[i];
                BuutonList[i].BackgroundImage= imageList[i];

            }

            timer1.Start();

        }

       

       

        private void Button_Click(object sender, EventArgs e)
        {
            


            if (B1 == (Button)sender)
                return;// ارجاع اذا ضغط اكثر من مرة على نفس الزر


            if (Click == 1)
            {

                B1 = (Button)sender;
                B1.BackgroundImage = (Image)B1.Tag;
                Click++;
            }

            else if (Click == 2)
            {
                B2 = (Button)sender;
                B2.BackgroundImage = (Image)B2.Tag;
                Click = 1;

                if (B1.Tag == B2.Tag)
                {

                    B1.Enabled = false;
                    B2.Enabled = false;
                    CounterVectory++;
                    //  PlaySound("Correct.mp3");
                    if (CounterVectory == 7)
                        MessageBox.Show("Game Over","MatchGame",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
                else
                {
                   //  PlaySound("Wrong.mp3");
                    timer2.Start();
                   
                }
            }

           


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            for (int i = 0; i < BuutonList.Count; i++)
            {
                // BuutonList[i].Tag = imageList[i];
                BuutonList[i].BackgroundImage = Resources.question_mark_96;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            B1.BackgroundImage = Resources.question_mark_96;
            B2.BackgroundImage = Resources.question_mark_96;
            B1 = null;
            B2 = null;
        }

        private void MakeButtonCircular(Button btn)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);
        }

      
    }
}
