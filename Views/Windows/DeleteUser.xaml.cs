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
using WordAndSQL_Core.Collection;
using WordAndSQL_Core.ViewModels;

namespace WordAndSQL_Core.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteUserViewModel deleteUserViewModel = new DeleteUserViewModel();
            deleteUserViewModel.DeleteSelectedUser();
        }
    }
}
