# WaitingPage
Xamarin.Forms page design with a built-in indicator

#Properties


##IsWaiting (bool, bindable)
**true** Shows the waiting indicator, **false** hides the waiting indicator.


##ShowLoadingFrame (bool, bindable)
**true** Wraps the waiting indicator in a frame. **false** simply shows the waiting indicator by itself.


##ShowLoadingMessage (bool, bindable)
**true** Shows a message along with the waiting indicator, **false** simply shows the waiting indicator by itself.


##ShadeBackground (bool, bindable)
**true** will shade the background of the page a light grey while the indicator is active, **false** will not employ shading.


##LoadingMessage (string, bindable)
Allows you to specify a waiting message along with the waiting indicator. The default is **Loading...**.


##WaitingOrientation (StackOrientation, bindable)
Shows the waiting indicator either vertically or horizontally. If you only have the indicator, this properly is pretty much ignored.  But if you are using a waiting message, it will display the message above the indicatore (vertical) or to the right of the indicator (horizatontal).


##Indicator (ActivityIndicator)
You may specify your own pre-created ActivityIndicator if you wish. If one is not specified, a new one will be created.
