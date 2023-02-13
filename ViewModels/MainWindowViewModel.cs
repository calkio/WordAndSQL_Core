﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WordAndSQL_Core.ViewModels.Base;
using WordAndSQL_Core.Infastructure.Commands;
using WordAndSQL_Core.Views.Windows;
using Microsoft.Data.SqlClient;
using WordAndSQL_Core.Entity;
using Dapper;
using MySql.Data.MySqlClient;
using WordAndSQL_Core.Infastructure.Commands.Base;

namespace WordAndSQL_Core.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Колекции

        #region Колекция пользователей

        private System.Collections.IEnumerable user;

        public System.Collections.IEnumerable User
        {
            get => GetDataUsers();
            set => Set(ref user, value);
        }

        #endregion

        #region Колекция групп

        private System.Collections.IEnumerable group;

        public System.Collections.IEnumerable Group
        {
            get => GetDataGroups();
            set => Set(ref group, value);
        }

        #endregion

        #endregion

        #region Текст для окна удаления

        static public string textDelete { get; set; }

        #endregion

        #region Команды

        #region Команда открытия окна добавления

        public ICommand CreateApplicationCommand { get; }

        private bool CanCreateApplicationCommandExecute(object p) => true;

        private void OnCreateApplicationCommandExecuted(object p)
        {
            CreateGroup createGroup = new CreateGroup();
            createGroup.Owner = Application.Current.MainWindow;
            createGroup.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            createGroup.ShowDialog();
        }

        #endregion

        #region Команда открытия окна изменения

        public ICommand UpdateApplicationCommand { get; }

        private bool CanUpdateApplicationCommandExecute(object p) => true;

        private void OnUpdateApplicationCommandExecuted(object p)
        {
            UpdateGroup UpdateGroup = new UpdateGroup();
            UpdateGroup.Owner = Application.Current.MainWindow;
            UpdateGroup.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            UpdateGroup.ShowDialog();
        }

        #endregion

        #region Команда открытия окна карточки

        public ICommand UserPassportApplicationCommand { get; }

        private bool CanUserPassportApplicationCommandExecute(object p) => true;

        private void OnUserPassportApplicationCommandExecuted(object p)
        {
            UserPassport userPassport = new UserPassport();
            userPassport.Owner = Application.Current.MainWindow;
            userPassport.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            userPassport.ShowDialog();
        }

        #endregion

        #region Команда открытия окна удаления группы

        public ICommand DeleteGroupApplicationCommand { get; }

        private bool CanDeleteGroupApplicationCommandExecute(object p) => true;

        private void OnDeleteGroupApplicationCommandExecuted(object p)
        {
            textDelete = "Вы действительно хотите удалить выбранную группу?";
            Delete delete = new Delete();
            delete.Owner = Application.Current.MainWindow;
            delete.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            delete.ShowDialog();
        }

        #endregion

        #region Команда открытия окна удаления пользователя

        public ICommand DeleteUserApplicationCommand { get; }

        private bool CanDeleteUserApplicationCommandExecute(object p) => true;

        private void OnDeleteUserApplicationCommandExecuted(object p)
        {
            textDelete = "Вы действительно хотите удалить выбранного человека?";
            Delete delete = new Delete();
            delete.Owner = Application.Current.MainWindow;
            delete.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            delete.ShowDialog();
        }

        #endregion

        #endregion

        #region Методы 

        /// <summary>
        /// Заполняет таблицу всеми users
        /// </summary>
        /// <returns></returns>
        public List<Users> GetDataUsers()
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

        /// <summary>
        /// Заполняет таблицу всеми группами
        /// </summary>
        /// <returns></returns>
        public List<Users> GetDataGroups()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnection))
                {
                    var sql = @"SELECT * FROM Groups";

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


        public MainWindowViewModel()
        {
            #region Команды

            CreateApplicationCommand = new LambdaCommand(OnCreateApplicationCommandExecuted, CanCreateApplicationCommandExecute);
            UpdateApplicationCommand = new LambdaCommand(OnUpdateApplicationCommandExecuted, CanUpdateApplicationCommandExecute);
            UserPassportApplicationCommand = new LambdaCommand(OnUserPassportApplicationCommandExecuted, CanUserPassportApplicationCommandExecute);
            DeleteGroupApplicationCommand = new LambdaCommand(OnDeleteGroupApplicationCommandExecuted, CanDeleteGroupApplicationCommandExecute);
            DeleteUserApplicationCommand = new LambdaCommand(OnDeleteUserApplicationCommandExecuted, CanDeleteUserApplicationCommandExecute);

            #endregion
        }

    }
}
