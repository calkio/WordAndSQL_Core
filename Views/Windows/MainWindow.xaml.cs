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
using WordAndSQL_Core.Entity;
using WordAndSQL_Core.Infastructure.Commands;
using WordAndSQL_Core.ViewModels;
using WordAndSQL_Core.Views.Windows;

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

        private void UserGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            UserPassport userPassport = new UserPassport();
            userPassport.Owner = Application.Current.MainWindow;
            userPassport.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            userPassport.ShowDialog();
        }
    }
}
