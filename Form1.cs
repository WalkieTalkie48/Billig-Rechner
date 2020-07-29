using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner
{
    public partial class Form1 : Form
    {
        //Sound 
        private SoundPlayer soundPlayer;
        //Fehlermeldungen
        private Form2 fehlerMeldungAnfang = new Form2();
        private Form3 fehlerMeldungAnswer = new Form3();
        private Form4 fehlerMeldungÜberlastung = new Form4();
        //Listen
        private List<double> zahlen = new List<double>();
        private List<int> operatoren = new List<int>();
        //Booleans
        private bool ergebnisOutputVorher;
        private bool answerPrinted;
        //Variablen
        private double answer;
        private string ergebnis;
        public Form1()
        {
            InitializeComponent();
            answer = 0;
        }

        //Zahlenbuttons
        private void button1_Click(object sender, EventArgs e)
        {
            Zahlenbutton(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Zahlenbutton(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Zahlenbutton(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Zahlenbutton(4);
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            Zahlenbutton(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Zahlenbutton(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Zahlenbutton(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Zahlenbutton(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Zahlenbutton(9);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Zahlenbutton(0);
        }

        //Plusbutton
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (zahlen.Count == 4) { FehlerÜberlastung(); }

            else
            {
                if (Rechnertxt.Text != "")
                {
                    zahlen.Add(double.Parse(Rechnertxt.Text));
                    Rechnertxt.Text = "";
                    operatoren.Add(1);
                    answerPrinted = false;
                }

                else { FehlerAnfang(); }
            }
     
        }

        //Minusbutton
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (zahlen.Count == 4) { FehlerÜberlastung(); }

            else
            {
                if (Rechnertxt.Text != "")
                {
                    zahlen.Add(double.Parse(Rechnertxt.Text));
                    Rechnertxt.Text = "";
                    operatoren.Add(2);
                    answerPrinted = false;
                }

                else { FehlerAnfang(); }
            }
   
        }

        //Malbutton
        private void buttonMal_Click(object sender, EventArgs e)
        {
            if (zahlen.Count == 4) { FehlerÜberlastung(); }

            else
            {
                if (Rechnertxt.Text != "")
                {
                    zahlen.Add(double.Parse(Rechnertxt.Text));
                    Rechnertxt.Text = "";
                    operatoren.Add(3);
                    answerPrinted = false;
                }

                else { FehlerAnfang(); }
            }
 
        }

        //Durchbutton
        private void buttonDurch_Click(object sender, EventArgs e)
        {
            if (zahlen.Count == 4) { FehlerÜberlastung(); }
            else
            {
                if (Rechnertxt.Text != "")
                {
                    zahlen.Add(double.Parse(Rechnertxt.Text));
                    Rechnertxt.Text = "";
                    operatoren.Add(4);
                    answerPrinted = false;
                }

                else { FehlerAnfang(); }
            }

        }


        //IstGleichBUtton
        private void buttonGleich_Click(object sender, EventArgs e)
        {
            if (Rechnertxt.Text != "")
            {
                if (zahlen.Count <= 5) 
                {
                    zahlen.Add(double.Parse(Rechnertxt.Text));
                    answerPrinted = false;

                    switch (zahlen.Count)
                    {
                        case 1:
                            ergebnis = Rechnertxt.Text;
                            break;

                        case 2:
                            ergebnis = Rechnungentscheidung(operatoren[0], zahlen[0], zahlen[1]);
                            break;

                        case 3:
                            ergebnis = Rechnungentscheidung(operatoren[0], zahlen[0], zahlen[1]);
                            ergebnis = RechnungEntscheidung2(operatoren[1], ergebnis, zahlen[2]);
                            break;

                        case 4:
                            ergebnis = Rechnungentscheidung(operatoren[0], zahlen[0], zahlen[1]);
                            ergebnis = RechnungEntscheidung2(operatoren[1], ergebnis, zahlen[2]);
                            ergebnis = RechnungEntscheidung2(operatoren[2], ergebnis, zahlen[3]);
                            break;

                        case 5:
                            ergebnis = Rechnungentscheidung(operatoren[0], zahlen[0], zahlen[1]);
                            ergebnis = RechnungEntscheidung2(operatoren[1], ergebnis, zahlen[2]);
                            ergebnis = RechnungEntscheidung2(operatoren[2], ergebnis, zahlen[3]);
                            ergebnis = RechnungEntscheidung2(operatoren[3], ergebnis, zahlen[4]);
                            break;
                    }

                    Rechnertxt.Text = "";
                    Rechnertxt.Text = ergebnis;
                    answer = double.Parse(ergebnis);
                    zahlen.Clear();
                    operatoren.Clear();
                    ergebnisOutputVorher = true;
                }

                else { FehlerÜberlastung(); }
                
            }

            else { FehlerAnfang(); }
        }

        //Answerbutton
        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            
            if (ergebnisOutputVorher == true) { Rechnertxt.Text = ""; ergebnisOutputVorher = false; }
                
            if (Rechnertxt.Text == "")
            {                   
                    Rechnertxt.Text = Convert.ToString(answer);
                    answerPrinted = true;
            }
            else { FehlerAnswer(); }
            
        }

        private void FehlerAnfang()
        {
            fehlerMeldungAnfang.ShowDialog();
        }

        private void FehlerAnswer()
        {
            fehlerMeldungAnswer.ShowDialog();
        }

        private void FehlerÜberlastung()
        {
            fehlerMeldungÜberlastung.ShowDialog();
        }

        private string Rechnungentscheidung(int operation, double zahl1, double zahl2)
        {
            string ergebnis = "";
            switch (operation)
            {
                case 1:
                    ergebnis = Convert.ToString(zahl1 + zahl2);
                    break;

                case 2:
                    ergebnis = Convert.ToString(zahl1 - zahl2);
                    break;

                case 3:
                    ergebnis = Convert.ToString(zahl1 * zahl2);
                    break;

                case 4:
                    ergebnis = Convert.ToString(zahl1 / zahl2);
                    break;
            }
            return ergebnis;
        }

        private string RechnungEntscheidung2(int operation, string ergebnis, double zahl)
        {
            switch (operation)
            {
                case 1:
                    ergebnis = Convert.ToString(double.Parse(ergebnis) + zahl);
                    break;

                case 2:
                    ergebnis = Convert.ToString(double.Parse(ergebnis) - zahl);
                    break;

                case 3:
                    ergebnis = Convert.ToString(double.Parse(ergebnis) * zahl);
                    break;

                case 4:
                    ergebnis = Convert.ToString(double.Parse(ergebnis) / zahl);
                    break;
            }

            return ergebnis;
        }

        private void Zahlenbutton(int button)
        {
            if (answerPrinted == true) { FehlerAnswer(); }
            else
            {
                if (ergebnisOutputVorher == true) { Rechnertxt.Text = ""; ergebnisOutputVorher = false; }
                Rechnertxt.Text += button;
            }
        }
    }
}
