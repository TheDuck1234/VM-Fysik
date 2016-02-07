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
        private List<string> calList = new List<string>();

        public Omdrejning_Frame()
        {
            InitializeComponent();
            setup();
        }

        private void setup()
        {
            var list = new List<string>() { "n, Omdrejninger", "D, Diameter", "Vc, Skærehastighed" };
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 0;
            //listBox.DataContext = calList;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (comboBox.SelectedItem.Equals("n, Omdrejninger"))
            {
                try
                {
                    double Vc = Convert.ToDouble(textBox1.Text);
                    double D = Convert.ToDouble(textBox2.Text);
                    double total1 = Vc * 1000;
                    double total2 = Math.PI * D;
                    total1 = Math.Round(total1, 3);
                    total2 = Math.Round(total2, 3);
                    double cal1 = (Vc * 1000) / (Math.PI * D);
                    cal1 = Math.Round(cal1, 3);
                    string t1 = "(" + Vc + "* 1000)/( PI *" + D + ") = " + total1 + "/" + total2 + " = " + cal1;
                    t1 = t1.Replace("PI", "\u03C0");
                    textBox3.Text = t1;
                    label3.Content = "N = " + cal1;
                   // UpdateList("N = " + cal1);


                }
                catch (Exception)
                {
                    Message("Fejl, skal være nummer i felterne");
                }
            }
            if (comboBox.SelectedItem.Equals("D, Diameter"))
            {
                try
                {
                    double Vc = Convert.ToDouble(textBox1.Text);
                    double n = Convert.ToDouble(textBox2.Text);
                    double total1 = (Vc * 1000);
                    double total2 = (Math.PI * n);
                    total1 = Math.Round(total1, 3);
                    total2 = Math.Round(total2, 3);
                    double cal1 = (Vc * 1000) / (Math.PI * n);
                    cal1 = Math.Round(cal1, 3);
                    string t1 = "(" + Vc + " * 1000)/( PI *" + n + ") = " + total2 + "/" + total1 + " = " + cal1;
                    t1 = t1.Replace("PI", "\u03C0");
                    textBox3.Text = t1;
                    label3.Content = "D = " + cal1;
                   // UpdateList("D = " + cal1);
                }
                catch (Exception)
                {
                    Message("Fejl, skal være nummer i felterne");
                }

            }
            if (comboBox.SelectedItem.Equals("Vc, Skærehastighed"))
            {
                try
                {
                    double D = Convert.ToDouble(textBox1.Text);
                    double n = Convert.ToDouble(textBox2.Text);
                    double total1 = D * n * Math.PI;
                    total1 = Math.Round(total1, 3);
                    double cal1 = (1000) / (Math.PI * D * n);
                    cal1 = Math.Round(cal1, 3);
                    string t1 = "1000/( PI *" + D + " * " + n + ") =  1000/" + total1 + " = " + cal1;
                    t1 = t1.Replace("PI", "\u03C0");
                    textBox3.Text = t1;
                    label3.Content = "Vc = " + cal1;
                    //UpdateList("Vc = " + cal1);
                }
                catch (Exception)
                {
                    Message("Fejl, skal være nummer i felterne");
                }

            }
        }

        //private void UpdateList(string text)
        //{
        //    calList.Add(text);
        //    listBox.ItemsSource = null;
        //    // Bind ArrayList with the ListBox
        //    listBox.ItemsSource = calList;
        //}
        private void Message(string message)
        {
            MessageBoxResult result = MessageBox.Show(message);
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem.Equals("n, Omdrejninger"))
            {
                label.Content = "Vc =";
                textBox1.ToolTip = "Vc, Skærehastighed";
                label1.Content = "D =";
                textBox2.ToolTip = "D, Diameter";
            }
            if (comboBox.SelectedItem.Equals("D, Diameter"))
            {
                label.Content = "Vc =";
                textBox1.ToolTip = "Vc, Skærehastighed";
                label1.Content = "n =";
                textBox2.ToolTip = "n, Omdrejninger";
            }
            if (comboBox.SelectedItem.Equals("Vc, Skærehastighed"))
            {
                label.Content = "D =";
                textBox1.ToolTip = "D, Diameter";
                label1.Content = "n =";
                textBox2.ToolTip = "n, Omdrejninger";
            }
        }

        private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
