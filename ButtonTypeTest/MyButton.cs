using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace ButtonTypeTest
{
    public enum XButtonType
    {
        TopState,
        HiddenTopState
    }
    public sealed class MyButton : Button
    {
        public MyButton()
        {
            this.DefaultStyleKey = typeof(MyButton);
            Loaded += MyButton_Loaded;

        }

        private void MyButton_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonType = (XButtonType)GetValue(ButtonTypeProperty);
        }

        public XButtonType ButtonType
        {
            get { return (XButtonType)GetValue(ButtonTypeProperty); }
            set { SetValue(ButtonTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonTypeProperty =
            DependencyProperty.Register("ButtonType", typeof(XButtonType), typeof(MyButton), new PropertyMetadata(null, new PropertyChangedCallback(OnButtonTypeChange)));

        private static void OnButtonTypeChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MyButton;

            switch ((XButtonType)e.NewValue)
            {
                case XButtonType.TopState:
                    VisualStateManager.GoToState(control, "TopState", false);
                    break;
                case XButtonType.HiddenTopState:
                    VisualStateManager.GoToState(control, "HiddenTopState", false);
                    break;
                default:
                    break;
            }
        }
    }
}
