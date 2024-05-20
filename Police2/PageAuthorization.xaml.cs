using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Police2
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public PageAuthorization()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            int idUser = 1;
            if (string.IsNullOrEmpty(textBoxLogin.Text) || string.IsNullOrEmpty(passwordBox.Password))
            {
                MessageBox.Show("Заполните все поля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            if (textBoxLogin.Text == "copp" && passwordBox.Password == "password")
            {
                MessageBox.Show("Успешная авторизация администратора!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.MainFrame.Navigate(new PageAdmin());
            } else
            {
                idUser = tryAuth(textBoxLogin.Text, passwordBox.Password);
                if (idUser == -1)
                {
                    MessageBox.Show("Нет такого логина!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                } else if (idUser == 0)
                {
                    MessageBox.Show("Неправильный пароль!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Успешная авторизация!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                    Manager.MainFrame.Navigate( new PageRequest(idUser));
                }
            }
        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Registration());
        }

        public int tryAuth(string login, string password)
        {
            foreach(User user in Police2Entities.GetContext().User.ToList())
            {
                if(user.Login == login)
                {
                    if (user.Password == password)
                    {
                        return user.Id;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            return -1;
        }
    }
}
