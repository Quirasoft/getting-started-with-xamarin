using System;

using UIKit;

namespace BMIApp.iOS
{
	public partial class ViewController : UIViewController
	{
        private UIButton ButtonCalculate;
        private UILabel LabelWeight;
        private UILabel LabelHeight;
        private UILabel LabelBMI;
        private UITextField InputWeight;
        private UITextField InputHeight;
        private UITextField OutputResult;

        public ViewController (IntPtr handle) : base (handle)
		{

		}

        public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            this.CreateViews();

            this.SetupConstraints();

            this.SetupButtonCalculate();
        }

        private void SetupButtonCalculate()
        {
            // Perform any additional setup after loading the view, typically from a nib.
            ButtonCalculate.AccessibilityIdentifier = "ButtonCalculate";
            ButtonCalculate.TouchUpInside += delegate {

                var weight = float.Parse(this.InputWeight.Text);
                var height = float.Parse(this.InputHeight.Text);

                var result = Calculator.CalculateBodyMassIndex(weight, height);

                this.OutputResult.Text = result.ToString();

            };
        }

        private void CreateViews()
        {
            this.ButtonCalculate = new UIButton(UIButtonType.System);
            this.ButtonCalculate.SetTitle("Calculate", UIControlState.Normal);
            this.ButtonCalculate.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            this.Add(this.ButtonCalculate);

            this.LabelWeight = new UILabel();
            this.LabelWeight.Text = "Weight (kg)";
            this.Add(this.LabelWeight);

            this.LabelHeight = new UILabel();
            this.LabelHeight.Text = "Height (m)";
            this.Add(this.LabelHeight);

            this.LabelBMI = new UILabel();
            this.LabelBMI.Text = "BMI";
            this.Add(this.LabelBMI);

            this.InputWeight = new UITextField();
            this.InputWeight.Layer.CornerRadius = 5;
            this.InputWeight.BorderStyle = UITextBorderStyle.RoundedRect;
            this.InputWeight.KeyboardType = UIKeyboardType.DecimalPad;
            this.Add(this.InputWeight);

            this.InputHeight = new UITextField();
            this.InputHeight.BorderStyle = UITextBorderStyle.RoundedRect;
            this.InputHeight.KeyboardType = UIKeyboardType.DecimalPad;
            this.Add(this.InputHeight);

            this.OutputResult = new UITextField();
            this.OutputResult.BorderStyle = UITextBorderStyle.RoundedRect;
            this.OutputResult.Enabled = false;
            this.Add(this.OutputResult);
        }

        private void SetupConstraints()
        {
            this.LabelWeight.TranslatesAutoresizingMaskIntoConstraints  = false;
            this.InputWeight.TranslatesAutoresizingMaskIntoConstraints  = false;
            this.LabelHeight.TranslatesAutoresizingMaskIntoConstraints  = false;
            this.LabelBMI.TranslatesAutoresizingMaskIntoConstraints     = false;

            this.InputHeight.TranslatesAutoresizingMaskIntoConstraints      = false;
            this.ButtonCalculate.TranslatesAutoresizingMaskIntoConstraints  = false;
            this.OutputResult.TranslatesAutoresizingMaskIntoConstraints     = false;

            NSLayoutConstraint.ActivateConstraints(new NSLayoutConstraint[] {

                    this.LabelWeight.TopAnchor.ConstraintEqualTo(this.View.TopAnchor, 50),
                    this.LabelWeight.LeftAnchor.ConstraintEqualTo(this.View.LeftAnchor, 20),
                    this.LabelWeight.WidthAnchor.ConstraintEqualTo(100),

                    this.InputWeight.TopAnchor.ConstraintEqualTo(this.LabelWeight.TopAnchor, 0),
                    this.InputWeight.LeftAnchor.ConstraintEqualTo(this.LabelWeight.RightAnchor, 10),
                    this.InputWeight.RightAnchor.ConstraintEqualTo(this.View.RightAnchor, -20),

                    this.LabelHeight.TopAnchor.ConstraintEqualTo(this.LabelWeight.BottomAnchor, 20),
                    this.LabelHeight.LeftAnchor.ConstraintEqualTo(this.LabelWeight.LeftAnchor, 0),
                    this.LabelHeight.WidthAnchor.ConstraintEqualTo(this.LabelWeight.WidthAnchor),

                    this.InputHeight.TopAnchor.ConstraintEqualTo(this.LabelHeight.TopAnchor, 0),
                    this.InputHeight.LeftAnchor.ConstraintEqualTo(this.InputWeight.LeftAnchor,0),
                    this.InputHeight.RightAnchor.ConstraintEqualTo(this.InputWeight.RightAnchor, 0),

                    this.ButtonCalculate.TopAnchor.ConstraintEqualTo(this.InputHeight.BottomAnchor, 20),
                    this.ButtonCalculate.LeftAnchor.ConstraintEqualTo(this.InputHeight.LeftAnchor, 0),
                    this.ButtonCalculate.RightAnchor.ConstraintEqualTo(this.InputHeight.RightAnchor,0),
                  
                    this.LabelBMI.TopAnchor.ConstraintEqualTo(this.ButtonCalculate.BottomAnchor, 20),
                    this.LabelBMI.LeftAnchor.ConstraintEqualTo(this.LabelHeight.LeftAnchor, 0),
                    this.LabelBMI.WidthAnchor.ConstraintEqualTo(this.LabelWeight.WidthAnchor),

                    this.OutputResult.TopAnchor.ConstraintEqualTo(this.LabelBMI.TopAnchor, 0),
                    this.OutputResult.LeftAnchor.ConstraintEqualTo(this.InputWeight.LeftAnchor, 0),
                    this.OutputResult.RightAnchor.ConstraintEqualTo(this.InputWeight.RightAnchor,0),
                   
            });

        }

        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

