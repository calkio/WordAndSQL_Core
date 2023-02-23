using System.Windows;
using WordAndSQL_Core.Collection;
using WordAndSQL_Core.Entity;
using WordAndSQL_Core.ViewModels;

namespace WordAndSQL_Core.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserPassport.xaml
    /// </summary>
    public partial class UserPassport : Window
    {
        UserPassportViewModel userPassportViewModel = new UserPassportViewModel();

        public UserPassport()
        {
            InitializeComponent();
        }

        #region Методы окна

        /// <summary>
        /// При нажатии на кнопку "Сохранить" сохраняются данные из textBox в базу данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userPassportViewModel.SaveTextBox();
        }

        /// <summary>
        /// Сохраняются заметки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            userPassportViewModel.SaveNotes();
        }

        #endregion

    }
}
