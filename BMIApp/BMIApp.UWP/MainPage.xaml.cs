using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BMIApp.UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            var weight = float.Parse(this.InputWeight.Text);
            var height = float.Parse(this.InputHeight.Text);

            var result = Calculator.CalculateBodyMassIndex(weight, height);

            this.OutputResult.Text = result.ToString();
        }
    }
}