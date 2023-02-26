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
using WordAndSQL_Core.Collection;
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

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UpdateGroup updateGroup = new UpdateGroup();
            updateGroup.Owner = Application.Current.MainWindow;
            updateGroup.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            updateGroup.ShowDialog();
        }
    }
}
