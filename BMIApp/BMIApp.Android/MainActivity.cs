using Android.App;
using Android.Widget;
using Android.OS;

namespace BMIApp.Droid
{
    [Activity (Label = "BMIApp.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.ButtonCalculate);
			
			button.Click += delegate {

                var weight = float.Parse(FindViewById<EditText>(Resource.Id.InputWeight).Text);
                var height = float.Parse(FindViewById<EditText>(Resource.Id.InputHeight).Text);

                var result = Calculator.CalculateBodyMassIndex(weight, height);

                FindViewById<TextView>(Resource.Id.OutputResult).Text = result.ToString();

            };
		}
	}
}