using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Demo_WaitingPage
{
    public class DemoPageCode : WaitingPage
    {
        public DemoPageCode()
        {
            var buttonOn = new Button
            {
                Text = "  On  ",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.End
            };

            var buttonOff = new Button
            {
                Text = "  Off  ",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End
            };

            buttonOn.Clicked += (sender, args) => { IsWaiting = true; };
            buttonOff.Clicked += (sender, args) => { IsWaiting = false; };

            var buttonStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Center,
                Children = { buttonOn, buttonOff }
            };

            var stack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                   new Label
                   {
                         VerticalOptions = LayoutOptions.CenterAndExpand,
                         HorizontalOptions = LayoutOptions.Center,
                         Text = "Hello ContentPage"
                   },
                   buttonStack
                }
            };

            LoadingMessage = "Loading...";

            Content = stack;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            IsWaiting = true;
        }
    }
}
