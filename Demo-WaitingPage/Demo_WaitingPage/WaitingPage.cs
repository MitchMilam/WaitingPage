using Xamarin.Forms;

namespace Demo_WaitingPage
{
    public class WaitingPage : ContentPage
    {
        public static readonly BindableProperty IsWaitingProperty = BindableProperty.Create("IsWaiting", typeof(bool), typeof(WaitingPage), false);
        public static readonly BindableProperty LoadingMessageProperty = BindableProperty.Create("LoadingMessage", typeof(string), typeof(WaitingPage), string.Empty);

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

        private ContentView WaitingPageContent;
        public new View Content
        {
            set
            {
                WaitingPageContent.Content = value;
            }
        }

        public ActivityIndicator Indicator { get; set; }

        private Grid Layout;
        private Frame FrameLayout;

        public WaitingPage()
        {
            WaitingPageContent = new ContentView
            {
                Content = null,
            };

            Layout = new Grid
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Padding = new Thickness(0, 0, 0, 8),
                BackgroundColor = Color.Transparent,
            };

            Layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            Layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            base.Content = Layout;
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

            Layout.Children.Add(WaitingPageContent, 0, 0);

            if (!string.IsNullOrEmpty(LoadingMessage))
            {
                FrameLayout = new Frame
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    BackgroundColor = Color.White,
                    OutlineColor = Color.Black,
                    HasShadow = false,
                    Content = new StackLayout
                    {
                        Spacing = 15,
                        Children = {
                            new Label
                            {
                                Text = LoadingMessage,
                                FontSize = Device.GetNamedSize(NamedSize.Small, this)
                            }, 
                            Indicator
                        }
                    }
                };

                Layout.Children.Add(FrameLayout, 0, 0);
            }
            else
            {
                Layout.Children.Add(Indicator, 0, 0);
            }
        }

        private void ShowIndicator()
        {
            if (Indicator == null)
            {
                return;
            }

            if (FrameLayout != null)
            {
                FrameLayout.IsVisible = true;
            }

            Indicator.IsRunning = true;
        }

        private void HideIndicator()
        {
            if (Indicator == null)
            {
                return;
            }

            if (FrameLayout != null)
            {
                FrameLayout.IsVisible = false;
            }

            Indicator.IsRunning = false;
        }
    }
}
