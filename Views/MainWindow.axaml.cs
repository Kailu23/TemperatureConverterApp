using Avalonia.Controls;
using System;
using System.Diagnostics;

namespace TemperatureConverterApp.Views {
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}
		private void CelsiusTextChanged(object? sender, TextChangedEventArgs e) {
			if (Celsius.IsFocused) {
				if (IsTextValid(Celsius.Text)) {
					Fahrenheit.Text = "";
				} else if (double.TryParse(Celsius.Text, out double celsius)) {
					double fahrenheit = celsius * (9d / 5d) + 32;
					Fahrenheit.Text = fahrenheit.ToString("0.0");
				} else {
					InvalidInput();
				}
			}
		}

		private void FahrenheitTextChanged(object? sender, TextChangedEventArgs e) {
			if (Fahrenheit.IsFocused) {
				if (IsTextValid(Fahrenheit.Text)) {
					Celsius.Text = "";
				} else if (double.TryParse(Fahrenheit.Text, out double fahrenheit)) {
					double celsius = (fahrenheit - 32d) * (5d / 9d);
					Debug.WriteLine(celsius);
					Celsius.Text = celsius.ToString("0.0");
				} else {
					InvalidInput();
				}
			}
		}

		private bool IsTextValid(string? text) {
			return String.IsNullOrEmpty(text) || text == "-";
		}

		private void InvalidInput() {
			Fahrenheit.Text = "0";
			Celsius.Text = "0";
		}
	}
}