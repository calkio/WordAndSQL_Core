using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WordAndSQL_Core.ViewModels.Base;
using WordAndSQL_Core.Infastructure.Commands;
using WordAndSQL_Core.Views.Windows;

namespace WordAndSQL_Core.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

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

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CreateApplicationCommand = new LambdaCommand(OnCreateApplicationCommandExecuted, CanCreateApplicationCommandExecute);
            UpdateApplicationCommand = new LambdaCommand(OnUpdateApplicationCommandExecuted, CanUpdateApplicationCommandExecute);
            UpdateApplicationCommand = new LambdaCommand(OnUserPassportApplicationCommandExecuted, CanUserPassportApplicationCommandExecute);

            #endregion

        }
    }
}
