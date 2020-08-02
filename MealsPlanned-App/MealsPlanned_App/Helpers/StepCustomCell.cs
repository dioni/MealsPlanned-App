using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MealsPlanned_App.Helpers
{
    public class StepCustomCell : ViewCell
    {
        Label stepLabel, descriptionLabel;

        public StepCustomCell()
        {
            stepLabel = new Label();
            descriptionLabel = new Label();
        }

        public static readonly BindableProperty StepProperty =
            BindableProperty.Create("Step", typeof(string), typeof(StepCustomCell), "Step");

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create("Description", typeof(string), typeof(StepCustomCell), "Description");

        public string Step
        {
            get { return (string)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }



        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                stepLabel.Text = Step;
                descriptionLabel.Text = Description;
            }
        }
    }
}
