using Dapper;
using Microsoft.Data.SqlClient;
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
using WordAndSQL_Core.Entity;
using WordAndSQL_Core.ViewModels;

namespace WordAndSQL_Core.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserPassport.xaml
    /// </summary>
    public partial class UserPassport : Window
    {
        public UserPassport()
        {
            InitializeComponent();
        }

        private void TableUser_Loaded(object sender, RoutedEventArgs e)
        {
            var user = new UserPassportViewModel();
            TableUser.ItemsSource = user.GetDataUsers();
        }
    }
}
