using Avalonia.Controls;
using System;

namespace TemperatureConverterApp.Views {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void CelsiusTextChanged(object? sender, TextChangedEventArgs e) {
            if (String.IsNullOrEmpty(Celsius.Text) || Celsius.Text == "-") {
                Fahrenheit.Text = "";
            } else if (double.TryParse(Celsius.Text, out double celsius)) {
                double fahrenheit = celsius * (9 / 5) + 32;
                Fahrenheit.Text = fahrenheit.ToString("0.0");
            } else {
                Fahrenheit.Text = "0";
                Celsius.Text = "0";
            }
        }
    }
}