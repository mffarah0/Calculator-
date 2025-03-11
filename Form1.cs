////////////////////////////////////
// Change History 
// Date         Developer  Description 
// 2025-02-04   mffarah0   Started development of the calculator application.
// 2025-02-06   mffarah0   Updated calculator buttons to be responsive and interactive.
// 2025-02-11   mffarah0   Completed responsiveness for all buttons and implemented math operations.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double leftoperand = 0.0;
        private string mathOperation = "";
        private bool mathOpInProgress = false;
        public Form1()
        {
            InitializeComponent();
        }
        // Clears everything on the calculator display when 'CE' is clicked
        private void CE_Click(object sender, EventArgs e)
        {

        }
        // Adds the text of the clicked button to the display
        private void numBtn_Click(object sender, EventArgs e)

        {
            if (display.Text == "0" || mathOpInProgress == true && display.Text != ".")
            {
                //clear the display is
                // 1 - display is only a ZERO
                // 2 - you are "doing a math op and it is not a "." ONLY
                display.Clear();

            }
            mathOpInProgress = false;
            display.Text += ((Button)sender).Text;
        }
        // Resets the current display to '0'
        private void clearEntryBtn_Click(object sender, EventArgs e)
        {
            display.Text = "0";
        }
        // Clears all current settings including any stored operands or operations 
        private void clearAllbtn_Click(object sender, EventArgs e)
        {
            //clear any memory locs holding "first" operands, and possibly
            // the math operation "operator"
            leftoperand = 0.0;
            mathOpInProgress= false;
            mathOperation = "";

            // Similar to the action of the clear entry button
            clearEntryBtn_Click(sender, e);

        }
        //sign button +/-
        private void posNegBtn_Click(object sender, EventArgs e)
        {
            display.Text = (-double.Parse(display.Text)).ToString();
        }
        //first cut - using the ternary operator - not currently using in this app
        private void decimalPtBtn_Click_orig(object sender, EventArgs e)
        {
            // example of the conditional operator
            display.Text = (display.Text.Contains(".")) ? display.Text : display.Text + ".";

        }
        private void decimalPtBtn_Click(object sender, EventArgs e) =>

            // example of the conditional operator
            display.Text = (display.Text.Contains(".")) ? display.Text : display.Text + ".";

        private void backSpaceBtn_Click(object sender, EventArgs e)
        {
            if (display.Text.Length > 1)
            {
                // sunny day scenario - take off the last char
                display.Text = display.Text.Substring(0, display.Text.Length - 1);
            }
            else
            {
                display.Text = "0";
            }
        }
        // Saves the displayed number as the left operand and the operation from the button text
        private void mathOperationBtn_Click(object sender, EventArgs e)
        {
            leftoperand = double.Parse(display.Text); // get the left operand from the current display
            mathOperation = ((Button)sender).Text;  // get the operation from the button that was clicked
            mathOpInProgress = true;
            // for debugging to make it obvious that an operation was captured
            display.Clear();

        }
        // describe what the equals sign is triggering in the calc
        private void equalsBtn_Click(object sender, EventArgs e)
        {
            // based on the saved math operation that was chosen just before equals 
            switch (mathOperation)
            {
                case "+":
                  display.Text = (leftoperand + double .Parse (display.Text)). ToString();
                    break;
                case "-":
                    display.Text = (leftoperand - double.Parse(display.Text)).ToString();
                    break;
                case "x":
                    display.Text = (leftoperand * double.Parse(display.Text)).ToString();
                    break;
                case "/":
                    display.Text = (leftoperand / double.Parse(display.Text)).ToString();
                    break;
                default:
                    break;
            }
        }

        private void clearEntryBtn_Click_1(object sender, EventArgs e)
        {
            display.Text = "0";
        }
    }
}

