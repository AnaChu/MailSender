using System;
using System.Security;
using System.Windows;

namespace TestWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var user_name = UserNameEdit.Text;
                //var user_password = PasswordEdit.Password;
                SecureString user_password = PasswordEdit.SecurePassword;

                var message = new Message
                {
                    Subject = SubjectEdit.Text,
                    Body = BodyEdit.Text
                };

                var mailSender = new EmailSender(YandexServer.Address, YandexServer.Port, user_name, user_password);

                mailSender.Send(Mails.From, Mails.To, message);

                MessageBox.Show("Почта отправлена!", "Ура!!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
