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

namespace VMGF2_Fysik
{
    /// <summary>
    /// Interaction logic for RetvinkletTrekant.xaml
    /// </summary>
    public partial class RetvinkletTrekant : Window
    {
        public RetvinkletTrekant()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ClearColors();
            var tb = CheckTextBox();
            if (tb.Count >= 2)
            {
                double Radians = 57.29577951308235;
                if (tb[0].Equals("boxa") && tb[1].Equals("boxb"))
                {
                    double a = Convert.ToDouble(boxa.Text);
                    double b = Convert.ToDouble(boxb.Text);
                    double c = Math.Sqrt((a*a) + (b*b));
                    c = Math.Round(c, 3);
                    double A = Math.Tan(a/b)* Radians;
                    A= Math.Round(A, 3);
                    double B = 90 - A;
                    boxc.Text = ErrorCheck(c);
                    boxA.Text = ErrorCheck(A);
                    boxB.Text = ErrorCheck(B);

                    string math = "c = \u221A ("+a+"^2 + "+b+"^2) = "+c+ " \n\n" +
                                  "A = Tan("+a+" / "+b+") = "+A+ " \n\n" +
                                  "B = 90 - "+A+" = "+B;
                    BoxS.Text = math;
                    boxa.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxa.BorderThickness = new Thickness(3);
                    boxb.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxb.BorderThickness = new Thickness(3);
                }
                if (tb[0].Equals("boxa") && tb[1].Equals("boxc"))
                {
                    double a = Convert.ToDouble(boxa.Text);
                    double c = Convert.ToDouble(boxc.Text);
                    double b = Math.Round(Math.Sqrt((c*c) - (a*a)),3);
                    double A = Math.Round((Math.Asin(a/c))*Radians, 3);
                    double B = 90 - A;
                    boxb.Text = ErrorCheck(b);
                    boxA.Text = ErrorCheck(A);
                    boxB.Text = ErrorCheck(B);

                    boxa.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxa.BorderThickness = new Thickness(3);
                    boxc.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxc.BorderThickness = new Thickness(3);
                }
            }

        }

        private string ErrorCheck(double tal)
        {
            if (tal < 0)
            {
                return "Error";
            }
            return "" + tal;
        }
        private void ClearColors()
        {
            boxa.BorderBrush = null;
            boxb.BorderBrush = null;
            boxc.BorderBrush = null;
            boxA.BorderBrush = null;
            boxB.BorderBrush = null;

            boxa.BorderThickness = new Thickness(1);
            boxb.BorderThickness = new Thickness(1);
            boxc.BorderThickness = new Thickness(1);
            boxA.BorderThickness = new Thickness(1);
            boxB.BorderThickness = new Thickness(1);
        }
        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
        private List<string> CheckTextBox()
        {
            var tb = new List<string>();
            if (!string.IsNullOrEmpty(boxa.Text))
            {
                tb.Add(boxa.Name);
            }
            if (!string.IsNullOrEmpty(boxb.Text))
            {
                tb.Add(boxb.Name);
            }
            if (!string.IsNullOrEmpty(boxc.Text))
            {
                tb.Add(boxc.Name);
            }
            if (!string.IsNullOrEmpty(boxA.Text))
            {
                tb.Add(boxA.Name);
            }
            if (!string.IsNullOrEmpty(boxB.Text))
            {
                tb.Add(boxB.Name);
            }
            return tb;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ClearColors();

            boxa.Text = "";
            boxc.Text = "";
            boxb.Text = "";
            boxA.Text = "";
            boxB.Text = "";

            BoxS.Text = "";
        }
    }
}
