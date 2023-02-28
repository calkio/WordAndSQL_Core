using System.Windows;
using System.Windows.Controls;
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
            Init();
        }

        /// <summary>
        /// Сохраняются заметки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            userPassportViewModel.SaveNotes();
            InitMain();
        }

        #endregion

        #region Доп методы

        private void Init()
        {
            textButtonTB.Text = userPassportViewModel.TextButton;

            SecondNameTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            SecondNameTB.Background = userPassportViewModel.Background;

            BirthDateTB.IsEnabled = userPassportViewModel.IsReadOnlyDP;
            BirthDateTB.Background = userPassportViewModel.Background;

            SnilsTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            SnilsTB.Background = userPassportViewModel.Background;

            FirstNameTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            FirstNameTB.Background = userPassportViewModel.Background;

            PhoneTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            PhoneTB.Background = userPassportViewModel.Background;

            CitizenshipTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            CitizenshipTB.Background = userPassportViewModel.Background;

            SurnameTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            SurnameTB.Background = userPassportViewModel.Background;

            LoginTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            LoginTB.Background = userPassportViewModel.Background;

            GenderTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            GenderTB.Background = userPassportViewModel.Background;

            NumberTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            NumberTB.Background = userPassportViewModel.Background;
        }

        private void InitMain()
        {
            textButtonTB.Text = userPassportViewModel.TextButton;

            SecondNameTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            SecondNameTB.Background = userPassportViewModel.Background;

            BirthDateTB.IsEnabled = userPassportViewModel.IsReadOnlyDP;
            BirthDateTB.Background = userPassportViewModel.Background;

            SnilsTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            SnilsTB.Background = userPassportViewModel.Background;

            FirstNameTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            FirstNameTB.Background = userPassportViewModel.Background;

            PhoneTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            PhoneTB.Background = userPassportViewModel.Background;

            CitizenshipTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            CitizenshipTB.Background = userPassportViewModel.Background;

            SurnameTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            SurnameTB.Background = userPassportViewModel.Background;

            LoginTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            LoginTB.Background = userPassportViewModel.Background;

            GenderTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            GenderTB.Background = userPassportViewModel.Background;

            NumberTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            NumberTB.Background = userPassportViewModel.Background;

            PlaceWorkTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            PlaceWorkTB.Background = userPassportViewModel.Background;

            PostTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            PostTB.Background = userPassportViewModel.Background;

            EducationTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            EducationTB.Background = userPassportViewModel.Background;

            CommentTB.IsReadOnly = userPassportViewModel.IsReadOnly;
            CommentTB.Background = userPassportViewModel.Background;
        }

        #endregion
    }
}
