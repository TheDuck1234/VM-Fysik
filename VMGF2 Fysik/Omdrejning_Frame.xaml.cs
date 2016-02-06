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
using System.Text.RegularExpressions;

namespace VMGF2_Fysik
{
    /// <summary>
    /// Interaction logic for Omdrejning_Frame.xaml
    /// </summary>
    public partial class Omdrejning_Frame : Window
    {
        public Omdrejning_Frame()
        {
            InitializeComponent();
            setup();


        }

        private void setup()
        {
            var list = new List<string>() { "n, Omdrejninger", "D, Diameter", "Vc, Skærehastighed"};
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 0;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedItem.Equals("n, Omdrejninger"))
            {
                try
                {
                    double Vc = Convert.ToDouble(textBox1.Text);
                    double D = Convert.ToDouble(textBox2.Text);
                    double total1 = Vc*1000;
                    double total2 = Math.PI*D;
                    double cal1 = (Vc*1000)/ (Math.PI * D);
                    string t1 = "(" + Vc + "* 1000)/(PI *" + D + ") = " + total1 + "/" + total2;
                    textBox3.Text = t1;
                    label3.Content = "N = " + cal1;
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem.Equals("n, Omdrejninger"))
            {
                label.Content = "Vc =";
                label.ToolTip = "Vc, Skærehastighed";
                label1.Content = "D =";
                label1.ToolTip = "D, Diameter";
            }
            if (comboBox.SelectedItem.Equals("D, Diameter"))
            {
                label.Content = "Vc =";
                label.ToolTip = "Vc, Skærehastighed";
                label1.Content = "n =";
                label1.ToolTip = "n, Omdrejninger";
            }
            if (comboBox.SelectedItem.Equals("Vc, Skærehastighed"))
            {
                label.Content = "D =";
                label.ToolTip = "D, Diameter";
                label1.Content = "n =";
                label1.ToolTip = "n, Omdrejninger";
            }
        }
    }
}
