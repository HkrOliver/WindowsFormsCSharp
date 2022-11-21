using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int numberOne;
            int numberTwo;
            int answer;

            numberOne = int.Parse(TxtBx1.Text);
            numberTwo = int.Parse(TxtBx2.Text);
            answer = numberOne + numberTwo;

            MessageBox.Show(Convert.ToString(answer));
        }

        private void BtnSubtract_Click(object sender, EventArgs e)
        {
            int numberOne;
            int numberTwo;
            int answer;

            numberOne = int.Parse(TxtBx1.Text);
            numberTwo = int.Parse(TxtBx2.Text);
            answer = numberOne - numberTwo;

            MessageBox.Show(Convert.ToString(answer));
        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            int numberOne;
            int numberTwo;
            int answer;

            numberOne = int.Parse(TxtBx1.Text);
            numberTwo = int.Parse(TxtBx2.Text);
            answer = numberOne * numberTwo;

            MessageBox.Show(Convert.ToString(answer));
        }

        private void BtnDivide_Click(object sender, EventArgs e)
        {
            int numberOne;
            int numberTwo;
            int answer;

            numberOne = int.Parse(TxtBx1.Text);
            numberTwo = int.Parse(TxtBx2.Text);
            answer = numberOne / numberTwo;

            MessageBox.Show(Convert.ToString(answer));
        }

        private void BtnAdd2_Click(object sender, EventArgs e)
        {
            int numberOne;
            int numberTwo;
            int numberThree;
            int answer;

            numberOne = int.Parse(TxtBx1.Text);
            numberTwo = int.Parse(TxtBx2.Text);
            numberThree = int.Parse(TxtBx3.Text);
            answer = (numberOne + numberTwo) - numberThree;

            MessageBox.Show(Convert.ToString(answer));
        }

        private void BtnSubtract2_Click(object sender, EventArgs e)
        {
            int numberOne;
            int numberTwo;
            int numberThree;
            int answer;

            numberOne = int.Parse(TxtBx1.Text);
            numberTwo = int.Parse(TxtBx2.Text);
            numberThree = int.Parse(TxtBx3.Text);
            answer = (numberOne - numberTwo) * numberThree;

            MessageBox.Show(Convert.ToString(answer));
        }

        private void BtnMultiply2_Click(object sender, EventArgs e)
        {
            int numberOne;
            int numberTwo;
            int numberThree;
            int answer;

            numberOne = int.Parse(TxtBx1.Text);
            numberTwo = int.Parse(TxtBx2.Text);
            numberThree = int.Parse(TxtBx3.Text);
            answer = numberOne * (numberTwo - numberThree);
            MessageBox.Show(Convert.ToString(answer));
        }

        private void BtnDivide2_Click(object sender, EventArgs e)
        {
            int numberOne;
            int numberTwo;
            int numberThree;
            int answer;

            numberOne = int.Parse(TxtBx1.Text);
            numberTwo = int.Parse(TxtBx2.Text);
            numberThree = int.Parse(TxtBx3.Text);
            answer = (numberOne / numberTwo) + 2156;
            MessageBox.Show(Convert.ToString(answer));
        }
    }
}
