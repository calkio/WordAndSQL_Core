using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WordAndSQL_Core.Collection;
using WordAndSQL_Core.Entity;
using WordAndSQL_Core.ViewModels.Base;
using WordAndSQL_Core.Views.Windows;

namespace WordAndSQL_Core.ViewModels
{
    class UserPassportViewModel : ViewModel
    {
        string sqlConnection = "Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Свойства

        public Users SelectedUser { get; set; }

        #region ReadOnly для полей

        /// <summary>
        /// Шапка
        /// </summary>
        private bool _isReadOnly = true;

        public bool IsReadOnly { get => _isReadOnly; set => Set(ref _isReadOnly, value); }


        /// <summary>
        /// DatePicker
        /// </summary>
        private bool _isReadOnlyDP = false;

        public bool IsReadOnlyDP { get => _isReadOnlyDP; set => Set(ref _isReadOnlyDP, value); }

        /// <summary>
        /// 4 нижних поля
        /// </summary>
        private bool _isReadOnlyMain = true;

        public bool IsReadOnlyMain { get => _isReadOnlyMain; set => Set(ref _isReadOnlyMain, value); }


        #endregion

        #region Текст 

        /// <summary>
        /// Для маленькой кнопки
        /// </summary>
        private string _textButton = "Редактировать";

        public string TextButton { get => _textButton; set => Set(ref _textButton, value); }

        /// <summary>
        /// Для большой кнопки
        /// </summary>
        private string _textButtonMain = "Редактировать";

        public string TextButtonMain { get => _textButtonMain; set => Set(ref _textButtonMain, value); }

        #endregion

        #region Фон для TextBox

        /// <summary>
        /// Для верхних полей
        /// </summary>
        private Brush _background = new SolidColorBrush(Colors.LightGray);

        public Brush Background { get => _background; set => Set(ref _background, value); }


        /// <summary>
        /// Для нижних полей
        /// </summary>
        private Brush _backgroundMain = new SolidColorBrush(Colors.LightGray);

        public Brush BackgroundMain { get => _backgroundMain; set => Set(ref _backgroundMain, value); }

        #endregion

        #endregion

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
            if (_isReadOnly)
            {
                _isReadOnly = false;
                _isReadOnlyDP = true;
                _textButton = "Сохранить";
                _background = new SolidColorBrush(Colors.White);
            }
            else
            {
                try
                {
                    using (var connection = new SqlConnection(sqlConnection))
                    {
                        var sql = $"UPDATE Users SET SecondName='{SelectedUser.SecondName}', FirstName='{SelectedUser.FirstName}', Surname='{SelectedUser.Surname}', Numder='{SelectedUser.Numder}', BirthDate='{SelectedUser.BirthDate}', Telephone='{SelectedUser.Telephone}', Login='{SelectedUser.Login}', Snils='{SelectedUser.Snils}', Citizenship='{SelectedUser.Citizenship}', Gender='{SelectedUser.Gender}' WHERE id={SelectedUser.id}";

                        var users = connection.Query(sql);

                        MessageBox.Show("Сохранения изменины!", "Сообщение!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    _isReadOnly = true;
                    _isReadOnlyDP = false;
                    _textButton = "Редактировать";
                    _background = new SolidColorBrush(Colors.LightGray);
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        /// <summary>
        /// Сохраняются заметки
        /// </summary>
        public void SaveNotes()
        {
            if (_isReadOnly)
            {
                _isReadOnly = false;
                _isReadOnlyDP = true;
                _textButton = "Сохранить";
                _background = new SolidColorBrush(Colors.White);

                _isReadOnlyMain = false;
                _textButtonMain = "Сохранить";
                _backgroundMain = new SolidColorBrush(Colors.White);
            }
            else
            {
                try
                {
                    using (var connection = new SqlConnection(sqlConnection))
                    {
                        var sql = $"UPDATE Users SET SecondName='{SelectedUser.SecondName}', FirstName='{SelectedUser.FirstName}', Surname='{SelectedUser.Surname}', Numder='{SelectedUser.Numder}', BirthDate='{SelectedUser.BirthDate}', Telephone='{SelectedUser.Telephone}', Login='{SelectedUser.Login}', Snils='{SelectedUser.Snils}', Citizenship='{SelectedUser.Citizenship}', Gender='{SelectedUser.Gender}', PlaceWork='{SelectedUser.PlaceWork}', Post='{SelectedUser.Post}', Education='{SelectedUser.Education}', Comment='{SelectedUser.Comment}' WHERE id={SelectedUser.id}";

                        var users = connection.Query(sql);

                        MessageBox.Show("Сохранения изменины!", "Сообщение!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    _isReadOnly = true;
                    _isReadOnlyDP = false;
                    _textButton = "Редактировать";
                    _background = new SolidColorBrush(Colors.LightGray);

                    _isReadOnlyMain = false;
                    _textButtonMain = "Редактировать";
                    _backgroundMain = new SolidColorBrush(Colors.White);
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        #endregion
    }
}
