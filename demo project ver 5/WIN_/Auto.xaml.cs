using demo_project_ver_5.DB_;
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
using System.Windows.Shapes;

namespace demo_project_ver_5.WIN_
{
    /// <summary>
    /// Interaction logic for Auto.xaml
    /// </summary>
    public partial class Auto : Window
    {
        public Auto()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var user = DB_.demo_ver5Entities.GetContext().TbПользователь.FirstOrDefault(x => x.Имя == tbAutoLogin.Text && x.Пароль == tbAutoPassword.Password);
            if (user != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TbПользователь tb = new TbПользователь()
                {
                    Имя = tbAutoLogin.Text,
                    Пароль = tbAutoPassword.Password
                };
                DB_.demo_ver5Entities.GetContext().TbПользователь.Add(tb);
DB_.demo_ver5Entities.GetContext().SaveChanges();
                MessageBox.Show("Регистрация прошла успешно");
            }
            catch  { MessageBox.Show("ошибка"); }
        }
    }
}
