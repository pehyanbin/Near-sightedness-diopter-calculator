using System;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace NearsightednessGUI
{
    public class MainForm : Form
    {
        TextBox inputBox;
        System.Windows.Forms.Label resultLabel;
        Button calculateButton;

        RadioButton modeDiopter;
        RadioButton modeFocal;

        public MainForm()
        {
            Text = "Nearsightedness Calculator";
            Width = 400;
            Height = 400;

            modeDiopter = new RadioButton() { Text = "Focal Length (cm)", Left = 20, Top = 20, Checked = true };
            modeFocal = new RadioButton() { Text = "Refractive Error (º)", Left = 20, Top = 50 };

            inputBox = new TextBox() { Left = 20, Top = 90, Width = 200 };
            calculateButton = new Button() { Text = "Calculate", Left = 20, Top = 130, Width = 100 };
            resultLabel = new System.Windows.Forms.Label() { Left = 20, Top = 200, Width = 350, Height = 70 };

            calculateButton.Click += Calculate;

            Controls.Add(modeDiopter);
            Controls.Add(modeFocal);
            Controls.Add(inputBox);
            Controls.Add(calculateButton);
            Controls.Add(resultLabel);
        }

        private void Calculate(object sender, EventArgs e)
        {
            double input;
            if (!double.TryParse(inputBox.Text, out input) || input <= 0)
            {
                MessageBox.Show("Please enter a valid positive number.");
                return;
            }

            if (modeDiopter.Checked)
            {
                double focalLength = input / 100.0;
                double diopter = 1 / focalLength;
                double refractiveError = diopter * 100;

                resultLabel.Text = $"Focal Length: {focalLength:F2} m\n\nDiopter: {diopter:F2} D\n\nRefractive Error: {refractiveError:F2}°";
            }
            else
            {
                double diopter = input / 100.0;
                double focalLength = 1 / diopter;
                double focalLengthCm = focalLength * 100;

                resultLabel.Text = $"Refractive Error: {input:F2}°\n\nDiopter: {diopter:F2} D\n\nFocal Length: {focalLengthCm:F2} cm";
            }
        }

        
    }
}
