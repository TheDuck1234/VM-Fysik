using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace VMGF2_Fysik
{
    /// <summary>
    /// Interaction logic for RetvinkletTrekant.xaml
    /// </summary>
    public partial class RetvinkletTrekant
    {
        public RetvinkletTrekant()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ClearColors();
            try
            {
                var tb = CheckTextBox();
                if (tb.Count < 2) return;
                var radians = 57.29577951308235;
                if (tb[0].Equals("boxa") && tb[1].Equals("boxb"))
                {
                    var a = Convert.ToDouble(boxa.Text);
                    var b = Convert.ToDouble(boxb.Text);
                    var c = Math.Sqrt((a * a) + (b * b));
                    c = Math.Round(c, 3);
                    var A = Math.Atan(a / b) * radians;
                    A = Math.Round(A, 3);
                    var B = 90 - A;
                    boxc.Text = ErrorCheck(c);
                    boxA.Text = ErrorCheck(A);
                    boxB.Text = ErrorCheck(B);

                    var math = "c = \u221A (" + a + "^2 + " + b + "^2) = " + c + " \n\n" +
                                  "A = Tan^-1(" + a + " / " + b + ") = " + A + " \n\n" +
                                  "B = 90 - " + A + " = " + B;
                    BoxS.Text = math;
                    boxa.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxa.BorderThickness = new Thickness(3);
                    boxb.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxb.BorderThickness = new Thickness(3);
                }
                    
                else if (tb[0].Equals("boxa") && tb[1].Equals("boxc"))
                {
                    var a = Convert.ToDouble(boxa.Text);
                    var c = Convert.ToDouble(boxc.Text);
                    var b = Math.Round(Math.Sqrt((c * c) - (a * a)), 3);
                    var A = Math.Round((Math.Asin(a / c)) * radians, 3);
                    var B = 90 - A;
                    boxb.Text = ErrorCheck(b);
                    boxA.Text = ErrorCheck(A);
                    boxB.Text = ErrorCheck(B);
                    var math = "b = \u221A (" + c + "^2 - "+ a + "^2) = " + c + " \n\n" +
                                  "A = Sin^-1(" + a + " / " + c + ") = " + A + " \n\n" +
                                  "B = 90 - " + A + " = " + B;
                    BoxS.Text = math;

                    boxa.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxa.BorderThickness = new Thickness(3);
                    boxc.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxc.BorderThickness = new Thickness(3);
                }
                else if (tb[0].Equals("boxb") && tb[1].Equals("boxc"))
                {
                    var b = Convert.ToDouble(boxb.Text);
                    var c = Convert.ToDouble(boxc.Text);
                    var a = Math.Round(Math.Sqrt((c * c) - (b * b)), 3);
                    var A = Math.Round(Math.Acos(b / c) * radians, 3);
                    var B = 90 - A;
                    boxa.Text = ErrorCheck(a);
                    boxA.Text = ErrorCheck(A);
                    boxB.Text = ErrorCheck(B);
                    string math = "b = \u221A (" + c + "^2 - " + b + "^2) = " + a + " \n\n" +
                                  "A = Sin^-1(" + b + " / " + c + ") = " + A + " \n\n" +
                                  "B = 90 - " + A + " = " + B;
                    BoxS.Text = math;

                    boxc.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxc.BorderThickness = new Thickness(3);
                    boxb.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxb.BorderThickness = new Thickness(3);
                }
                else if (tb[0].Equals("boxa") && tb[1].Equals("boxA"))
                {
                    var a = Convert.ToDouble(boxa.Text);
                    var A = Convert.ToDouble(boxA.Text);
                    var c = Math.Round(a / Math.Tan(A / radians), 3);
                    var b = Math.Round(a / Math.Sin(A / radians), 3);
                    var B = 90 - A;
                    boxc.Text = ErrorCheck(c);
                    boxb.Text = ErrorCheck(b);
                    boxB.Text = ErrorCheck(B);
                    var math = "c = " + a + " / Tan(" + A + ") = "+c+" \n\n" +
                                  "b = " + a + " / Sin(" + A + ") = "+b+" \n\n" +
                                  "B = 90 - " + A + " = " + B;
                    BoxS.Text = math;

                    boxa.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxa.BorderThickness = new Thickness(3);
                    boxA.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxA.BorderThickness = new Thickness(3);
                }
                else if (tb[0].Equals("boxb") && tb[1].Equals("boxA"))
                {
                    var A = Convert.ToDouble(boxA.Text);
                    var b = Convert.ToDouble(boxb.Text);
                    var a = Math.Round(b * Math.Tan(A / radians), 3);
                    var c = Math.Round(b / Math.Cos(A / radians), 3);
                    var B = 90 - A;
                    boxc.Text = ErrorCheck(c);
                    boxa.Text = ErrorCheck(a);
                    boxB.Text = ErrorCheck(B);
                    var math = "c = " + b + " * Tan(" + A + ") = "+c+" \n\n" +
                                  "a = " + b + " / Cos(" + A + ") = "+a+" \n\n" +
                                  "B = 90 - " + A + " = " + B;
                    BoxS.Text = math;

                    boxb.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxb.BorderThickness = new Thickness(3);
                    boxA.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxA.BorderThickness = new Thickness(3);
                }
                else if (tb[0].Equals("boxc") && tb[1].Equals("boxA"))
                {
                    var c = Convert.ToDouble(boxc.Text);
                    var A = Convert.ToDouble(boxA.Text);
                    var a = Math.Round(c * Math.Sin(A / radians), 3);
                    var b = Math.Round(c * Math.Cos(A / radians), 3);
                    var B = 90 - A;
                    boxa.Text = ErrorCheck(a);
                    boxb.Text = ErrorCheck(b);
                    boxB.Text = ErrorCheck(B);
                    string math = "b = " + c + " * Sin(" + A + ") = " + b + " \n\n" +
                                  "a = " + b + " * Cos(" + A + ") = " + a + " \n\n" +
                                  "B = 90 - " + A + " = " + B;
                    BoxS.Text = math;

                    boxc.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxc.BorderThickness = new Thickness(3);
                    boxA.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxA.BorderThickness = new Thickness(3);
                }
                else if (tb[0].Equals("boxa") && tb[1].Equals("boxB"))
                {
                    var a = Convert.ToDouble(boxa.Text);
                    var B = Convert.ToDouble(boxB.Text);
                    var b = Math.Round(a * Math.Tan(B / radians), 3);
                    var c = Math.Round(a / Math.Cos(B / radians), 3);
                    var A = 90 - B;
                    boxc.Text = ErrorCheck(c);
                    boxb.Text = ErrorCheck(b);
                    boxA.Text = ErrorCheck(A);
                    string math = "c = " + a + " / Cos(" + A + ") = " + c + " \n\n" +
                                  "b = " + a + " * Tan(" + A + ") = " + b + " \n\n" +
                                  "A = 90 - " + B + " = " + A;
                    BoxS.Text = math;

                    boxa.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxa.BorderThickness = new Thickness(3);
                    boxB.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxB.BorderThickness = new Thickness(3);
                }
                else if (tb[0].Equals("boxb") && tb[1].Equals("boxB"))
                {
                    var b = Convert.ToDouble(boxb.Text);
                    var B = Convert.ToDouble(boxB.Text);
                    var c = Math.Round(b/Math.Sin(B/radians), 3);
                    var a = Math.Round(b/Math.Tan(B/radians), 3);
                    var A = 90 - B;
                    boxc.Text = ErrorCheck(c);
                    boxa.Text = ErrorCheck(a);
                    boxA.Text = ErrorCheck(A);

                    boxb.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxb.BorderThickness = new Thickness(3);
                    boxB.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxB.BorderThickness = new Thickness(3);
                }
                else if (tb[0].Equals("boxc") && tb[1].Equals("boxB"))
                {
                    var c = Convert.ToDouble(boxc.Text);
                    var B = Convert.ToDouble(boxB.Text);
                    var a = Math.Round(c*Math.Cos(B/radians), 3);
                    var b = Math.Round(c*Math.Sin(B/radians), 3);
                    var A = 90 - B;
                    boxb.Text = ErrorCheck(b);
                    boxa.Text = ErrorCheck(a);
                    boxA.Text = ErrorCheck(A);

                    boxc.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxc.BorderThickness = new Thickness(3);
                    boxB.BorderBrush = new SolidColorBrush(Colors.Blue);
                    boxB.BorderThickness = new Thickness(3);
                }
            }
            catch (Exception)
            {
                Message("Fejl, skal være nummer i felterne");
            }
           

        }
        private void Message(string message)
        {
            MessageBox.Show(message);
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
