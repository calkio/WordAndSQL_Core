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
        private Users SelectedUser { get; set; }

        UserPassportViewModel userPassportViewModel = new UserPassportViewModel();

        public UserPassport()
        {
            InitializeComponent();
            SelectedUser = UsersObservableCollection.SelectedUser;
        }

        #region Побочные методы

        /// <summary>
        /// Заполянем textBox данными из базы
        /// </summary>
        private void GetTextBox()
        {
            SecondNameTB.Text = SelectedUser.SecondName;
            FirstNameTB.Text = SelectedUser.FirstName;
            SurnameTB.Text = SelectedUser.Surname;
            NumberTB.Text = SelectedUser.Numder;
            BirthDateTB.Text = SelectedUser.BirthDate;
            PhoneTB.Text = SelectedUser.Telephone;
            LoginTB.Text = SelectedUser.Login;
            SnilsTB.Text = SelectedUser.Snils;
            CitizenshipTB.Text = SelectedUser.Citizenship;
            GenderTB.Text = SelectedUser.Gender;
            PlaceWorkTB.Text = SelectedUser.PlaceWork;
            PostTB.Text = SelectedUser.Post;
            EducationTB.Text = SelectedUser.Education;
            CommentTB.Text = SelectedUser.Comment;
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

        #region Методы окна

        /// <summary>
        /// При нажатии на кнопку "Сохранить" сохраняются данные из textBox в базу данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userPassportViewModel.SaveTextBox(SecondNameTB.Text, FirstNameTB.Text, SurnameTB.Text, NumberTB.Text, BirthDateTB.Text, PhoneTB.Text, LoginTB.Text, SnilsTB.Text, CitizenshipTB.Text, GenderTB.Text);
            SelectedUser = GetData();
            GetTextBox();
        }

        /// <summary>
        /// Сохраняются заметки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            userPassportViewModel.SaveNotes(PlaceWorkTB.Text, PostTB.Text, EducationTB.Text, CommentTB.Text);
            userPassportViewModel.SaveTextBox(SecondNameTB.Text, FirstNameTB.Text, SurnameTB.Text, NumberTB.Text, BirthDateTB.Text, PhoneTB.Text, LoginTB.Text, SnilsTB.Text, CitizenshipTB.Text, GenderTB.Text);
            SelectedUser = GetData();
            GetTextBox();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SelectedUser = GetData();//загружаем данные в объект
            GetTextBox();//Заполянем textBox данными из базы
        }

        #endregion

    }
}
