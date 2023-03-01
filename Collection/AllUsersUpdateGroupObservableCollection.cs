using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using WordAndSQL_Core.Entity;

namespace WordAndSQL_Core.Collection
{
    class AllUsersUpdateGroupObservableCollection : ObservableCollection<Users>
    {
        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Свойства

        #region Свойство для колекции пользователей

        static private ObservableCollection<Users> users = new ObservableCollection<Users>();

        static public ObservableCollection<Users> Users
        {
            get => users;
            set => users = value;
        }

        #endregion

        #region Свойство для выделенного пользователя

        static private Users _selectedUser { get; set; } 

        static public Users SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                }
            }
        }

        #endregion

        #region Текст в текстбоксе, по которому идет поиск 

        static private string _textFind;

        static public string TextFind { get => _textFind; set => _textFind = value; }

        #endregion

        #endregion

        public AllUsersUpdateGroupObservableCollection()
        {
            users = FillingGridUsers();
            users = DeleteItemInCollection();
        }

        /// <summary>
        /// Заполняет колекцию пользователей, обращаясь к базе
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Users> FillingGridUsers()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = @"SELECT * FROM Users";

                    var usersList = connection.Query<Users>(sql).ToList();

                    var users = new ObservableCollection<Users>();
                    foreach (var user in usersList)
                    {
                        users.Add(user);
                    }

                    return users;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);

                return new ObservableCollection<Users>();
            }
        }

        /// <summary>
        /// Удаление айтемов из колекции, которые уже есть в другой таблице
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Users> DeleteItemInCollection()
        {
            var usersCollection = new ObservableCollection<Users>();
            bool isAdd = true;

            foreach (var item1 in users)
            {
                isAdd = true;
                foreach (var item2 in UsersInGroupObservableCollection.Users)
                {
                    if (item1.id == item2.id) isAdd = false;
                }
                if (isAdd) usersCollection.Add(item1);
            }

            return usersCollection;
        }

        /// <summary>
        /// Поиск пользователей по тексту в textBox
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Users> FindUsersOutsideGroup()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    if (_textFind == null || _textFind == "") return FillingGridUsers();

                    var sql = $"SELECT * FROM Users WHERE FirstName LIKE '%{_textFind}%' or SecondName LIKE '%{_textFind}%' or Surname LIKE '%{_textFind}%'";

                    var users = connection.Query<Users>(sql).ToList();

                    var usersOC = new ObservableCollection<Users>();
                    foreach (var item in users)
                    {
                        usersOC.Add(item);
                    }

                    return usersOC;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);

                return new ObservableCollection<Users>();
            }
        }
    }
}
