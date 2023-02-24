using Dapper;
using Microsoft.Data.SqlClient;
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

        #endregion

        public AllUsersUpdateGroupObservableCollection()
        {
            users = FillingGridUsers();
            users.CollectionChanged += ContentCollectionChanged;
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
        /// Вызывается при изменении колекции, но почему то не работает
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ContentCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is Users newUser)
                    {
                        MessageBox.Show($"Новый пользователь {newUser.FullName}", "Сообщение!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is Users oldUser)
                    {
                        MessageBox.Show($"Пользователь удален {oldUser.FullName}", "Сообщение!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    if ((e.NewItems?[0] is Users replacingUser) &&
                        (e.OldItems?[0] is Users replacedUser))
                        MessageBox.Show($"Объект {replacedUser.FullName} заменен объектом {replacingUser.FullName}", "Сообщение!", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }
    }
}
