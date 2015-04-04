using Xamarin.Forms;

namespace Demo_WaitingPage
{
    public class WaitingPage : ContentPage
    {
        public static readonly BindableProperty IsWaitingProperty = BindableProperty.Create("IsWaiting", typeof(bool), typeof(WaitingPage), false);
        public static readonly BindableProperty LoadingMessageProperty = BindableProperty.Create("LoadingMessage", typeof(string), typeof(WaitingPage), "Loading...");
        public static readonly BindableProperty ShowLoadingMessageProperty = BindableProperty.Create("ShowLoadingMessage", typeof(bool), typeof(WaitingPage), false);

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

        public string LoadingMessage
        {
            get
            {
                return (string)GetValue(LoadingMessageProperty);
            }
            set
            {
                SetValue(LoadingMessageProperty, value);
            }
        }
        public bool ShowLoadingMessage
        {
            get
            {
                return (bool)GetValue(ShowLoadingMessageProperty);
            }
            set
            {
                SetValue(ShowLoadingMessageProperty, value);
            }
        }

        public new View Content
        {
            set
            {
                WaitingPageContent.Content = value;
            }
        }

        public ActivityIndicator Indicator { get; set; }

        private ContentView WaitingPageContent;
        private Grid ContentLayout;
        private Frame FrameLayout;

        public WaitingPage()
        {
            WaitingPageContent = new ContentView
            {
                Content = null,
            };

            ContentLayout = new Grid
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Padding = new Thickness(0, 0, 0, 0),
                BackgroundColor = Color.Transparent,
            };

            ContentLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            ContentLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            base.Content = ContentLayout;
        }

        protected override void OnAppearing()
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

            View finalIndicator = Indicator;

            if (ShowLoadingMessage)
            {
                FrameLayout = new Frame
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    BackgroundColor = Color.FromRgba(255, 255, 255, 1.0),   // White, Opaque. Required for Android
                    OutlineColor = Color.Black,
                    HasShadow = false,
                    Content = new StackLayout
                    {
                        Spacing = 15,
                        Children = {
                            new Label
                            {
                                TextColor = Color.Black,
                                Text = LoadingMessage,
                                FontSize = Device.GetNamedSize(NamedSize.Small, this)
                            }, 
                            Indicator
                        }
                    }
                };

                finalIndicator = FrameLayout;
            }

            // Each layout engine is different. This block helps ensure
            // that the indicator shows on top of the main content.
            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                    ContentLayout.Children.Add(WaitingPageContent, 0, 0);
                    ContentLayout.Children.Add(finalIndicator, 0, 0);
                    break;
                case TargetPlatform.Android:
                    ContentLayout.Children.Add(finalIndicator, 0, 0);
                    ContentLayout.Children.Add(WaitingPageContent, 0, 0);
                    break;
                case TargetPlatform.WinPhone:       // TODO: Verify
                    ContentLayout.Children.Add(WaitingPageContent, 0, 0);
                    ContentLayout.Children.Add(finalIndicator, 0, 0);
                    break;
            }
        }

        private void ShowIndicator()
        {
            if (Indicator != null)
            {
                Indicator.IsRunning = true;
            }

            if (FrameLayout != null)
            {
                FrameLayout.IsVisible = true;
            }
        }

        private void HideIndicator()
        {
            if (Indicator != null)
            {
                Indicator.IsRunning = false;
            }

            if (FrameLayout != null)
            {
                FrameLayout.IsVisible = false;
            }
        }
    }
}
