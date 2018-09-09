using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties
        int Clicks { get; set; } = 0;
        bool GameOver { get; set; } = false;
        Button[][] Buttons = new Button[3][];
        ObservableCollection<string> Player1Items;
        ObservableCollection<string> Player2Items;

        #endregion
        public MainWindow()
        {
            InitializeComponent();
            InitializeButtons(Buttons);
            Player1Items = new ObservableCollection<string>();
            Player2Items = new ObservableCollection<string>();
            DataContext = this;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!GameOver && ((Button)sender).Content == null)
            {
                Button btn = (Button)sender;
                btn.Opacity = 0;
                btn.Content = Clicks++ % 2 == 0 ? "X" : "O";
                for (double i = 0; i <= 1; i += 0.1)
                {
                    btn.Opacity = i;
                }
                await CheckWinnerAsync();
            }
        }

        private void InitializeButtons(Button[][] buttons)
        {
            for (int i = 0; i < 3; i++)
            {
                buttons[i] = new Button[3];
                for (int j = 0; j < 3; j++)
                {
                    buttons[i][j] = (Button)(Container.Children.Cast<UIElement>().FirstOrDefault(e => Grid.GetRow(e) == i + 1 && Grid.GetColumn(e) == j));
                }
            }
        }


        private async Task CheckWinnerAsync()
        {
            if (Clicks >= 5)
            {
                string d1 = Buttons[0][0].Content?.ToString();
                string d2 = Buttons[0][Buttons.Length - 1].Content?.ToString();

                for (int i = 0; i < Buttons.Length; i++)
                {
                    int j = 0;
                    bool xy1 = false;
                    bool xy2 = false;
                    string horizontal = Buttons[i][0].Content?.ToString();
                    string vertical = Buttons[0][i].Content?.ToString();

                    bool x = Buttons[i].Any(e => e.Content == null) ? false : Buttons[i].All(e => e.Content.ToString() == horizontal);
                    bool y = Buttons.Any(e => e[i].Content == null) ? false : Buttons.All(e => e[i].Content.ToString() == vertical);
                    bool x1 = Buttons.Any(e => e[j++].Content == null);
                    j = 0;
                    bool x2 = Buttons.Any(e => e[Buttons.Length - 1 - j++].Content == null);
                    j = 0;
                    if (!x1)
                    {
                        j = 0;
                        xy1 = Buttons.All(e => e[j++].Content.ToString() == d1);
                    }
                    j = 0;

                    if (!x2)
                    {
                        j = 0;
                        xy2 = Buttons.All(e => e[Buttons.Length - 1 - j++].Content.ToString() == d2);
                    }

                    if (xy1)
                    {
                        for (int k = 0; k < Buttons.Length; k++)
                        {
                            Buttons[k][k].Background = new SolidColorBrush(Colors.MediumVioletRed);
                        }
                        await End(d1);
                        return;

                    }

                    if (xy2)
                    {
                        for (int k = 0; k < Buttons.Length; k++)
                        {
                            Buttons[Buttons.Length - 1 - k][k].Background = new SolidColorBrush(Colors.MediumVioletRed);
                        }
                        await End(d2);
                        return;

                    }

                    if (x)
                    {
                        foreach (var item in Buttons[i])
                        {
                            item.Background = new SolidColorBrush(Colors.GreenYellow);
                        }
                        await End(horizontal);
                        return;

                    }

                    if (y)
                    {
                        foreach (var item in Buttons)
                        {
                            item[i].Background = new SolidColorBrush(Colors.GreenYellow);
                        }
                        await End(vertical);
                        return;
                    }
                }
            }
        }

        private async Task End(string str)
        {
            GameOver = true;
            if (str == "X")
            {
                await Task.Run(() =>
                 {
                     Player1Items.Add(str);
                 });
                LS1.Items.Add(str + $" ({Player1Items.Count})");
                LS1.ScrollIntoView(LS1.Items[LS1.Items.Count-1]);
            }
            else
            {
                await Task.Run(() =>
                {
                    Player2Items.Add(str);
                });
                LS2.Items.Add(str + $" ({Player2Items.Count})");
                LS2.Items.MoveCurrentToLast();
                LS2.ScrollIntoView(LS2.Items.CurrentItem);
            }
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            GameOver = false;
            Clicks = 0;
            foreach (var item in Buttons)
            {
                foreach (var x in item)
                {
                    x.Background = new SolidColorBrush(Colors.Azure);
                    x.Content = null;
                }
            }
        }
    }
}
