using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MemberWiseCloneTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondWindow : Page
    {
        public SecondWindow()
        {
            this.InitializeComponent();
        }

        public TestValue TestValue
        {
            get { return (TestValue)GetValue(TestValueProperty); }
            set { SetValue(TestValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TestValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TestValueProperty =
            DependencyProperty.Register("TestValue", typeof(TestValue), typeof(MainPage), new PropertyMetadata(null));


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is TestValue tvalue)
            {
                TestValue = tvalue;
            }
        }

        private async void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TestValue = TestValue;
            TestValue.b = !TestValue.b;
            TestValue.a += 1;
        }
    }
}