using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealsPlanned_App.CustomView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientView : ContentView
    {
        public IngredientView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty QuantityProperty =
            BindableProperty.Create(nameof(Quantity), typeof(string), typeof(IngredientView), string.Empty);

        public string Quantity
        {
            get => (string)GetValue(QuantityProperty);
            set => SetValue(QuantityProperty, value);
        }


        public static readonly BindableProperty UnityOfMeasureNameProperty =
            BindableProperty.Create(nameof(UnityOfMeasureName), typeof(string), typeof(IngredientView), string.Empty);

        public string UnityOfMeasureName
        {
            get => (string)GetValue(UnityOfMeasureNameProperty);
            set => SetValue(UnityOfMeasureNameProperty, value);
        }


        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(nameof(Name), typeof(string), typeof(IngredientView), string.Empty);

        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }


        public static readonly BindableProperty ObservationProperty =
            BindableProperty.Create(nameof(Observation), typeof(string), typeof(IngredientView), string.Empty);

        public string Observation
        {
            get => (string)GetValue(ObservationProperty);
            set => SetValue(ObservationProperty, value);
        }
    }
}