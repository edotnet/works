using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Media.Animation;
using System.Windows.Threading;
using WpfApp1.Commands;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsGameOvered;
        public Button[][] Btn { get; set; }

        int movesCount = 0;

        public int MovesCount
        {
            get => movesCount;
            set
            {
                movesCount = value;
                OnPropertyChanged("MovesCount");
            }
        }

        private MainWindowViewModel()
        {
            Btn = new Button[4][];
            CreateButtons();
            InitButtons();
        }

        static MainWindowViewModel _instance;

        public static MainWindowViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new MainWindowViewModel();
            return _instance;
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ICommand OptionsCommand
        {
            get => new DelegateCommand(opt =>
            {
                OptionsWindow win = new OptionsWindow();
                win.Show();
            });
        }

        public ICommand ExitGame
        {
            get => new DelegateCommand(async opt =>
            {
                await Task.Delay(500);
                Application.Current.Windows[0].Close();
            });
        }

        public ICommand NewGame
        {
            get => new DelegateCommand(opt =>
            {
                IsGameOvered = false;
                MovesCount = 0;
                InitButtons();
            });
        }

        public ICommand Click
        {
            get => new DelegateCommand(opt =>
            {
                int x = 0, y = 0;
                for (int i = 0; i < Btn.GetLength(0); i++)
                {
                    for (int j = 0; j < Btn[i].Length; j++)
                    {
                        if (Btn[i][j].Content == ((Button)opt).Content)
                        {
                            x = i;
                            y = j;
                            i = Btn.GetLength(0);
                            break;
                        }
                    }
                }

                Button b = Btn[x][y];
                try
                {
                    if (Btn[x - 1][y].Content == null)
                        Change(b, Btn[x - 1][y]);
                }
                catch (IndexOutOfRangeException)
                {
                }
                try
                {
                    if (Btn[x][y - 1].Content == null)
                        Change(b, Btn[x][y - 1]);
                }
                catch (IndexOutOfRangeException)
                {
                }
                try
                {
                    if (Btn[x + 1][y].Content == null)
                        Change(b, Btn[x + 1][y]);
                }
                catch (IndexOutOfRangeException)
                {
                }
                try
                {
                    if (Btn[x][y + 1].Content == null)
                        Change(b, Btn[x][y + 1]);
                }
                catch (IndexOutOfRangeException)
                {
                }
            }, x => !IsGameOvered);
        }

        void Change(Button b1, Button b2)
        {
            Button b = new Button();
            b.Content = b1.Content;
            b.Background = b1.Background;
            b1.Content = b2.Content;
            b1.Background = b2.Background;
            b2.Content = b.Content;
            b2.Background = b.Background;

            MovesCount++;
            GameOvered();
        }



        void CreateButtons()
        {
            for (int i = 0; i < Btn.GetLength(0); i++)
            {
                Btn[i] = new Button[4];
                for (int j = 0; j < Btn[i].Length; j++)
                    Btn[i][j] = new Button();
            }
        }

        private void InitButtons()
        {
            List<int> vals = new List<int>();
            Random rd = new Random();

            for (int i = 0; i < Btn.GetLength(0); i++)
            {

                for (int j = 0; j < (i == (Btn.GetLength(0) - 1) ? Btn[i].Length - 1 : Btn[i].Length); j++)
                {
                    int x = rd.Next(1, 16);
                    while (vals.Contains(x))
                        x = rd.Next(1, 16);
                    vals.Add(x);
                    Btn[i][j].Content = x;
                    Btn[i][j].Background = new SolidColorBrush(Colors.DeepSkyBlue);
                }
            }
            Btn[3][3].Content = null;
            Btn[3][3].Background = null;
        }

        public void GameOvered()
        {
            if (Btn[3][3].Content != null)
                return;

            for (int i = 1; i <= 15; i++)
            {
                if ((int)Btn[i / 4][(int)(i % 4)].Content != i)
                    return;
            }

            IsGameOvered = true;
        }
    }
}
