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
        private Users user { get; set; }

        public object User
        {
            get => user;
            set => user = (Users)value;
        }

        UserPassportViewModel userPassportViewModel = new UserPassportViewModel();

        public UserPassport()
        {
            InitializeComponent();
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

            userPassportViewModel.SelectedUser = user;
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
            user = GetData();
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
            user = GetData();
            GetTextBox();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            user = GetData();//загружаем данные в объект
            GetTextBox();//Заполянем textBox данными из базы
        }

        #endregion


    }
}
