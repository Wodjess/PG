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

namespace Passwordgenerator_LITE
{
    public partial class SecretWord : Page
    {
        byte one = 1;
        public static string SecretWord1;
        public SecretWord()
        {
            InitializeComponent();
        }
        void Exit_app(object sender, RoutedEventArgs s)
        {
            Application.Current.Shutdown();
        }
        void Ready(object sender, RoutedEventArgs s)
        {
            if (password.Text != "")
            {
                try
                {
                    SecretWord1 = password.Text;
                    NavigationService.Navigate(new password_generator());

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Произошла ошибка " + ex);
                }
            }
        }
        void clicker(object sender, RoutedEventArgs s)
        {
            if (one == 1)
            {
                password.Text = "";
                one = 0;
            }
        }
    }
}
