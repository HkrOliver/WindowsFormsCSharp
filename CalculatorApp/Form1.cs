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
    public partial class Form1 : Form
    {
        private string currentCalculation = "";

        public Form1()
        {
            InitializeComponent();
        }

    // On the event that any of the buttons
    // (except =, C, CE and the blank button)
    // is clicked, the text of the button is added to the textbox.
    
        private void Btn_Click(object sender, EventArgs e)
        {
          currentCalculation += (sender as Button).Text;
          TxtBxOutput.Text = currentCalculation; 
        }

    //  This calculates the result

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                string formatedCalculation = currentCalculation.ToString().Replace("X", "*").ToString().Replace("÷", "/");
                TxtBxOutput.Text = new DataTable().Compute(formatedCalculation, null).ToString();
            }
            catch (Exception ex)
            {
                TxtBxOutput.Text = "0";
                currentCalculation = "";
            }
        }
    //  This button clears the whole textbox.
        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtBxOutput.Text = "0";
            currentCalculation = "";
        }

    //  This button is a delete button.
        private void BtnClearEntry_Click(object sender, EventArgs e)
        {
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }
            TxtBxOutput.Text = currentCalculation;
        }
    }
}
