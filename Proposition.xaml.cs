using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Version_1
{
    /// <summary>
    /// Interaction logic for Proposition.xaml
    /// </summary>
    public partial class Proposition : Window
    {
        string CM = "Коментар";
        public Proposition()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Comm_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Comm_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Comm.Text == CM)
                Comm.Text = "";

        }

        private void Comm_LostFocus(object sender, RoutedEventArgs e)
        {
                if (Comm.Text == "")
                    Comm.Text = CM;
        }
    }
}
