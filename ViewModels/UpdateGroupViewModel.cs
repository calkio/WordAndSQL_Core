using System.Windows.Input;
using System.Windows;
using WordAndSQL_Core.Infastructure.Commands;
using WordAndSQL_Core.Views.Windows;
using Microsoft.Data.SqlClient;
using Dapper;
using WordAndSQL_Core.Collection;
using WordAndSQL_Core.ViewModels.Base;
using System.Windows.Media;
using WordAndSQL_Core.Entity;
using System.Collections.ObjectModel;
using System.Linq;
using Google.Protobuf.WellKnownTypes;

namespace WordAndSQL_Core.ViewModels
{
    class UpdateGroupViewModel : ViewModel
    {
        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Свойства

        public Groups SelectedGroup { get; set; }

        #region ReadOnly для полей

        private bool _isReadOnly = true;

        public bool IsReadOnly { get => _isReadOnly; set => Set(ref _isReadOnly, value); }


        /// <summary>
        /// DatePicker
        /// </summary>
        private bool _isReadOnlyDP = false;

        public bool IsReadOnlyDP { get => _isReadOnlyDP; set => Set(ref _isReadOnlyDP, value); }

        #endregion

        #region Фон для TextBox

        private Brush _background = new SolidColorBrush(Colors.LightGray);

        public Brush Background { get => _background; set => Set(ref _background, value); }

        #endregion

        #endregion

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

        #region Взаимодействие с полями

        public void SaveTextBox()
        {
            if (_isReadOnly)
            {
                _isReadOnly = false;
                _isReadOnlyDP = true;
                _background = new SolidColorBrush(Colors.White);
            }
            else
            {
                try
                {
                    using (var connection = new SqlConnection(sqlConnection))
                    {
                        var sql = $"UPDATE Groups SET Number='{SelectedGroup.Number}' ,FirstName='{SelectedGroup.FirstName}', StartDate='{SelectedGroup.StartDate}', EndDate='{SelectedGroup.EndDate}' WHERE id={SelectedGroup.id}";

                        var group = connection.Query(sql);

                        MessageBox.Show("Сохранения изменины!", "Сообщение!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    _isReadOnly = true;
                    _isReadOnlyDP = false;
                    _background = new SolidColorBrush(Colors.LightGray);
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        #endregion

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

            SelectedGroup = GroupsObservableCollection.SelectedGroup;
        }
    }
}
