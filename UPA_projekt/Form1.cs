using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace UPA_projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OkrajNalevoButton_Click(object sender, EventArgs e)
        {
            OkrajVlevo.ShowDialog();
            OkrajNalevoButton.BackColor = OkrajVlevo.Color;
            OkrajNalevoButton.ForeColor = OkrajVlevo.Color;
            if (sjednotitOkraje.Checked == true)
            {
                OkrajNahore.Color = OkrajVlevo.Color;
                OkrajNahoreButton.BackColor = OkrajNahore.Color;
                OkrajNahoreButton.ForeColor = OkrajNahore.Color;
                OkrajNahoreButton.Enabled = false;
            }
        }

        private void OkrajNahoreButton_Click(object sender, EventArgs e)
        {
            OkrajNahore.ShowDialog();
            OkrajNahoreButton.BackColor = OkrajNahore.Color;
            OkrajNahoreButton.ForeColor = OkrajNahore.Color;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(sjednotitOkraje.Checked == true)
            {
                OkrajNahore.Color = OkrajVlevo.Color;
                OkrajNahoreButton.BackColor = OkrajNahore.Color;
                OkrajNahoreButton.ForeColor = OkrajNahore.Color;
                OkrajNahoreButton.Enabled = false;
            }
            else
            {
                OkrajNahoreButton.Enabled = true;
            }
        }

        private void NevyplnenePixelyButton_Click(object sender, EventArgs e)
        {
            NevyplnenePixely.ShowDialog();
            NevyplnenePixelyButton.BackColor = NevyplnenePixely.Color;
            NevyplnenePixelyButton.ForeColor = NevyplnenePixely.Color;
        }

        private void GenerujObraz_Click(object sender, EventArgs e)
        {
            Generator(Int32.Parse(RozliseniX.Text), Int32.Parse(RozliseniY.Text), Int32.Parse(Skalovani.Text), OkrajVlevo.Color, OkrajNahore.Color, NevyplnenePixely.Color, Instrukce.Lines, FileName.Text);
            /*
            try
            {
                Generator(Int32.Parse(RozliseniX.Text), Int32.Parse(RozliseniY.Text), Int32.Parse(Skalovani.Text), OkrajVlevo.Color, OkrajNahore.Color, NevyplnenePixely.Color, Instrukce.Lines, FileName.Text);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
        //public double a = 0, b, c;//aby vsichni mohli pristupovat
        //public int x, y;
        public Bitmap img;//aby mohlo i evaluujVyraz() pristupovat
        public int pxCount = 0;
        public int pxCountTotal = 1;
        public double[,] bmp;
        public List<byte[]> CrashBuffer = new List<byte[]>();
        public int RozliseniXint = 0;
        public int RozliseniYint = 0;
        int Generator(int rozliseniX, int rozliseniY, int scale, Color okrajVlevo, Color okrajNahore, Color nevyplPx, string[] instrukce, string filename)
        {
            //Zachycujeme problémy
            if(rozliseniX <= 0 || rozliseniY <= 0)//Špatné rozlišení
            {
                throw new Exception("Rozlišení musí být kladné číslo!");
            }
            if (scale <= 0)//invalid scale
            {
                throw new Exception("Škála musí být větší než 0!");
            }
            if (filename.Contains('/'))//název souboru obsahuje invalidní znak/y
            {
                throw new Exception("Název souboru obsahuje invalidní znaky!");
            }
            if (File.Exists(Directory.GetCurrentDirectory() + "/" + filename))//Soubor existuje, chceme jej přepsat?
            {
                DialogResult res = MessageBox.Show("Zadaný soubor již existuje! Chcete jej přepsat?", "Varování!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(res == DialogResult.Yes)//chci přepsat soubor
                {
                    //nic se nestane, jedeme dál
                }
                if (res == DialogResult.No)//chci zanechat soubor
                {
                    throw new Exception("Soubor již existuje!");//chyba
                }
            }
            img = new Bitmap(rozliseniX*scale, rozliseniY*scale);//Vytvoření bitmapy
            Stopwatch sw = new Stopwatch();//stopky na mereni rychlosti
            pxCount = 0;
            pxCountTotal = rozliseniX * rozliseniY;
            bmp = new double[rozliseniX, rozliseniY];
            RozliseniXint = rozliseniX;
            RozliseniYint = rozliseniY;
            for (int drawx = 0; drawx <= rozliseniX - 1; drawx++)//radek po radku
            {
                for (int drawy = 0; drawy <= rozliseniY - 1; drawy++)//sloupec po sloupci
                {
                    bmp[drawx, drawy] = double.NaN;//vyplnime NAN, kbuli cekani vlaken na sebe a aostatni
                }
            }
            sw.Start();
            for (int drawy = 0; drawy <= rozliseniY-1; drawy++)//sloupec po sloupci
            {
                for(int drawx = 0; drawx <= rozliseniX-1; drawx++)//radek po radku
                {
                    new Thread(() => { Vlakno(instrukce, drawx, drawy); }).Start();//zavedeme vlakna
                    pxCount++;
                    StatusLabel.Text = "Pracuji: " + pxCount + " / " + pxCountTotal;
                    StatusLabel.Update();
                }
            }
            sw.Stop();
            StatusLabel.Text = ("Hotovo\nČas: " + sw.ElapsedMilliseconds + " ms\nZapisuji na disk...");
            StatusLabel.Update();
            for (int drawx = 0; drawx <= rozliseniX - 1; drawx++)//radek po radku
            {
                for (int drawy = 0; drawy <= rozliseniY - 1; drawy++)//sloupec po sloupci
                {
                    double a = bmp[drawx,drawy];
                    Color barva = Color.Red;
                    if (Double.IsNaN(a) == false)
                    {
                        a = Math.Abs(bmp[drawx, drawy]);//Proti negativnim cislum
                        barva = Color.FromArgb(Int32.Parse(Math.Floor(a).ToString()), Int32.Parse(Math.Floor(a).ToString()), Int32.Parse(Math.Floor(a).ToString()));//spocitame stupne sedi
                    } else
                    {
                        barva = Color.IndianRed;//na danem vlakne se vyskytla chyba, a vlakno ji zachytilo
                    }
                    for(int x = 0; x <= scale; x++)//v multipixelu po radku
                    {
                        for(int y = 0; y <= scale; y++)//po sloupcich
                        {
                            try
                            {
                                img.SetPixel((drawx * scale) + x, (drawy * scale) + y, barva);//a konecne nastavime pixel
                            } catch(ArgumentOutOfRangeException e)
                            {
                                //zapisujeme na invalidni misto
                            }
                        }
                    }
                }
            }
            //prevedeme chybu na byte pole
            byte[][] Chyby = CrashBuffer.ToArray();
            FileStream CrashWriter = File.Open(Directory.GetCurrentDirectory() + "/Crash.txt", FileMode.OpenOrCreate);//otevreme soubor
            for (int i = 0; i <= Chyby.Length-1; i++)
            {
                CrashWriter.Write(Chyby[i], 0, Chyby[i].Length - 1);
            }
            CrashWriter.Dispose();
            CrashWriter.Close();
            img.Save(filename);
            StatusLabel.Text = ("Hotovo\nČas: " + sw.ElapsedMilliseconds + " ms");
            StatusLabel.Update();
            return 0;
        }
        public void Vlakno(string[] instrukce, int x, int y)
        {
            Thread.CurrentThread.Name = x + ", " + y;//pojmenujeme vlákno            
            double a = 0, b = 0, c = 0, d = 0, e = 0, f = 0;
            for (int i = 0; i <= instrukce.Length - 1; i++)//Zpracování instrukcí jedna po druhé
            {
                try
                {
                    EvaluujVyraz(instrukce[i], ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                }
                catch (Exception ex)//chyba, zapiseme do stejne slozky do souboru crash.txt
                {
                    string ChybaString = "";
                    List<char> VnitrniChyba = new List<char>();//udelame list do ktereho ulozime chybove hlaseni
                    //zacneme skladat dohromady co se posralo
                    ChybaString += "========== Chyba ============\n";
                    ChybaString += ex.Message;
                    ChybaString += "\n";
                    ChybaString += "STACKTRACE\n";
                    ChybaString += ex.StackTrace;
                    ChybaString += "\n";
                    if (ex.InnerException != null)
                    {
                        ChybaString += "Vnitrni chyba\n";
                        ChybaString += ex.InnerException.Message;
                        ChybaString += "\n";
                        ChybaString += ex.InnerException.StackTrace;
                        ChybaString += "\n";
                    }
                    ChybaString += "Vlakno: ";
                    ChybaString += Thread.CurrentThread.Name;
                    ChybaString += "\n";
                    ChybaString += "Hodnoty (a/b/c/d/e/f/instrukce):";
                    ChybaString += "\n";
                    ChybaString += "a = ";
                    ChybaString += a;
                    ChybaString += "\n";
                    ChybaString += "b = ";
                    ChybaString += b;
                    ChybaString += "\n";
                    ChybaString += "c = ";
                    ChybaString += c;
                    ChybaString += "\n";
                    ChybaString += "d = ";
                    ChybaString += d;
                    ChybaString += "\n";
                    ChybaString += "e = ";
                    ChybaString += e;
                    ChybaString += "\n";
                    ChybaString += "f = ";
                    ChybaString += f;
                    ChybaString += "\n";
                    ChybaString += "Chyba je na radku:";
                    ChybaString += "\n";
                    ChybaString += instrukce[i];
                    ChybaString += "\n";
                    ChybaString += "\n";
                    ChybaString += "\n";
                    //prevedeme nazev chyby
                    char[] ChybaChar = new char[ChybaString.Length];//vnitrni chybu prevedeme na char pak na byte
                    for (int j = 0; j <= ChybaString.Length - 1; j++)
                    {
                        ChybaChar[j] = ChybaString[j];//zapiseme byte po byte do chyby v char
                    }
                    byte[] Chyba = new byte[ChybaString.Length];//prevedeme vnitrni chybu na pole
                    for (int j = 0; j <= Chyba.Length - 1; j++)//predelame pole char na pole byte
                    {
                        Chyba[j] = (byte)ChybaChar[j];
                    }
                    CrashBuffer.Add(Chyba);//pridame chybu do celkoveho chyboveho hlaseni
                    a = Double.NaN;//nastavime a na NaN, rekneme tak, aby se zbarvil px cervene, aby indikoval chybu.
                }
            }
            bmp[x, y] = a;
            Thread.Yield();
        }
        private double EvaluujVyraz(string vstup, ref double a, ref double b, ref double c, ref double d, ref double e, ref double f, int x, int y)
        {
            if (vstup == "" || vstup == null)//vstup neni validni
            {
                return 0;
            }
            if (b >= 1)//preskocime radek
            {
                b--;//odecteme radek
                return 0;//preskocime radek
            }
            vstup = vstup.Trim();
            vstup = vstup.ToLower();//odrezu prazdne znaky a dam vse do malych pismen
            string prvnidva = "";
            string zbytek = "";
            try
            {
                prvnidva = vstup.Substring(0, 2);
                zbytek = vstup.Substring(2);//vsechno ostatni krome prvnich dvou
            }
            catch (ArgumentOutOfRangeException)
            { //pri evaluaci jednotlivych cisel se muze stat, ze cislo ma jen 1 cislici, a to dela tady chybu
            }
            catch (IndexOutOfRangeException)
            {
                //to same viz drive
            }
            if (vstup.StartsWith("(") && vstup.EndsWith(')'))//Je to zavorka? a v ni nejaky vyraz?
            {
                vstup = vstup.Substring(1, vstup.Length - 2);//zbavime se zavorek
                EvaluujVyraz(vstup, ref a, ref b, ref c, ref d, ref e, ref f, x, y);
            }
            //Je to primo nejaka funkce?
            if (vstup.StartsWith("sin"))//sinus
            {
                return Math.Sin(EvaluujVyraz(vstup.Substring(3), ref a, ref b, ref c, ref d, ref e, ref f, x, y));
            }
            if (vstup.StartsWith("cos"))//kosinus
            {
                return Math.Cos(EvaluujVyraz(vstup.Substring(3), ref a, ref b, ref c, ref d, ref e, ref f, x, y));
            }
            if (vstup.StartsWith("tan"))//tangens
            {
                return Math.Tan(EvaluujVyraz(vstup.Substring(3), ref a, ref b, ref c, ref d, ref e, ref f, x, y));
            }
            if (vstup.StartsWith("cotg"))//cotangens
            {
                return Math.Tanh(EvaluujVyraz(vstup.Substring(4), ref a, ref b, ref c, ref d, ref e, ref f, x, y));
            }
            if (vstup.StartsWith("sgn"))//signum
            {
                if (EvaluujVyraz(vstup.Substring(3), ref a, ref b, ref c, ref d, ref e, ref f, x, y) > 0)
                {
                    return 1;
                }
                else if (EvaluujVyraz(vstup.Substring(3), ref a, ref b, ref c, ref d, ref e, ref f, x, y) == 0)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            //ne, jedeme dal
            switch (prvnidva)//tridim podle toho, jestli se prirrazuje promenna, jedna se o funkci, nebo ne
            {
                case "a=":
                    a = EvaluujVyraz(zbytek, ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                    return 0;
                //break;
                case "b=":
                    b = EvaluujVyraz(zbytek, ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                    return 0;
                //break;
                case "c=":
                    c = EvaluujVyraz(zbytek, ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                    return 0;
                //break;
                case "d=":
                    d = EvaluujVyraz(zbytek, ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                    return 0;
                //break;
                case "e=":
                    e = EvaluujVyraz(zbytek, ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                    return 0;
                //break;
                case "f=":
                    f = EvaluujVyraz(zbytek, ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                    return 0;
                //break;
                case "if"://pokud se jedna o if-podminku
                    if (EvaluujVyraz(zbytek, ref a, ref b, ref c, ref d, ref e, ref f, x, y) >= 1)//pokud bude vysledek podminky pravda
                    {
                        b = 0;//b je nula, zadny radek se nepreskoci, jedeme dal
                    }
                    else
                    {
                        b = 1;//preskocime b radku
                    }
                    return 0;
                //break;
                case "pi"://Jedna se o cislo pi
                    return Math.PI;
            }
            if (vstup.StartsWith('[') && vstup.EndsWith(']'))//jedna se o souradnice
            {
                int soux = 0, souy = 0;
                string[] souradnice = { };
                vstup = vstup.Substring(1, vstup.Length - 2);//zbavime se hranatych zavorek
                if (vstup.Contains(';'))
                {
                    souradnice = vstup.Split(';');//separujeme podle ;
                }
                else if (vstup.Contains(','))
                {
                    souradnice = vstup.Split(',');//separujeme podle ,
                }
                else
                {
                    throw new Exception("Znamenko mezi souradnicemi musi byt ; nebo ,");
                }
                Int32.TryParse(souradnice[0], out soux);
                Int32.TryParse(souradnice[1], out souy);
                if (soux <= 0 || soux >= RozliseniXint)//okraj nalevo
                {
                    return Double.Parse("254");
                }
                else if (souy <= 0 || souy >= RozliseniYint)//okraj nahore
                {
                    return Double.Parse("254");
                }
                else
                {
                    if (Double.IsNaN(bmp[soux, souy]) == true)//dana vec je NaN, tzn. bud se nespocitala kvuli chybe, nebo se ceka na jine vlakna
                    {
                        int cekame = 0;
                        int SleepInt = 50;
                        while (Double.IsNaN(bmp[soux, souy]) == true)//budeme cekat
                        {
                            if (cekame >= (SleepInt * x * y))//cekame dele nez je pravdepodobne, takze na danem px je chyba
                            {
                                break;
                            }
                            Thread.Sleep(SleepInt);//pockame
                            cekame += SleepInt;//pricteme cas
                        }
                        if (Double.IsNaN(bmp[soux, souy]) == true)//znova se optame
                        {
                            return 0;//neco je spatne, vracim 0
                        }
                        else return bmp[soux, souy];//hodnota se spocitala, vse je ok
                    }
                    else
                    {
                        return bmp[soux, souy];
                    }
                }
            }
            if (vstup.Contains("=="))//ptame se na podminku ==
            {
                string[] rozd = vstup.Split("==");
                if (Int32.Parse(EvaluujVyraz(rozd[0].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y).ToString()) == Int32.Parse(EvaluujVyraz(rozd[1].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y).ToString()))//pokud se vyrazy rovnaji
                {
                    return 1;
                }
                else { return 0; }
            }
            if (vstup.Contains(">="))//ptame se na podminku >=
            {
                string[] rozd = vstup.Split(">=");
                if (Int32.Parse(EvaluujVyraz(rozd[0].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y).ToString()) >= Int32.Parse(EvaluujVyraz(rozd[1].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y).ToString()))//pokud se vyrazy rovnaji
                {
                    return 1;
                }
                else { return 0; }
            }
            if (vstup.Contains("<="))//ptame se na podminku <=
            {
                string[] rozd = vstup.Split("<=");
                if (Int32.Parse(EvaluujVyraz(rozd[0].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y).ToString()) <= Int32.Parse(EvaluujVyraz(rozd[1].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y).ToString()))//pokud se vyrazy rovnaji
                {
                    return 1;
                }
                else { return 0; }
            }
            if (vstup.Contains("!="))//ptame se na podminku !=
            {
                string[] rozd = vstup.Split("!=");
                if (Int32.Parse(EvaluujVyraz(rozd[0].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y).ToString()) != Int32.Parse(EvaluujVyraz(rozd[1].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y).ToString()))//pokud se vyrazy rovnaji
                {
                    return 1;
                }
                else { return 0; }
            }
            if (vstup.Contains("<"))//ptame se na podminku <
            {
                string[] rozd = vstup.Split('<');
                if (Int32.Parse(EvaluujVyraz(rozd[0].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y).ToString()) < Int32.Parse(EvaluujVyraz(rozd[1].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y).ToString()))//pokud se vyrazy rovnaji
                {
                    return 1;
                }
                else { return 0; }
            }
            if (vstup.Contains(">"))//ptame se na podminku >
            {
                string[] rozd = vstup.Split('>');
                if (Int32.Parse(EvaluujVyraz(rozd[0].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y).ToString()) > Int32.Parse(EvaluujVyraz(rozd[1].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y).ToString()))//pokud se vyrazy rovnaji
                {
                    return 1;
                }
                else { return 0; }
            }
            //pokud neni nic, pravdepodobne se jedna o + - * / %
            double vysl;
            if (vstup.Contains('+'))//scitani
            {
                vysl = 0;
                string[] rozd = vstup.Split('+');
                double[] rozdvysl = new double[rozd.Length];
                for (int i = 0; i <= rozd.Length - 1; i++)
                {
                    rozdvysl[i] = EvaluujVyraz(rozd[i].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                }
                for (int i = 0; i <= rozd.Length - 1; i++)
                {
                    vysl += rozdvysl[i];
                }
                return vysl;
            }
            if (vstup.Contains('-'))//odcitani NEBO negativni hodnota
            {
                string[] rozd = vstup.Split('-');
                if (rozd.Length == 2 && rozd[0] == "")//jedna se o jednu negativni hodnotu
                {
                    return Double.Parse(vstup);
                }
                vysl = EvaluujVyraz(rozd[0].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y);//kdyby dal nekdo neznamou na prvni misto
                double[] rozdvysl = new double[rozd.Length];
                for (int i = 1; i <= rozd.Length - 1; i++)
                {
                    rozdvysl[i] = EvaluujVyraz(rozd[i].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                }
                for (int i = 1; i <= rozd.Length - 1; i++)
                {
                    vysl -= rozdvysl[i];
                }
                return vysl;
            }
            if (vstup.Contains('*'))//nasobeni
            {
                string[] rozd = vstup.Split('*');
                vysl = EvaluujVyraz(rozd[0].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                double[] rozdvysl = new double[rozd.Length];
                for (int i = 1; i <= rozd.Length - 1; i++)
                {
                    rozdvysl[i] = EvaluujVyraz(rozd[i].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                }
                for (int i = 1; i <= rozd.Length - 1; i++)
                {
                    vysl *= rozdvysl[i];
                }
                return vysl;
            }
            if (vstup.Contains('/'))//deleno
            {
                string[] rozd = vstup.Split('/');
                vysl = EvaluujVyraz(rozd[0].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                double[] rozdvysl = new double[rozd.Length];
                for (int i = 1; i <= rozd.Length - 1; i++)
                {
                    rozdvysl[i] = EvaluujVyraz(rozd[i].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                }
                for (int i = 1; i <= rozd.Length - 1; i++)
                {
                    vysl /= rozdvysl[i];
                }
                return vysl;
            }
            if (vstup.Contains('%'))//modulo
            {
                string[] rozd = vstup.Split('%');
                vysl = EvaluujVyraz(rozd[0].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                double[] rozdvysl = new double[rozd.Length];
                for (int i = 1; i <= rozd.Length - 1; i++)
                {
                    rozdvysl[i] = EvaluujVyraz(rozd[i].ToString(), ref a, ref b, ref c, ref d, ref e, ref f, x, y);
                }
                for (int i = 1; i <= rozd.Length - 1; i++)
                {
                    vysl %= rozdvysl[i];
                }
                return vysl;
            }
            if (vstup.Length == 1)//ptame se jen na 1 promennou
            {
                switch (vstup)
                {
                    case "x":
                        return x;
                    //break;
                    case "y":
                        return y;
                    //break;
                    case "a":
                        return a;
                    //break;
                    case "b":
                        return b;
                    //break;
                    case "c":
                        return c;
                    //break;
                    case "d":
                        return d;
                    //break;
                    case "e":
                        return e;
                    //break;
                    case "f":
                        return f;
                        //break;
                }
            }
            return Double.Parse(vstup);
        }

        private void RozliseniY_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
