using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WordAndSQL_Core.Infastructure.Commands;
using WordAndSQL_Core.Views.Windows;

namespace WordAndSQL_Core.ViewModels
{
    class UpdateGroupViewModel
    {
        #region Команды

        #region Команда открытия окна добавления

        public ICommand OpenImportApplicationCommand { get; }

        private bool CanImportApplicationCommandExecute(object p) => true;

        private void OnImportApplicationCommandExecuted(object p)
        {
            ImportUsers importUsers = new ImportUsers();
            importUsers.Owner = Application.Current.MainWindow;
            importUsers.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            importUsers.ShowDialog();
        }

        #endregion

        #endregion


        public UpdateGroupViewModel()
        {
            #region Команды

            OpenImportApplicationCommand = new LambdaCommand(OnImportApplicationCommandExecuted, CanImportApplicationCommandExecute);

            #endregion

        }
    }
}
