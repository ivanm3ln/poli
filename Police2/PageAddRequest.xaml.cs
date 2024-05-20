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
    /// Логика взаимодействия для PageAddRequest.xaml
    /// </summary>
    public partial class PageAddRequest : Page
    {
        int idUser;
        public PageAddRequest(int idUser)
        {
            this.idUser = idUser;
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAutoNumber.Text) || string.IsNullOrEmpty(textBoxDescription.Text))
            {
                MessageBox.Show("Заполните все поля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Police2Entities.GetContext().AddRequest(textBoxAutoNumber.Text, textBoxDescription.Text, 1, idUser);
                MessageBox.Show("Заявка подана!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);

                Manager.MainFrame.GoBack();
            }
        }
    }
}
