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

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для LoginWindows.xaml
    /// </summary>
    public partial class LoginWindows : Window
    {
        public LoginWindows()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = Login.Text;
            string password = Password.Text;
            

            if (username.Equals("admin") && password.Equals("password"))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
           
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
        }

        private void ForgotPassword_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void ContinueWithoutLogin_Click(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
