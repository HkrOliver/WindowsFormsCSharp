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
        const string divideByZero = "Err!";
        const string syntaxErr = "SYNTAX ERROR!";
        bool decimalPointActive = false;
        public Form2()
        {
            InitializeComponent();
        }

        // Copies the equation in the text box.
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDisplay.Text)) return;
            Clipboard.SetText(txtDisplay.Text);
        }

        // Resets the textbox so if the user had entered a previous calculation, that won't go away.
        private void BtnReset_Click(object sender, EventArgs e)
        {
            decimalPointActive = false;
            PreCheck_ButtonClick();
            previousOperation = Operation.None;
            txtDisplay.Clear();
        }

        // Fully clears the text box. The next calculation will not be affected by a previous calculation
        // All buttons use the PreCheck_Button so that when the user enters a calculation wrong, they have
        // to start the calculation again.
        private void BtnClear_Click(object sender, EventArgs e)
        {
            decimalPointActive = false;
            PreCheck_ButtonClick();
            if (txtDisplay.Text.Length > 0)
            {
                double d;
                if (!double.TryParse(txtDisplay.Text[txtDisplay.Text.Length - 1].ToString(), out d))
                {
                    previousOperation = Operation.None;
                }

                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
            if (txtDisplay.Text.Length == 0)
            {
                previousOperation = Operation.None;
            }
            if (previousOperation != Operation.None)
            {
                currentOperation = previousOperation;
            }
        }

        private void BtnDiv_Click(object sender, EventArgs e)
        {
            if (txtDisplay.TextLength == 0) return;
            PreCheck_ButtonClick();
            currentOperation = Operation.Div;
            PerformCalculation(previousOperation);

            previousOperation = currentOperation;
            EnableOperatorButtons(false);
            txtDisplay.Text += (sender as Button).Text;
        }

        private void BtnMul_Click(object sender, EventArgs e)
        {
            if (txtDisplay.TextLength == 0) return;
            PreCheck_ButtonClick();
            currentOperation = Operation.Mul;
            PerformCalculation(previousOperation);
            previousOperation = currentOperation;
            EnableOperatorButtons(false);
            txtDisplay.Text += (sender as Button).Text;
        }

        private void BtnSub_Click(object sender, EventArgs e)
        {
            if (txtDisplay.TextLength == 0 || previousOperation == Operation.Sub) return;
            PreCheck_ButtonClick();
            currentOperation = Operation.Sub;
            PerformCalculation(previousOperation);

            previousOperation = currentOperation;
            EnableOperatorButtons(false);
            txtDisplay.Text += (sender as Button).Text;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtDisplay.TextLength == 0) return;
            PreCheck_ButtonClick();
            currentOperation = Operation.Add;
            PerformCalculation(previousOperation);

            previousOperation = currentOperation;
            EnableOperatorButtons(false);
            txtDisplay.Text += (sender as Button).Text;
        }

        private void PerformCalculation(Operation previousOperation)
        {
            try
            {
                if (previousOperation == Operation.None)
                    return;
                List<double> lstNums = null;

                switch (previousOperation)
                {
                    case Operation.Add:
                        if (currentOperation == Operation.Sub)
                        {
                            currentOperation = Operation.Add;
                            return;
                        }
                        lstNums = txtDisplay.Text.Split('+').Select(double.Parse).ToList();
                        txtDisplay.Text = (lstNums[0] + lstNums[1]).ToString();
                        break;
                    case Operation.Sub:
                        int idx = txtDisplay.Text.LastIndexOf('-'); // To handle ex: -9-2
                        if (idx > 0)
                        {
                            var op1 = Convert.ToDouble(txtDisplay.Text.Substring(0, idx));
                            var op2 = Convert.ToDouble(txtDisplay.Text.Substring(idx + 1));
                            txtDisplay.Text = (op1 - op2).ToString();
                        }
                        break;
                    case Operation.Mul:
                        if (currentOperation == Operation.Sub)
                        {
                            currentOperation = Operation.Mul;
                            return;
                        }
                        lstNums = txtDisplay.Text.Split('*').Select(double.Parse).ToList();
                        txtDisplay.Text = (lstNums[0] * lstNums[1]).ToString();
                        break;
                    case Operation.Div:
                        if (currentOperation == Operation.Sub)
                        {
                            currentOperation = Operation.Div;
                            return;
                        }
                        try
                        {
                            lstNums = txtDisplay.Text.Split('/').Select(double.Parse).ToList();
                            if (lstNums[1] == 0)
                            {
                                throw new DivideByZeroException();
                            }
                            txtDisplay.Text = (lstNums[0] / lstNums[1]).ToString();
                        }
                        catch (DivideByZeroException)
                        {
                            txtDisplay.Text = divideByZero;
                        }
                        break;
                    case Operation.None:
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                txtDisplay.Text = syntaxErr;
            }
        }

        private void BtnNum_Click(object btn, EventArgs e)
        {
            if (txtDisplay.Text == syntaxErr || txtDisplay.Text == divideByZero)
            {
                txtDisplay.Text = string.Empty;
            }
            EnableOperatorButtons();
            PreCheck_ButtonClick();
            txtDisplay.Text += (btn as Button).Text;
        }

        private void PreCheck_ButtonClick()
        {
            if (txtDisplay.Text == divideByZero || txtDisplay.Text == syntaxErr)
                txtDisplay.Clear();
            if (previousOperation != Operation.None)
            {
                EnableOperatorButtons();
            }
        }

        private void EnableOperatorButtons(bool enable = true)
        {
            btnMul.Enabled = enable;
            btnDiv.Enabled = enable;
            btnAdd.Enabled = enable;
            if (!enable)
            {
                decimalPointActive = false;
            }
            //btnSub.Enabled = enable;
        }
        enum Operation
        {
            Add,
            Sub,
            Mul,
            Div,
            None
        }

        Operation previousOperation = Operation.None;
        Operation currentOperation = Operation.None;

        private void BtnRes_Click(object sender, EventArgs e)
        {
            if (txtDisplay.TextLength == 0) return;
            if (previousOperation != Operation.None)
                PerformCalculation(previousOperation);

            previousOperation = Operation.None;
        }

        private void BtnDecimal_Click(object sender, EventArgs e)
        {
            if (decimalPointActive) return;
            if (txtDisplay.Text == syntaxErr || txtDisplay.Text == divideByZero)
            {
                txtDisplay.Text = string.Empty;
            }
            EnableOperatorButtons();
            PreCheck_ButtonClick();
            txtDisplay.Text += (sender as Button).Text;
            decimalPointActive = true;
        }
    }
}
