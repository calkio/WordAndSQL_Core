using Dapper;
using Microsoft.Data.SqlClient;
using Org.BouncyCastle.Tls;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using WordAndSQL_Core.Entity;
using WordAndSQL_Core.Views.Windows;


namespace WordAndSQL_Core.ViewModels
{
    class CreateGroupViewModel
    {
        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Команда

        public void CreateGroup(string VidCB, string DirectionCB, string FirstNameTB, string NumberTB, string StartDateDP, string EndDateDP)
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = $"insert into Groups (FirstName, Number, StartDate, EndDate, Vid, Direction) values ('{FirstNameTB}', '{NumberTB}', '{StartDateDP}', '{EndDateDP}', '{VidCB}', '{DirectionCB}')";

                    var command = connection.Query(sql);

                    MessageBox.Show("Вы создали новую группу!", "Сообщение!", MessageBoxButton.OK, MessageBoxImage.Information);
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
