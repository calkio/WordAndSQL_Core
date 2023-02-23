using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using WordAndSQL_Core.Collection;
using WordAndSQL_Core.Entity;
using WordAndSQL_Core.ViewModels.Base;
using WordAndSQL_Core.Views.Windows;

namespace WordAndSQL_Core.ViewModels
{
    class UserPassportViewModel : ViewModel
    {
        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public Users SelectedUser { get; set; }

        public UserPassportViewModel()
        {
            SelectedUser = UsersObservableCollection.SelectedUser;
        }

        #region Сохранение данных из textBox

        /// <summary>
        /// Сохраняет данные из textBox
        /// </summary>
        public void SaveTextBox()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = $"UPDATE Users SET SecondName='{SelectedUser.SecondName}', FirstName='{SelectedUser.FirstName}', Surname='{SelectedUser.Surname}', Numder='{SelectedUser.Numder}', BirthDate='{SelectedUser.BirthDate}', Telephone='{SelectedUser.Telephone}', Login='{SelectedUser.Login}', Snils='{SelectedUser.Snils}', Citizenship='{SelectedUser.Citizenship}', Gender='{SelectedUser.Gender}' WHERE id={SelectedUser.id}";

                    var users = connection.Query(sql);

                    UsersObservableCollection usersObservableCollection = new UsersObservableCollection();

                    MessageBox.Show("Сохранения изменины!", "Сообщение!", MessageBoxButton.OK, MessageBoxImage.Information);
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
        public void SaveNotes()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = $"UPDATE Users SET SecondName='{SelectedUser.SecondName}', FirstName='{SelectedUser.FirstName}', Surname='{SelectedUser.Surname}', Numder='{SelectedUser.Numder}', BirthDate='{SelectedUser.BirthDate}', Telephone='{SelectedUser.Telephone}', Login='{SelectedUser.Login}', Snils='{SelectedUser.Snils}', Citizenship='{SelectedUser.Citizenship}', Gender='{SelectedUser.Gender}', PlaceWork='{SelectedUser.PlaceWork}', Post='{SelectedUser.Post}', Education='{SelectedUser.Education}', Comment='{SelectedUser.Comment}' WHERE id={SelectedUser.id}";

                    var users = connection.Query(sql);

                    UsersObservableCollection usersObservableCollection = new UsersObservableCollection();

                    MessageBox.Show("Сохранения изменины!", "Сообщение!", MessageBoxButton.OK, MessageBoxImage.Information);
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
