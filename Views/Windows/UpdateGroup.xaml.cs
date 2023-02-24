using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WordAndSQL_Core.Collection;
using WordAndSQL_Core.ViewModels;

namespace WordAndSQL_Core.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdateGroup.xaml
    /// </summary>
    public partial class UpdateGroup : Window
    {
        public UpdateGroup()
        {
            InitializeComponent();
        }

        private void UserGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var groupsInUserObservableCollection = new GroupsInUserObservableCollection();
            GroupsInUser.ItemsSource = GroupsInUserObservableCollection.Groups;
        }

        private void UserGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var updateGroupViewModel = new UpdateGroupViewModel();
            updateGroupViewModel.UpdateUserGrid();
            var usersInGroupObservableCollection = new UsersInGroupObservableCollection();
            UsersInSelectedGroup.ItemsSource = UsersInGroupObservableCollection.Users;
        }

        private void UsersInSelectedGroup_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var updateGroupViewModel = new UpdateGroupViewModel();
            updateGroupViewModel.UpdateUsersInSelectedGroup();
            var allUsersUpdateGroupObservableCollection = new AllUsersUpdateGroupObservableCollection();
            UserGrid.ItemsSource = AllUsersUpdateGroupObservableCollection.Users;
        }
    }
}
