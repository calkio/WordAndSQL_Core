using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
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
            using (var connection = new SqlConnection(sqlConnection))
            {
                var sql = @"SELECT * FROM Users WHERE id=2";

                var user = connection.QuerySingle<Users>(sql);

                return user;
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
            using (var connection = new SqlConnection(sqlConnection))
            {
                var sql = @"SELECT * FROM Users WHERE id=2";

                var users = connection.Query<Users>(sql).ToList();

                return users;
            }
        }

        #endregion

        #region Сохранение данных из textBox

        /// <summary>
        /// Сохраняет данные из textBox
        /// </summary>
        public void SaveTextBox()
        {
            using (var connection = new SqlConnection(sqlConnection))
            {
                UserPassport str = new UserPassport();

                var sql = @"UPDATE Users SET 
                            SecondName='Катя',
                            FirstName='петя',
                            Surname='Катя', 
                            Numder='Катя',
                            BirthDate='21.01.2003', 
                            Telephone='Катя', 
                            Login='Катя', 
                            Snils='Катя', 
                            Citizenship='Катя', 
                            Gender='Катя'
                            WHERE id=2";

                var users = connection.Query(sql);
            }
        }

        /// <summary>
        /// Сохраняются заметки
        /// </summary>
        public void SaveNotes()
        {
            using (var connection = new SqlConnection(sqlConnection))
            {
                var sql = @"UPDATE Users SET 
                            PlaceWork='Катя', 
                            Post='Катя', 
                            Education='Катя', 
                            Comment='Катя'
                            WHERE id=2";

                var users = connection.Query(sql);
            }
        }

        #endregion
    }
}
