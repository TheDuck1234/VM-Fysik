using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace VMGF2_Fysik
{
    /// <summary>
    /// Interaction logic for OmdrejningFrame.xaml
    /// </summary>
    public partial class OmdrejningFrame : Window
    {
        private List<string> calList = new List<string>();

        public OmdrejningFrame()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            var list = new List<string>() { "n, Omdrejninger", "D, Diameter", "Vc, Skærehastighed", "Vf, Bordtilspænding", "fz, Tilspænding pr. tand" };
            var zList = new List<string>() {"1","2","3","4","5","6"};
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 0;
            comboBox1.ItemsSource = zList;
            comboBox1.SelectedIndex = 1;
            string text =
                        "D = Diameter(mm) \n \n Z = Antal tænder \n \n fZ = Tilspænding pr.tand(mm / z) \n \n fr = Tilspænding pr.rotation(mm / r) \n \n n = omdrejninger pr.minut(omdr./ min) \n \n  Vc = Skærehastighed(m / min) \n \n Vf = Bordtilspænding(mm / min) ";
            txtLabel.Content = text;
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
            if (comboBox.SelectedItem.Equals("Vf, Bordtilspænding"))
            {
                try
                {
                    double fz = Convert.ToDouble(textBox1.Text);
                    double n = Convert.ToDouble(textBox2.Text);
                    double Z = Convert.ToDouble(comboBox1.SelectedItem);

                    double cal1 = fz * n * Z;
                    cal1 = Math.Round(cal1, 3);
                    string t1 = fz +" * "+ Z + " * "+ n + " = " + cal1;
                    textBox3.Text = t1;
                    label3.Content = "Vf = " + cal1;
                    //UpdateList("Vc = " + cal1);
                }
                catch (Exception)
                {
                    Message("Fejl, skal være nummer i felterne");
                }
            }
            if (comboBox.SelectedItem.Equals("fz, Tilspænding pr. tand"))
            {
                try
                {
                    double Vf = Convert.ToDouble(textBox1.Text);
                    double n = Convert.ToDouble(textBox2.Text);
                    double Z = Convert.ToDouble(comboBox1.SelectedItem);
                    double total1 = n*Z;
                    total1 = Math.Round(total1, 3);
                    double cal1 = Vf/(n * Z);
                    cal1 = Math.Round(cal1, 3);
                    string t1 = Vf + " / ( " + Z + " * " + n + ") = "+Vf+" / "+total1+ " = " + cal1;
                    textBox3.Text = t1;
                    label3.Content = "fz = " + cal1;
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
            MessageBox.Show(message);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem.Equals("n, Omdrejninger"))
            {
                label.Content = "Vc =";
                textBox1.ToolTip = "Vc, Skærehastighed";
                label1.Content = "D =";
                textBox2.ToolTip = "D, Diameter";
                TandVisible(false);
            }
            if (comboBox.SelectedItem.Equals("D, Diameter"))
            {
                label.Content = "Vc =";
                textBox1.ToolTip = "Vc, Skærehastighed";
                label1.Content = "n =";
                textBox2.ToolTip = "n, Omdrejninger";
                TandVisible(false);
            }
            if (comboBox.SelectedItem.Equals("Vc, Skærehastighed"))
            {
                label.Content = "D =";
                textBox1.ToolTip = "D, Diameter";
                label1.Content = "n =";
                textBox2.ToolTip = "n, Omdrejninger";
                TandVisible(false);
            }
            if (comboBox.SelectedItem.Equals("Vf, Bordtilspænding"))
            {
                label.Content = "fz =";
                textBox1.ToolTip = "fz, Tilspænding pr. tand";
                label1.Content = "n =";
                textBox2.ToolTip = "n, Omdrejninger";
                TandVisible(true);
            }
            if (comboBox.SelectedItem.Equals("fz, Tilspænding pr. tand"))
            {
                label.Content = "Vf =";
                textBox1.ToolTip = "Vf, Bordtilspænding";
                label1.Content = "n =";
                textBox2.ToolTip = "n, Omdrejninger";
                TandVisible(true);
            }
        }

        private void TandVisible(bool check)
        {
            if (!check)
            {
                comboBox1.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
            }
            else
            {
                comboBox1.Visibility = Visibility.Visible;
                label5.Visibility = Visibility.Visible;
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
