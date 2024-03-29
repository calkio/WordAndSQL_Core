﻿using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using WordAndSQL_Core.Entity;

namespace WordAndSQL_Core.Collection
{
    internal class GroupsObservableCollection : ObservableCollection<Groups>
    {
        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Свойства

        #region Свойство для колекции групп

        static private ObservableCollection<Groups> groups = new ObservableCollection<Groups>();

        static public ObservableCollection<Groups> Groups
        {
            get => groups;
            set => groups = value;
        }

        #endregion

        #region Свойство для выделенной группы

        static private Groups _selectedGroup { get; set; }

        static public Groups SelectedGroup
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

        public GroupsObservableCollection()
        {
            groups = FillingGridGroups();
        }

        /// <summary>
        /// Заполняет колекцию групп, обращаясь к базе
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<Groups> FillingGridGroups()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = @"SELECT * FROM Groups";

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
