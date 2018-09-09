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
using WpfApp1.Converters;

namespace WpfApp1.ViewModels
{
    class OptionsViewModel
    {
        static OptionsViewModel _instance;
        Colors color { get; set; }
        public MyConverter MyCon { get; set; } = new MyConverter();
        MainWindowViewModel Mv { get; set; }
        private OptionsViewModel()
        {
            Mv = MainWindowViewModel.GetInstance();
        }

        public static OptionsViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new OptionsViewModel();
            return _instance;
        }

        public ICommand SelectionChanged
        {
            get => new DelegateCommand(opt =>
            {
                SelectionChangedEventArgs s = opt as SelectionChangedEventArgs;
                string y = ((ListBoxItem)s.AddedItems[0]).Content.ToString();
                #region Change Colors
                switch (y)
                {
                    case "Aqua":
                        foreach (var item in Mv.Btn)
                        {
                            foreach (var x in item)
                            {
                                if (x.Background != null)
                                    x.Background = new SolidColorBrush(Colors.Aqua);
                            }
                        }
                        break;
                    case "Aquamarine":
                        foreach (var item in Mv.Btn)
                        {
                            foreach (var x in item)
                            {
                                if (x.Background != null)
                                    x.Background = new SolidColorBrush(Colors.Aquamarine);
                            }
                        }
                        break;
                    case "AliceBlue":
                        foreach (var item in Mv.Btn)
                        {
                            foreach (var x in item)
                            {
                                if (x.Background != null)
                                    x.Background = new SolidColorBrush(Colors.AliceBlue);
                            }
                        }
                        break;
                    case "Green":
                        foreach (var item in Mv.Btn)
                        {
                            foreach (var x in item)
                            {
                                if (x.Background != null)
                                    x.Background = new SolidColorBrush(Colors.Green);
                            }
                        }
                        break;
                    case "DarkGreen":
                            foreach (var item in Mv.Btn)
                            {
                                foreach (var x in item)
                                {
                                    if (x.Background != null)
                                        x.Background = new SolidColorBrush(Colors.DarkGreen);
                                }
                            }
                        break;
                    case "DeepSkyBlue":
                        foreach (var item in Mv.Btn)
                        {
                            foreach (var x in item)
                            {
                                if (x.Background != null)
                                    x.Background = new SolidColorBrush(Colors.DeepSkyBlue);
                            }
                        }
                        break;
                    case "Pink":
                        foreach (var item in Mv.Btn)
                        {
                            foreach (var x in item)
                            {
                                if (x.Background != null)
                                    x.Background = new SolidColorBrush(Colors.Pink);
                            }
                        }
                        break;
                    case "Yellow":
                        foreach (var item in Mv.Btn)
                        {
                            foreach (var x in item)
                            {
                                if (x.Background != null)
                                    x.Background = new SolidColorBrush(Colors.Yellow);
                            }
                        }
                        break;
                    case "YellowGreen":
                        foreach (var item in Mv.Btn)
                        {
                            foreach (var x in item)
                            {
                                if (x.Background != null)
                                    x.Background = new SolidColorBrush(Colors.YellowGreen);
                            }
                        }
                        break;
                }
                #endregion 
            });
        }
    }
}
