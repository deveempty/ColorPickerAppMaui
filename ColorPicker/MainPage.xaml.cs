using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;

namespace ColorPicker;

public partial class MainPage : ContentPage
{
	bool isRandom;
	string hexValue;

	public MainPage()
	{
		InitializeComponent();
	}

    private void Slider_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    {
		if (!isRandom)
		{
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }
    }

    private void SetColor(Color color)
    {
		Debug.WriteLine(color.ToString());
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;

		frameTitle.BorderColor = color;
        hexColor.BorderColor = color;
        hexValue = color.ToHex();
        hexColor.Text = $"HEX Color: {hexValue}";
    }

    void btnRandom_Clicked(System.Object sender, System.EventArgs e)
    {
		isRandom = true;
		var random = new Random();

		var color = Color.FromRgb(
			random.Next(0,265),
			random.Next(0,265),
			random.Next(0,265));

		SetColor(color);

		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBlue.Value = color.Blue;
		isRandom = false;
    }

    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
		await Clipboard.SetTextAsync(hexValue);
		var toast = Toast.Make("Color copied on your clipboard",
					CommunityToolkit.Maui.Core.ToastDuration.Short,
					12);
		await toast.Show();
    }
}


