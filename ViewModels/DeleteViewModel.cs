using WordAndSQL_Core.ViewModels.Base;

namespace WordAndSQL_Core.ViewModels
{
    internal class DeleteViewModel : ViewModel
    {
        #region Что будет написанно в окне удаления

        private string _text = MainWindowViewModel.textDelete;

        public string text
        {
            get => _text;
            set => Set(ref _text, value);
        }

        #endregion

        #region Команды

        #endregion
    }
}
