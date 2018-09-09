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

namespace FractalTree
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 10;
        double deg_to_rad;
        public MainWindow()
        {
            InitializeComponent();
            MyGrid.Background = new SolidColorBrush(Colors.Black);
            DrawLine(400, 700, -90, 0);
        }

        public void DrawLine(double xx1, double yy1, double angle, int n)
        {
            if (n < count)
            {
                Line l1 = new Line();
                l1.X1 = xx1;
                l1.Y1 = yy1;

                l1.X2 = xx1 + Math.Cos(Math.PI * angle / 180.0) *50;
                l1.Y2 = yy1 + Math.Sin(Math.PI * angle / 180.0) *50;

                l1.Stroke = new SolidColorBrush(Colors.White);

                MyGrid.Children.Add(l1);

                DrawLine(l1.X2, l1.Y2, angle - 20, n + 1);
                DrawLine(l1.X2, l1.Y2, angle + 20, n + 1);
                DrawLine(l1.X2, l1.Y2, angle , n + 1);
            }
        }
    }
}
