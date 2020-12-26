using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGenerujObraz_Click(object sender, EventArgs e)
        {
            statusBox.Text = "Pracuji...";
            statusBox.Refresh();
            GenerujObraz(textBoxSeed.Text, Int32.Parse(textBoxRozliseniX.Text), Int32.Parse(textBoxRozliseniY.Text), Int32.Parse(textBoxScale.Text));
        }
        public void GenerujObraz(string sem, int x, int y, int imgScale)
        {
            bool control = true;//kontrolni bool, pokud je false, generace se neprovede
            try
            {
                if (sem.Length == 0)
                {
                    throw new IndexOutOfRangeException("Musíš něco napsat do semínka!");
                }
            }   catch (IndexOutOfRangeException e)
            {
                MessageBox.Show(e.Message);
                control = false;
            }
            try
            {
                if(imgScale <= 0)
                {
                    throw new Exception("Škála musí být větší než 1!");
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            char[] semChar = sem.ToArray();
            string seed = "";
            List<int> seedList = new List<int>();
            for (int i = 0; i <= semChar.Length - 1; i++)//převedeme semínko na char, sečteme
            {
                seed += semChar[i].GetHashCode().ToString();
            }
            for (int i = 0; i <= seed.Length - 1; i++)//seed na string[], bo  c# nějak neumí počítat s pole[index]
            {
                seedList.Add(seed[i]);
            }
            int[] seedPole = seedList.ToArray();
            Bitmap img = new Bitmap(x,y);
            int workx = 0, worky = 0, index = 0;
            byte barva = 0, barvaL, barvaN;
            int pixels = x * y;
            while (control)
            {
                try//POCITAME BARVU PIXELU NAHORE
                {
                    barvaL = img.GetPixel(workx - 1, worky).R;
                } catch (ArgumentOutOfRangeException)
                {
                    barvaL = 127;
                }
                try//POCITAME BYRVU PIXELU NALEVO
                {
                    barvaN = img.GetPixel(workx, worky - 1).R;
                }
                catch (ArgumentOutOfRangeException)
                {
                    barvaN = 127;
                }
                byte predchoziBarva = (byte) Math.Abs(barvaN - barvaL);
                byte mez = (byte) (predchoziBarva + (255 * (Math.Sin((Math.PI / 2) / (seedPole[index] - 48)))));
                byte.TryParse(mez.ToString(), out barva);
                for(int i = 0; i <= imgScale-1; i++)
                {
                    for (int j = 0; j <= imgScale-1; j++)
                    {
                        img.SetPixel(workx+i, worky+j, Color.FromArgb(barva, 255, 255, 255));//nastavujeme pixel
                    }
                }

                //-----------------------------------AFTERWORK, UKLIZENI
                statusLabelLong.Text = (((workx-1)*(worky))/pixels).ToString() + "%";
                statusLabelLong.Update();
                workx+=imgScale;
                if (workx >= x)
                {
                    workx = 0;
                    worky+=imgScale;
                }
                if (worky >= y)
                {
                    break;
                }
                index++;
                if(index>= seed.Length - 1)//vibe check
                {
                    index = 0;
                }
            }
            img.Save("obrazek.bmp");
            statusBox.Text = "Připraven";
            statusBox.Refresh();
        }
    }
}
