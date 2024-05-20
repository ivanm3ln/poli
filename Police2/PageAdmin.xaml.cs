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
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();

            updateDG();

            comboBoxStatus.Items.Add("Одобрено");
            comboBoxStatus.Items.Add("Отклонено");

            comboBoxStatus.SelectedIndex = 0;
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            dynamic item = dataGridRequest.SelectedItem;
            int idRequest = item.Id;

            if (item.Status == "Новое")
            {

                if (comboBoxStatus.SelectedIndex == 0)
                {
                    Police2Entities.GetContext().EditRequest(idRequest, 2);
                }
                else if (comboBoxStatus.SelectedIndex == 1)
                {
                    Police2Entities.GetContext().EditRequest(idRequest, 3);
                }
                MessageBox.Show("Заявка изменена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);

                updateDG();
            } else
            {
                MessageBox.Show("Заявка нельзя изменить, уже рассмотрена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void updateDG()
        {
            var query =
                from request in Police2Entities.GetContext().Request
                orderby request.Id
                select new
                {
                    request.Id,
                    request.AutoNumber,
                    request.Description,
                    Status = request.Status.Title,
                    User = (request.User.Surname + " " + request.User.Name + " " + request.User.Patronymic)
                };

            dataGridRequest.ItemsSource = query.ToList();
        }

        private void dataGridRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateDG();
        }
    }
}
