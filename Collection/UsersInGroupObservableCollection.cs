using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WordAndSQL_Core.Entity;

namespace WordAndSQL_Core.Collection
{
    class UsersInGroupObservableCollection : ObservableCollection<Users>
    {
        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Свойства

        #region Свойства листа с id пользователей, которые входят в выбранную группу

        List<int> listId { get; set; }

        #endregion

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

        public UsersInGroupObservableCollection()
        {
            listId = GetIdUsersInGroup();
            users = FillingGridUsers();
        }

        private List<int> GetIdUsersInGroup()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    if (GroupsObservableCollection.SelectedGroup == null) return null;
                    
                    var sql = $"SELECT idUser FROM Users_Groups WHERE idGroup={GroupsObservableCollection.SelectedGroup.id}";//Дает лист ID пользователей которые состоят в группе

                    var users = connection.Query<int>(sql).ToList();

                    return users;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);

                return new List<int>();
            }
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
                    if (listId == null || listId.Count == 0) return new ObservableCollection<Users>();

                    var inList = "(" + string.Join(", ", listId.Select(t => t)) + ")";

                    var sql = $"SELECT * FROM Users WHERE id IN{inList}";

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
        /// Поиск пользователей по тексту в textBox
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Users> FindUsersInGroup()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    if (listId == null || listId.Count == 0) return new ObservableCollection<Users>();
                    if (_textFind == null || _textFind == "") return FillingGridUsers();

                    var inList = "(" + string.Join(", ", listId.Select(t => t)) + ")";

                    var sql = $"SELECT * FROM Users WHERE (FirstName LIKE '%{_textFind}%' or SecondName LIKE '%{_textFind}%' or Surname LIKE '%{_textFind}%') and id IN{inList}";

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
