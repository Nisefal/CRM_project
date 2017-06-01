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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Version_4
{
    /// <summary>
    /// Interaction logic for StanTask_1.xaml
    /// </summary>
    public partial class StanTask_1 : Page
    {
        public StanTask_1()
        {
            InitializeComponent();
            string var = Slide.Value.ToString();
        }

        private void Slide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsInitialized)
            {
                string[] line = Slide.Value.ToString().Split(',');
                if (line.Length > 1)
                {
                    if (line[1].Length > 2)
                        PriceBox.Text = line[0] + "," + line[1].Remove(2);
                    else
                        PriceBox.Text = line[0] + "," + line[1];
                }
                else
                    PriceBox.Text = line[0];
            }
        }

        private void PriceBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PriceBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try 
            {
                double var = Convert.ToDouble(PriceBox.Text);
                Slide.Value = var;
            }
            catch(Exception)
            {
                PriceBox.Text = Slide.Value.ToString();
            }
        }

        
    }
}
