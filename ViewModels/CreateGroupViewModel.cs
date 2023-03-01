using Dapper;
using Microsoft.Data.SqlClient;
using Org.BouncyCastle.Tls;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls.Primitives;
using WordAndSQL_Core.Collection;
using WordAndSQL_Core.Entity;
using WordAndSQL_Core.Views.Windows;
using static Mysqlx.Crud.Order.Types;


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
                    bool isAddGgroup = IsAddGroup(NumberTB);

                    if (!isAddGgroup) 
                    {
                        MessageBox.Show("Уже существует группа с таким номером!", "Сообщение!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    
                    var sql = $"insert into Groups (FirstName, Number, StartDate, EndDate, Vid, Direction) values ('{FirstNameTB}', '{NumberTB}', '{StartDateDP}', '{EndDateDP}', '{VidCB}', '{DirectionCB}')";
                    var command = connection.Query(sql);

                    sql = $"SELECT * FROM Groups WHERE FirstName = '{FirstNameTB}' and Number = '{NumberTB}' and StartDate = '{StartDateDP}' and EndDate = '{EndDateDP}' and Vid = '{VidCB}' and Direction = '{DirectionCB}'";

                    var groups = connection.Query<Groups>(sql).ToList();

                    foreach (var group in groups)
                    {
                        GroupsObservableCollection.Groups.Add(group);
                    }

                    MessageBox.Show("Вы создали новую группу!", "Сообщение!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool IsAddGroup(string NumberTB)
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = $"SELECT COUNT (*) FROM Groups WHERE Number = '{NumberTB}'";
                    var command = connection.ExecuteScalar<bool>(sql);// проверяет есть ли группы с таким номером: если есть false

                    return !command;//меняю значение для корекности 
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);

                return false;
            }
        }

        #endregion
    }
}
