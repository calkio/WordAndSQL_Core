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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowviewModel = new MainWindowViewModel();
            mainWindowviewModel.FindGroup();

            GroupGrid.ItemsSource = GroupsObservableCollection.Groups;
        }

        private void FindGroupTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindowViewModel mainWindowviewModel = new MainWindowViewModel();
            MainWindowViewModel.TextFindGroup = FindGroupTB.Text;
            mainWindowviewModel.FindGroup();

            GroupGrid.ItemsSource = GroupsObservableCollection.Groups;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowviewModel = new MainWindowViewModel();
            mainWindowviewModel.FindUser();

            UserGrid.ItemsSource = UsersObservableCollection.Users;
        }

        private void FindUserTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindowViewModel mainWindowviewModel = new MainWindowViewModel();
            MainWindowViewModel.TextFindUser = FindUserTB.Text;
            mainWindowviewModel.FindUser();

            UserGrid.ItemsSource = UsersObservableCollection.Users;
        }
    }
}
