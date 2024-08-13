using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TTools.Controls
{
    [TemplatePart(Name = PART_Button, Type = typeof(Button))]
    public class IconTextBox : TextBox
    {
        const string PART_Button = "PART_Button";
        public IconTextBox()
        {


        }
        Button? button;
        public override void OnApplyTemplate()
        {
            button = GetTemplateChild(PART_Button) as Button;
            if (button != null)
            {
                button.Click += Button_Click;
            }
            base.OnApplyTemplate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Command?.Execute(null);
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(IconTextBox));




    }
}
