using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        }
        public XButtonType ButtonType
        {
            get { return (XButtonType)GetValue(ButtonTypeProperty); }
            set { SetValue(ButtonTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonTypeProperty =
            DependencyProperty.Register("ButtonType", typeof(XButtonType), typeof(MyButton), new PropertyMetadata(0, new PropertyChangedCallback(OnButtonTypeChange)));

        private static void OnButtonTypeChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MyButton;
            switch ((XButtonType)e.NewValue)
            {
                case XButtonType.TopState:
                    VisualStateManager.GoToState(control, "TopState", true);
                    break;
                case XButtonType.HiddenTopState:
                    VisualStateManager.GoToState(control, "HiddenTopState", true);
                    break;
                default:
                    break;
            }
        }
    }
}
