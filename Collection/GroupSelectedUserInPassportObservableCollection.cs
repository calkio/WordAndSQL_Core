using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WordAndSQL_Core.Entity;

namespace WordAndSQL_Core.Collection
{
    internal class GroupSelectedUserInPassportObservableCollection : ObservableCollection<Groups>
    {
        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Свойства

        #region Свойства листа с id групп, которые входят в выброного пользователя

        List<int> listId { get; set; }

        #endregion

        #region Свойство для колекции пользователей

        static private ObservableCollection<Groups> groups = new ObservableCollection<Groups>();

        static public ObservableCollection<Groups> Groups
        {
            get => groups;
            set => groups = value;
        }

        #endregion

        #region Свойство для выделенной группы

        static private Users _selectedGroup { get; set; }

        static public Users SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                if (_selectedGroup != value)
                {
                    _selectedGroup = value;
                }
            }
        }

        #endregion

        #endregion

        public GroupSelectedUserInPassportObservableCollection()
        {
            listId = GetIdUsersInGroup();
            groups = FillingGridGroups();
        }

        /// <summary>
        /// Дает лист ID групп в которых состоит пользователь
        /// </summary>
        /// <returns></returns>
        private List<int> GetIdUsersInGroup()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    if (UsersObservableCollection.SelectedUser == null) return null;

                    var sql = $"SELECT idGroup FROM Users_Groups WHERE idUser={UsersObservableCollection.SelectedUser.id}";//Дает лист ID групп в которых состоит пользователь

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
        public ObservableCollection<Groups> FillingGridGroups()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    if (listId == null || listId.Count == 0) return new ObservableCollection<Groups>();

                    var inList = "(" + string.Join(", ", listId.Select(t => t)) + ")";

                    var sql = $"SELECT * FROM Groups WHERE id IN{inList}";

                    var groupsList = connection.Query<Groups>(sql).ToList();


                    var groups = new ObservableCollection<Groups>();
                    foreach (var group in groupsList)
                    {
                        groups.Add(group);
                    }

                    return groups;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);

                return new ObservableCollection<Groups>();
            }
        }
    }
}
