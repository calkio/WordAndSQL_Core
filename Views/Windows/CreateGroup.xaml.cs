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
using WordAndSQL_Core.ViewModels;

namespace WordAndSQL_Core.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateGroup.xaml
    /// </summary>
    public partial class CreateGroup : Window
    {
        CreateGroupViewModel createGroupViewModel = new CreateGroupViewModel();

        public CreateGroup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            createGroupViewModel.CreateGroup(VidCB.Text, DirectionCB.Text, FirstNameTB.Text, NumberTB.Text, StartDateDP.Text, EndDateDP.Text);
        }
    }
}
