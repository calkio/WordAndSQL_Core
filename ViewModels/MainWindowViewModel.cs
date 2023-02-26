using System.Windows.Input;
using System.Windows;
using WordAndSQL_Core.ViewModels.Base;
using WordAndSQL_Core.Infastructure.Commands;
using WordAndSQL_Core.Views.Windows;
using Microsoft.Data.SqlClient;
using Dapper;
using WordAndSQL_Core.Collection;
using System.Linq;
using WordAndSQL_Core.Entity;
using System.Collections.ObjectModel;

namespace WordAndSQL_Core.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Свойства

        #region Текст в текстбоксе, по которому идет поиск группы

        static private string _textFindGroup;

        static public string TextFindGroup { get => _textFindGroup; set => _textFindGroup = value; }

        #endregion

        #region Текст в текстбоксе, по которому идет поиск пользователя

        static private string _textFindUser;

        static public string TextFindUser { get => _textFindUser; set => _textFindUser = value; }

        #endregion

        #endregion

        #region Команды

        #region Команда открытия окна добавления

        public ICommand CreateApplicationCommand { get; }

        private bool CanCreateApplicationCommandExecute(object p) => true;

        private void OnCreateApplicationCommandExecuted(object p)
        {
            CreateGroup createGroup = new CreateGroup();
            createGroup.Owner = Application.Current.MainWindow;
            createGroup.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            createGroup.ShowDialog();
        }

        #endregion

        #region Команда открытия окна изменения

        public ICommand UpdateApplicationCommand { get; }

        private bool CanUpdateApplicationCommandExecute(object p) => true;

        private void OnUpdateApplicationCommandExecuted(object p)
        {
            UpdateGroup UpdateGroup = new UpdateGroup();
            UpdateGroup.Owner = Application.Current.MainWindow;
            UpdateGroup.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            UpdateGroup.ShowDialog();
        }

        #endregion

        #region Команда открытия окна карточки

        public ICommand UserPassportApplicationCommand { get; }

        private bool CanUserPassportApplicationCommandExecute(object p) => true;

        private void OnUserPassportApplicationCommandExecuted(object p)
        {
            UserPassport userPassport = new UserPassport();
            userPassport.Owner = Application.Current.MainWindow;
            userPassport.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            userPassport.ShowDialog();
        }

        #endregion

        #region Команда открытия окна удаления группы

        public ICommand DeleteGroupApplicationCommand { get; }

        private bool CanDeleteGroupApplicationCommandExecute(object p) => true;

        private void OnDeleteGroupApplicationCommandExecuted(object p)
        {
            DeleteGroup delete = new DeleteGroup();
            delete.Owner = Application.Current.MainWindow;
            delete.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            delete.ShowDialog();
        }

        #endregion

        #region Команда открытия окна удаления пользователя

        public ICommand DeleteUserApplicationCommand { get; }

        private bool CanDeleteUserApplicationCommandExecute(object p) => true;

        private void OnDeleteUserApplicationCommandExecuted(object p)
        {
            DeleteUser delete = new DeleteUser();
            delete.Owner = Application.Current.MainWindow;
            delete.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            delete.ShowDialog();
        }

        #endregion

        #endregion

        #region Методы

        #region Поиск группы

        /// <summary>
        /// Поиск группы по нажатию на лупу и при вводе текста
        /// </summary>
        public void FindGroup()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = $"SELECT * FROM Groups WHERE FirstName LIKE '%{_textFindGroup}%'";

                    var groups = connection.Query<Groups>(sql).ToList();

                    var groupsOC = new ObservableCollection<Groups>();
                    foreach (var item in groups)
                    {
                        groupsOC.Add(item);
                    }

                    GroupsObservableCollection.Groups = groupsOC;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region Поиск пользователя

        /// <summary>
        /// Поиск пользователя по нажатию на лупу и при вводе текста
        /// </summary>
        public void FindUser()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    string sql;

                    //если пустое поле, то будет выводиться и пользователи без ФИО
                    if (_textFindUser != "") sql = $"SELECT * FROM Users WHERE FirstName LIKE '%{_textFindUser}%' or SecondName LIKE '%{_textFindUser}%' or Surname LIKE '%{_textFindUser}%'";
                    else sql = $"SELECT * FROM Users";

                    var users = connection.Query<Users>(sql).ToList();

                    var usersOC = new ObservableCollection<Users>();
                    foreach (var item in users)
                    {
                        usersOC.Add(item);
                    }

                    UsersObservableCollection.Users = usersOC;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CreateApplicationCommand = new LambdaCommand(OnCreateApplicationCommandExecuted, CanCreateApplicationCommandExecute);
            UpdateApplicationCommand = new LambdaCommand(OnUpdateApplicationCommandExecuted, CanUpdateApplicationCommandExecute);
            UserPassportApplicationCommand = new LambdaCommand(OnUserPassportApplicationCommandExecuted, CanUserPassportApplicationCommandExecute);
            DeleteGroupApplicationCommand = new LambdaCommand(OnDeleteGroupApplicationCommandExecuted, CanDeleteGroupApplicationCommandExecute);
            DeleteUserApplicationCommand = new LambdaCommand(OnDeleteUserApplicationCommandExecuted, CanDeleteUserApplicationCommandExecute);

            #endregion

            UsersObservableCollection usersObservableCollection = new UsersObservableCollection();//вызывается экземпляр, чтобы обновить колекцию
            GroupsObservableCollection groupsObservableCollection = new GroupsObservableCollection();//вызывается экземпляр, чтобы обновить колекцию
        }
    }
}
