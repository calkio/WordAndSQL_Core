using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WordAndSQL_Core.Collection;
using WordAndSQL_Core.ViewModels.Base;

namespace WordAndSQL_Core.ViewModels
{
    internal class DeleteUserViewModel : ViewModel
    {
        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Методы

        public void DeleteSelectedUser()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = $"DELETE FROM Users WHERE id={UsersObservableCollection.SelectedUser.id}";
                    connection.Query(sql);

                    sql = $"DELETE FROM Users_Groups WHERE idUser={UsersObservableCollection.SelectedUser.id}";
                    connection.Query(sql);

                    UsersObservableCollection.Users.Remove(UsersObservableCollection.SelectedUser);
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
