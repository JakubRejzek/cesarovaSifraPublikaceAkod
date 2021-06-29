using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sifrovani
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            
        }

        private void posunutiO(object sender, EventArgs e)
        {
           // MessageBox.Show("Text");
            int myMovement;
            if (int.TryParse(textBox1.Text, out myMovement))
            {
                //MessageBox.Show("Text2");
                richTextBox2.Text = posunoutVsechnyPrvky(myMovement);
            }
            else
            {
                string posunutiTxt;
                switch (posunutiTxt = textBox1.Text)
                {
                    case null:
                        break;
                    case "":
                        richTextBox2.Text = richTextBox1.Text;
                        break;
                    
                    default:
                        
                        try
                        {
                            richTextBox2.Text = posunoutVsechnyPrvky(posunutiTxt.ToCharArray());
                        }
                        catch (Exception ex)
                        {
                            richTextBox2.Text = "There was some kind of error \n " + ex.Message;
                        }
                        break;
                }
            }
        }
        private char posunDleZnaku(char znak, char kPosunu)
        {
            znak = char.ToLower(znak);
            char toReturn = kPosunu;
            int posun =0;
            
            
            
            if (znak >= 'a' && znak <= 'z')
            {
                if (kPosunu >= 'a' && kPosunu <= 'z')
                {
                    posun = znak -'a'+1;
                    if ((kPosunu - 'a' + posun) >= 26)
                    {
                        posun -= 26;
                    }
                }
                else if (kPosunu >= 'A' && kPosunu <= 'Z')
                {
                    posun = char.ToUpper(znak)- 'A'+1;
                    if ((kPosunu - 'A' + posun) >= 26)
                    {
                        posun -= 26;
                    }
                }
                toReturn = Convert.ToChar(kPosunu +posun);
            }
            else
            {
                
            }
           // MessageBox.Show(toReturn + " " + (toReturn + 0));
            return toReturn;
        }
        private string posunoutVsechnyPrvky (char[] posunuti)
        {
            string newText = "";
            int posunPosunuti = 0;
            //MessageBox.Show(""+'t'+('t'+0) + 'T'+ ('T'+0)+'Z'+('Z'+0));
            for (int i = 0; i < richTextBox1.TextLength; i++)
            {
                bool posunout = true; ;
                if (richTextBox1.Text[i] >= 'A' && richTextBox1.Text[i] <= 'Z' || richTextBox1.Text[i] >= 'a' && richTextBox1.Text[i] <= 'z')
                {
                    newText += posunDleZnaku(posunuti[posunPosunuti], richTextBox1.Text[i]) /*+" {"+posunPosunuti+" }" + posunuti.Length*/;

                }
                else
                {
                    newText += richTextBox1.Text[i];
                    posunout = false;
                }
                if (posunout)
                {
                    posunPosunuti += 1;
                }
                if (posunPosunuti == posunuti.Length)
                {
                    posunPosunuti = 0;
                }

            }

            return newText;
        }
        private string posunoutVsechnyPrvky(int posunuti)
        {
            string newText = "";
            while (posunuti > 25)
            {
                posunuti -= 25;
            }
            if (posunuti <0)
            {
                posunuti += 25;
            }
            
            for (int i = 0; i < richTextBox1.Text.Length; i++)
            {
                if (richTextBox1.Text[i] >= 'a' && richTextBox1.Text[i] <= 'z' )
                {
                    int movement = (richTextBox1.Text[i] + posunuti);
                    while (movement > 'z')
                    {
                        movement -= 26;
                    }
                    newText += "" + Convert.ToChar(movement);
                }
                else if (richTextBox1.Text[i] >= 'A' && richTextBox1.Text[i] <= 'Z')
                {
                    int movement = (richTextBox1.Text[i] + posunuti);
                    while (movement > 'Z')
                    {
                        movement -= 26;
                    }
                    newText += "" + Convert.ToChar(movement);
                }
                else
                {
                    newText += richTextBox1.Text[i].ToString();
                }
            }

            return newText ;
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Jedná se o aplikaci na posunutí abecedy. \n Po vložení textu do okna vlevo a napsání čísla v pravo dole bude text o tolik znaků posunut. Takto napsaný vzorec se opakuje do posunutí celého textu. \n  V případě potřeby složitějšího posunutí budete muset posunout o text. Kde znaky posouvají o: a =1; y=25 z = 0. Znaky mimo a-z/A-Z budou brány jako z. Zapisujete znaky za sebe tak jak chcete mít jednotlivé znaky posunuty. \nAplikace nefunguje s diakritikou, chcete proto navést na web na vyčištení vašeho textu od diakritiky?", "Nápověda", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                string myLinkToSite = "https://www.alejtech.com/en/services/additional-services/online-text-transformation-tools/diacritics-removal.html";
                System.Diagnostics.Process.Start(myLinkToSite);
            }
        }
    }
}
