using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1: Form
    {
        static Random rnd = new Random();
        int countRes = 15;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateBut();
        }

        private void UpdateBut() 
        {
            int rndint;
            Button[] but = { button1, button2, button3 };
            for (int i = 0; i < but.Length; i++)
            {
                    rndint = GetRandomInt();
                    but[i].Text = GetRandomMathSymbol(but[i], rndint).ToString() + rndint;
            }
        }

        private char GetRandomMathSymbol(Button btn, int rndint)
        {
            int currentNumber = Int32.Parse(Regex.Replace(label1.Text, @"\D", ""));
            char[] allSymbols = { '+', '*', '-', '/' };
            char[] firstStepSymbols = { '+', '*' };
            char[] smallDrop = { '*', '/' };
            char[] nextDrop = { '+', '-' };



            if (currentNumber >= 71)
            {
                return nextDrop[rnd.Next(nextDrop.Length)];
            }
            else if (currentNumber >= 20 && currentNumber <= 70)
            {
                if (RandomInt() <= 30 && rndint <= 3)
                {
                    return smallDrop[rnd.Next(smallDrop.Length)];
                } else {
                    if (RandomInt() <= 40 && rndint <= 3)
                    {
                       return firstStepSymbols[rnd.Next(firstStepSymbols.Length)];
                    }
                    else
                    {
                        return nextDrop[rnd.Next(nextDrop.Length)];
                    }
                }
            }
            else 
            {
                if (rndint <= 3)
                {
                    return firstStepSymbols[rnd.Next(firstStepSymbols.Length)];
                }
                else
                {
                    return '+';
                }
            }
        }


        static int RandomInt()
        {
            return rnd.Next(1,100);
        }
        private int GetRandomInt()
        {
            int currentNumber = Int32.Parse(Regex.Replace(label1.Text, @"\D", ""));

            int[] startlvl = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 2, 3 };
            int[] midlvl = { 2, 3, 5, 7, 9, 10, 2};
            int[] hight = { 1, 2, 3, 4, 5 };

            if (currentNumber >= 90) 
                return hight[rnd.Next(hight.Length)];
            else if (currentNumber >= 20)
                return midlvl[rnd.Next(midlvl.Length)];
            else
                return startlvl[rnd.Next(startlvl.Length)];
            
        
            }

        private void click(Button btn) 
        {
            if (countRes != 0)
            {
                int currentNumber = Int32.Parse(Regex.Replace(label1.Text, @"\D", ""));
                int operand = Int32.Parse(Regex.Replace(btn.Text, @"\D", ""));
                char operation = btn.Text.First(c => "+-*/".Contains(c));

                switch (operation)
                {
                    case '+':
                        currentNumber += operand;
                        countRes -= 1;
                        break;
                    case '-':
                        currentNumber -= operand;
                        countRes -= 1;
                        break;
                    case '*':
                        currentNumber *= operand;
                        countRes -= 1;
                        break;
                    case '/':
                        if (operand != 0)
                            currentNumber /= operand;
                        countRes -= 1;
                        break;
                }

                label1.Text = "Jusu cipars: " + currentNumber;
                label2.Text = "Pakāpju skaits: " + (countRes).ToString();

                if (currentNumber == 100)
                {
                    MessageBox.Show("Apsveicam! Jūs sasniedzāt 100!", "Uzvara", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetGame();
                }
                else if (currentNumber > 100 || currentNumber <= 0 || countRes <= 0)
                {
                    MessageBox.Show("Spēle beigusies! Mēģiniet vēlreiz.", "Beigas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetGame();
                }
                else
                {
                    UpdateBut();
                }
            }
            else 
            {
                MessageBox.Show("Spēle beigusies! Mēģiniet vēlreiz.", "Beigas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetGame();

            }
        }
        private void ResetGame()
        {
            countRes = 15;
            label1.Text = "Jusu cipars: 1";
            label2.Text = "Pakāpju skaits: " + countRes;
            UpdateBut();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            click(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            click(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            click(button3);
        }
    }
}
