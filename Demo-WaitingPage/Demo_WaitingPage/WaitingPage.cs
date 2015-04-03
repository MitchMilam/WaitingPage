using Xamarin.Forms;

namespace Demo_WaitingPage
{
    public class WaitingPage : ContentPage
    {
        public static readonly BindableProperty IsWaitingProperty = BindableProperty.Create("IsWaiting", typeof(bool), typeof(WaitingPage), false);

        /// <value><c>true</c> if rounded; otherwise, <c>false</c>.</value>
        public bool IsWaiting
        {
            get
            {
                return (bool)GetValue(IsWaitingProperty);
            }
            set
            {
                if (value)
                {
                    ShowIndicator();
                }
                else
                {
                    HideIndicator();
                }
            }
        }

        public View MainView { get; set; }
        public ActivityIndicator Indicator { get; set; }

        private Grid Layout;

        public WaitingPage()
        {
            Layout = new Grid
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Padding = new Thickness(0, 0, 0, 8),
                BackgroundColor = Color.Transparent,
            };

            Layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            Layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            Content = Layout;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Indicator == null)
            {
                Indicator = new ActivityIndicator
                {
                    Color = Color.Black,
                    Scale = 1.5,
                    IsEnabled = true,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Center,
                };
            }

            if (IsWaiting)
            {
                ShowIndicator();
            }

            Layout.Children.Add(MainView, 0, 0);
            Layout.Children.Add(Indicator, 0, 0);
        }

        private void ShowIndicator()
        {
            if (Indicator == null)
            {
                return;
            }

            Indicator.IsRunning = true;
        }

        private void HideIndicator()
        {
            if (Indicator == null)
            {
                return;
            } 

            Indicator.IsRunning = false;
        }
    }
}
