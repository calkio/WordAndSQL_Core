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
using WordAndSQL_Core.ViewModels;

namespace WordAndSQL_Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mainWindowViewModel  = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TableAllUser_Loaded(object sender, RoutedEventArgs e)
        {
            TableAllUser.ItemsSource = mainWindowViewModel.GetDataUsers();
        }
    }
}
