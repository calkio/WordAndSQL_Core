using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WordAndSQL_Core.ViewModels.Base;
using WordAndSQL_Core.Infastructure.Commands;

namespace WordAndSQL_Core.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "123";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #region Команды

        #region Команда закрыть окно

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion

        }
    }
}
