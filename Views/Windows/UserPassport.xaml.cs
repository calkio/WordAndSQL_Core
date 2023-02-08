using System.Windows;
using WordAndSQL_Core.Entity;
using WordAndSQL_Core.ViewModels;

namespace WordAndSQL_Core.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserPassport.xaml
    /// </summary>
    public partial class UserPassport : Window
    {
        Users user = new Users();
        UserPassportViewModel userPassportViewModel = new UserPassportViewModel();

        public UserPassport()
        {
            InitializeComponent();

            user = GetData();//загружаем данные в объект
            GetTextBox();//Заполянем textBox данными из базы
        }

        #region Побочные методы

        /// <summary>
        /// Заполянем textBox данными из базы
        /// </summary>
        private void GetTextBox()
        {
            SecondNameTB.Text = user.SecondName;
            FirstNameTB.Text = user.FirstName;
            SurnameTB.Text = user.Surname;
            NumberTB.Text = user.Numder;
            BirthDateTB.Text = user.BirthDate;
            PhoneTB.Text = user.Telephone;
            LoginTB.Text = user.Login;
            SnilsTB.Text = user.Snils;
            CitizenshipTB.Text = user.Citizenship;
            GenderTB.Text = user.Gender;
            PlaceWorkTB.Text = user.PlaceWork;
            PostTB.Text = user.Post;
            EducationTB.Text = user.Education;
            CommentTB.Text = user.Comment;
        }

        /// <summary>
        /// Загрузка данных в объект
        /// </summary>
        /// <returns></returns>
        private Users GetData()
        {
            var _user = new Users();

            _user = userPassportViewModel.GetDataUsers();

            return _user;
        }

        #endregion

        #region События окна

        /// <summary>
        /// Заполнение Таблицы данными
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableUser_Loaded(object sender, RoutedEventArgs e)
        {
            TableUser.ItemsSource = userPassportViewModel.GetDataGroup();
        }

        /// <summary>
        /// При нажатии на кнопку "Сохранить" сохраняются данные из textBox в базу данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userPassportViewModel.SaveTextBox();
            GetTextBox();
        }

        /// <summary>
        /// Сохраняются заметки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            userPassportViewModel.SaveNotes();
            GetTextBox();
        }

        #endregion
    }
}
