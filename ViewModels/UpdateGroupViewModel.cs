using System.Windows.Input;
using System.Windows;
using WordAndSQL_Core.Infastructure.Commands;
using WordAndSQL_Core.Views.Windows;
using Microsoft.Data.SqlClient;
using Dapper;
using WordAndSQL_Core.Collection;
using WordAndSQL_Core.ViewModels.Base;

namespace WordAndSQL_Core.ViewModels
{
    class UpdateGroupViewModel : ViewModel
    {
        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Команды

        #region Команда открытия окна добавления

        public ICommand OpenImportApplicationCommand { get; }

        private bool CanImportApplicationCommandExecute(object p) => true;

        private void OnImportApplicationCommandExecuted(object p)
        {
            ImportUsers importUsers = new ImportUsers();
            importUsers.Owner = Application.Current.MainWindow;
            importUsers.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            importUsers.ShowDialog();
        }

        #endregion

        #endregion

        #region Методы

        #region Присваивание пользователю его группу

        /// <summary>
        /// Удаление из базы многие ко многим пользователя 
        /// </summary>
        private void DeleteUserFromUserGrid()
        {
            try
            {
                AllUsersUpdateGroupObservableCollection.Users.Remove(AllUsersUpdateGroupObservableCollection.SelectedUser);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Добавление в базу многие ко многим пользователя, присвоение пользователю группу
        /// </summary>
        private void InsertUserInUsersInSelectedGroup()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = $"INSERT Users_Groups VALUES ({AllUsersUpdateGroupObservableCollection.SelectedUser.id}, {GroupsObservableCollection.SelectedGroup.id})";

                    connection.Query(sql);
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// При даблклике на пользователя удаляется из одного DataGrid и добавляется в другой 
        /// </summary>
        public void UpdateUserGrid()
        {
            InsertUserInUsersInSelectedGroup();
            DeleteUserFromUserGrid();
        }

        #endregion

        #region Выгнать пользователя из группы

        private void DeleteUserFromUsersInSelectedGroup()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = $"DELETE Users_Groups WHERE idUser = {UsersInGroupObservableCollection.SelectedUser.id} and idGroup = {GroupsObservableCollection.SelectedGroup.id}";

                    connection.Query(sql);
                }

                UsersInGroupObservableCollection.Users.Remove(UsersInGroupObservableCollection.SelectedUser);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void InsertUserInUserGrid()
        {
            try
            {
                AllUsersUpdateGroupObservableCollection.Users.Add(UsersInGroupObservableCollection.SelectedUser);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void UpdateUsersInSelectedGroup()
        {
            InsertUserInUserGrid();
            DeleteUserFromUsersInSelectedGroup();
        }

        #endregion

        #endregion

        public UpdateGroupViewModel()
        {
            #region Команды

            OpenImportApplicationCommand = new LambdaCommand(OnImportApplicationCommandExecuted, CanImportApplicationCommandExecute);

            #endregion
        }
    }
}
