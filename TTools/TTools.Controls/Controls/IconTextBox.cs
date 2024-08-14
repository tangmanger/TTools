using Dicgo.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TTools.Controls
{
    [TemplatePart(Name = PART_Button, Type = typeof(Button))]
    [TemplatePart(Name = PART_Border, Type = typeof(Border))]
    public class IconTextBox : TextBox
    {
        const string PART_Button = "PART_Button";
        const string PART_Border = "PART_Border";
        Border? border = null;
        VisualBrush? visualBrush = null;
        public IconTextBox()
        {
            visualBrush = new VisualBrush();
            visualBrush.TileMode = TileMode.None;
            visualBrush.AutoLayoutContent = true;
            visualBrush.AlignmentX = AlignmentX.Left;
            visualBrush.AlignmentY = AlignmentY.Top;
            visualBrush.Stretch = Stretch.None;
            TranslateTransform translateTransform = new TranslateTransform();
            translateTransform.X = 16;
            translateTransform.Y = 8;
            visualBrush.Transform = translateTransform;
            this.IsKeyboardFocusedChanged += IconTextBox_IsKeyboardFocusedChanged; ;
            this.TextChanged += IconTextBox_TextChanged; ;
            this.Loaded += IconTextBox_Loaded; ;

        }

        private void IconTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (border == null) return;
            if (string.IsNullOrWhiteSpace(Text))
            {
                border.Background = visualBrush;
            }
            else
            {
                border.Background = Brushes.Transparent;
            }
        }

        private void IconTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (border == null) return;
            if (string.IsNullOrWhiteSpace(Text))
            {
                border.Background = visualBrush;
            }
            else
            {
                border.Background = Brushes.Transparent;
            }
        }

        private void IconTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (border == null) return;
            if ((bool)e.NewValue == false && string.IsNullOrWhiteSpace(Text))
            {
                border.Background = visualBrush;
            }
            else
            {
                border.Background = Brushes.Transparent;
            }
        }

        Button? button;
        public override void OnApplyTemplate()
        {
            border = GetTemplateChild(PART_Border) as Border;
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

        public string PlaceHolderText
        {
            get
            {
                var result = (string)GetValue(PlaceHolderTextProperty);
                return result;
            }
            set
            {
                SetValue(PlaceHolderTextProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for PlaceHolderText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderTextProperty =
            DependencyProperty.Register("PlaceHolderText", typeof(string), typeof(IconTextBox), new PropertyMetadata("", new PropertyChangedCallback(PlaceHolderTextChangedCallBack)));

        private static void PlaceHolderTextChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Margin = new Thickness(0, 0, 8, 0);
            textBlock.Visibility = Visibility.Visible;
            textBlock.FontSize = 12;
            var text = e.NewValue.ToString();
            IconTextBox placeholderTextBox = (IconTextBox)d;
            textBlock.Text = text.GetLangText();
            textBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C3C8DC"));
            if (placeholderTextBox.visualBrush != null)
                placeholderTextBox.visualBrush.Visual = textBlock;
        }


    }
}
