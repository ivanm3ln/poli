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
    /// Логика взаимодействия для PageRequest.xaml
    /// </summary>
    public partial class PageRequest : Page
    {
        int idUser;
        public PageRequest(int idUser)
        {
            this.idUser = idUser;
            InitializeComponent();


            updateDG();
        }

        private void updateDG()
        {
            var query =
                from request in Police2Entities.GetContext().Request
                orderby request.Id
                where request.IdUser == idUser
                select new
                {
                    request.Id,
                    request.AutoNumber,
                    request.Description,
                    Status = request.Status.Title
                };

            dataGridRequest.ItemsSource = query.ToList();
        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAddRequest(idUser));
        }



        private void dataGridRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateDG();
        }
    }
}
