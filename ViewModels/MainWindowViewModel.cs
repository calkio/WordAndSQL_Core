using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAndSQL_Core.ViewModels.Base;

namespace WordAndSQL_Core.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Статистика";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
    }
}
