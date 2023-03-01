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
        UpdateGroupViewModel updateGroupViewModel = new UpdateGroupViewModel();

        public UpdateGroup()
        {
            InitializeComponent();
        }

        #region Методы

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            updateGroupViewModel.SaveTextBox();
            Init();
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsersInGroupObservableCollection.TextFind = FindUsers.Text;
            
            var usersInGroupObservableCollection = new UsersInGroupObservableCollection();
            UsersInGroupObservableCollection.Users = usersInGroupObservableCollection.FindUsersInGroup();

            UsersInSelectedGroup.ItemsSource = UsersInGroupObservableCollection.Users;

            AllUsersUpdateGroupObservableCollection.TextFind = FindUsers.Text;

            var allUsersUpdateGroupObservableCollection = new AllUsersUpdateGroupObservableCollection();
            AllUsersUpdateGroupObservableCollection.Users = allUsersUpdateGroupObservableCollection.FindUsersOutsideGroup();
            AllUsersUpdateGroupObservableCollection.Users = allUsersUpdateGroupObservableCollection.DeleteItemInCollection();

            UserGrid.ItemsSource = AllUsersUpdateGroupObservableCollection.Users;
        }

        #endregion

        #region Доп методы

        private void Init()
        {
            Number.Text = updateGroupViewModel.SelectedGroup.Number;
            Number.IsReadOnly = updateGroupViewModel.IsReadOnly;
            Number.Background = updateGroupViewModel.Background;

            Name.Text = updateGroupViewModel.SelectedGroup.FirstName;
            Name.IsReadOnly = updateGroupViewModel.IsReadOnly;
            Name.Background = updateGroupViewModel.Background;

            StartDate.Text = updateGroupViewModel.SelectedGroup.StartDate;
            StartDate.IsEnabled = updateGroupViewModel.IsReadOnlyDP;
            StartDate.Background = updateGroupViewModel.Background;

            EndDate.Text = updateGroupViewModel.SelectedGroup.EndDate;
            EndDate.IsEnabled = updateGroupViewModel.IsReadOnlyDP;
            EndDate.Background = updateGroupViewModel.Background;
        }

        #endregion

        
    }
}
