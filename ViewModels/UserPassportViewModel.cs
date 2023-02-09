using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using WordAndSQL_Core.Entity;
using WordAndSQL_Core.Views.Windows;

namespace WordAndSQL_Core.ViewModels
{
    class UserPassportViewModel
    {
        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Данныe о пользователи

        /// <summary>
        /// Дает данные для таблицы
        /// </summary>
        /// <returns></returns>
        public Users GetDataUsers()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = @"SELECT * FROM Users WHERE id=2";

                    var user = connection.QuerySingle<Users>(sql);

                    return user;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);

                return new Users();
            }
            
        }

        #endregion

        #region Данныe для таблицы

        /// <summary>
        /// Дает данные для таблицы
        /// </summary>
        /// <returns></returns>
        public List<Users> GetDataGroup()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = @"SELECT * FROM Users";

                    var users = connection.Query<Users>(sql).ToList();

                    return users;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);

                return new List<Users>();
            }
        }

        #endregion

        #region Сохранение данных из textBox

        /// <summary>
        /// Сохраняет данные из textBox
        /// </summary>
        public void SaveTextBox(string SecondName, string FirstName, string Surname, string Numder, string BirthDate, string Telephone, string Login, string Snils, string Citizenship, string Gender)
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = $"UPDATE Users SET SecondName='{SecondName}', FirstName='{FirstName}', Surname='{Surname}', Numder='{Numder}', BirthDate='{BirthDate}', Telephone='{Telephone}', Login='{Login}', Snils='{Snils}', Citizenship='{Citizenship}', Gender='{Gender}' WHERE id=2";

                    var users = connection.Query(sql);
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Сохраняются заметки
        /// </summary>
        public void SaveNotes(string PlaceWork, string Post, string Education, string Comment)
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = $"UPDATE Users SET PlaceWork='{PlaceWork}', Post='{Post}', Education='{Education}', Comment='{Comment}' WHERE id=2";

                    var users = connection.Query(sql);
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion
    }
}
