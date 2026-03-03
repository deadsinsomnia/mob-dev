using System;

namespace BMI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (double.TryParse(HeightEntry.Text, out double heightCm) &&
                double.TryParse(WeightEntry.Text, out double weightKg))
            {
                if (heightCm <= 0 || weightKg <= 0)
                {
                    ResultLabel.Text = "Please enter valid positive numbers.";
                    return;
                }

                double heightMeters = heightCm / 100;
                double bmi = weightKg / (heightMeters * heightMeters);

                string category = GetBMICategory(bmi);

                ResultLabel.Text = $"Your BMI: {bmi:F2}\nCategory: {category}";
            }
            else
            {
                ResultLabel.Text = "Please enter valid numeric values.";
            }
        }

        private string GetBMICategory(double bmi)
        {
            if (bmi < 18.5)
                return "Underweight";
            else if (bmi < 25)
                return "Normal weight";
            else if (bmi < 30)
                return "Overweight";
            else
                return "Obesity";
        }
    }
}