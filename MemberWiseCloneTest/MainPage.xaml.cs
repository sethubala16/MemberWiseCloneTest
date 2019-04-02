using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MemberWiseCloneTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<string> itemsource = new List<string> { "Hi", "Hello" };
        public MainPage()
        {
            tValue = new TestValue();
            tValue.a = 1;
            tValue.b = false;
            this.InitializeComponent();
        }



        public TestValue tValue
        {
            get { return (TestValue)GetValue(tValueProperty); }
            set { SetValue(tValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for tValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty tValueProperty =
            DependencyProperty.Register("tValue", typeof(TestValue), typeof(MainPage), new PropertyMetadata(null));

        //public TestValue tValue;


        private async void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var currentApplicationView = ApplicationView.GetForCurrentView();
            var newCoreApplicationView = CoreApplication.CreateNewView();
            tValue.a += 1;
            tValue.b = !tValue.b;
            var newvalue = tValue.Clone();

            ApplicationView newApplicationView = null;

            await newCoreApplicationView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                newApplicationView = ApplicationView.GetForCurrentView();
                var newWindow = Window.Current;
                var frame = new Frame();
                frame.Navigate(typeof(SecondWindow), newvalue);
                newWindow.Content = frame;
                newWindow.Activate();
            });

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newApplicationView.Id, ViewSizePreference.Default);
        }
    }
}