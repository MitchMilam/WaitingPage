using Xamarin.Forms;

namespace Demo_WaitingPage
{
    public class BusyPage : ContentPage
    {
        private StackLayout _activityLayout;
        private bool _showBusy;
        public bool ShowBusy
        {
            get { return _showBusy; }
            set
            {
                _showBusy = _activityLayout.IsVisible = value;
            }
        }
        private ContentView _busyPageContent;
        public new View Content
        {
            set
            {
                _busyPageContent.Content = value;
            }
        }

        public BusyPage()
        {
            var activityIndicator = new ActivityIndicator
            {
                IsVisible = true,
                IsEnabled = true,
                IsRunning = true,
            };

            var activityLabel = new Label
            {
                Text = "Loading...",
            };

            var centeredLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 0,
                Children = { activityIndicator, activityLabel },
            };

            _activityLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                IsVisible = false,
                Children = { centeredLayout },
                BackgroundColor = Color.FromRgba(255, 255, 255, 30),
            };

            var layout = new RelativeLayout();

            _busyPageContent = new ContentView
            {
                Content = null,
            };

            layout.Children.Add(_busyPageContent,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent(parent => parent.Width),
                Constraint.RelativeToParent(parent => parent.Height));
            layout.Children.Add(_activityLayout,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent(parent => parent.Width),
                Constraint.RelativeToParent(parent => parent.Height));
            base.Content = layout;

        }
    }
}

