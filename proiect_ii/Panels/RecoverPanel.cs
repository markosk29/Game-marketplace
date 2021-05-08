using System;
using System.Windows;
using System.Windows.Media.Imaging;
using proiect_ii.Database.Account;

namespace proiect_ii.Panels
{
    /// <summary>
    /// Interaction logic for RecoverPanel.xaml
    /// </summary>
    public partial class RecoverPanel : Window
    {

        public static readonly RoutedEvent SendNotificationEvent = EventManager.RegisterRoutedEvent(
            "SendNotification", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RecoverPanel));

        private bool animCompleted;

        private MainWindow _mainWindow;
        private AccountController _accountController;
        private Account _userAccount;
        Utilities utils;

        public RecoverPanel(MainWindow mainWindow)
        {
            InitializeComponent();

            this._mainWindow = mainWindow;

            this._accountController = new AccountController();

            animCompleted = true;

            errorLabel.Content = "";

            this.utils = new Utilities();
        }

        public void Return(object sender, RoutedEventArgs e)
        {
            this.Hide();

            _mainWindow.Show();
        }

        //de facut verificare mai stricta! -> Rezolvat in Inregisrare
        public void VerifyEmail(object sender, RoutedEventArgs e)
        {
            _userAccount = _accountController.GetAccountByEmail(emailBox.Text);

            if (_userAccount.email != null)
            {
                emailBox.Visibility = Visibility.Hidden;
                emailLabel.Visibility = Visibility.Hidden;
                confirmButton.Visibility = Visibility.Hidden;

                securityQuestion1.Content = _userAccount.securityQuestion1;
                securityQuestion2.Content = _userAccount.securityQuestion2;
                securityQuestion3.Content = _userAccount.securityQuestion3;

                securityQuestion1.Visibility = Visibility.Visible;
                securityQuestion2.Visibility = Visibility.Visible;
                securityQuestion3.Visibility = Visibility.Visible;
                firstAnswer.Visibility = Visibility.Visible;
                secondAnswer.Visibility = Visibility.Visible;
                thirdAnswer.Visibility = Visibility.Visible;
                confirmAnswersButton.Visibility = Visibility.Visible;

            }
            else
            {
                ThrowError(1);
            }
        }

        public void VerifyAnswers(object sender, RoutedEventArgs e)
        {
            if (firstAnswer.Text.Equals(_userAccount.securityAnswer1) &&
                secondAnswer.Text.Equals(_userAccount.securityAnswer2) &&
                thirdAnswer.Text.Equals(_userAccount.securityAnswer3))
            {
                securityQuestion1.Visibility = Visibility.Hidden;
                securityQuestion2.Visibility = Visibility.Hidden;
                securityQuestion3.Visibility = Visibility.Hidden;
                firstAnswer.Visibility = Visibility.Hidden;
                secondAnswer.Visibility = Visibility.Hidden;
                thirdAnswer.Visibility = Visibility.Hidden;
                confirmAnswersButton.Visibility = Visibility.Hidden;

                errorLabel.Content = "";

                ChangePassword();
            }
            else
            {
                ThrowError(2);
            }
        }

        public void ConfirmPasswordChange(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(passwordBox.Password) &&
                !String.IsNullOrWhiteSpace(passwordBox.Password) &&
                utils.StrongPass(passwordBox.Password))
            {
                _userAccount.password = passwordBox.Password;

                errorLabel.Content = "";

                _accountController.UpdatePassword(_userAccount);

                FinishPasswordChange();
            }
            else
            {
                ThrowError(3);
            }
        }

        public void ReturnToLogin(object sender, RoutedEventArgs e)
        {
            this.Close();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void ChangePassword()
        {
            welcomeLabel.Content = "Welcome, " +_userAccount.username + "!";

            welcomeLabel.Visibility = Visibility.Visible;
            changePasswordLabel.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Visible;
            confirmPasswordChange.Visibility = Visibility.Visible;
        }

        private void FinishPasswordChange()
        {
            welcomeLabel.Visibility = Visibility.Hidden;
            changePasswordLabel.Visibility = Visibility.Hidden;
            passwordBox.Visibility = Visibility.Hidden;
            confirmPasswordChange.Visibility = Visibility.Hidden;

            ReturnButton.Margin = new Thickness(
                ReturnButton.Margin.Left,
                ReturnButton.Margin.Top - 220,
                ReturnButton.Margin.Right,
                ReturnButton.Margin.Bottom);

            CreateNotification("Password successfully updated!", "success");
            
        }

        private void ThrowError(int id)
        {
            switch (id)
            {
                case 1:
                    CreateNotification("Invalid e-mail address!", "warning");
                    break;
                case 2:
                    CreateNotification("One or more answers are incorrect!", "warning");
                    break;
                case 3:
                    CreateNotification("Please enter a valid password!", "warning");
                    break;
            }
        }

        private void CreateNotification(string message, string type)
        {
            if (animCompleted)
            {
                animCompleted = false;

                NotificationLabel.Content = message;
                NotificationImage.Source = new BitmapImage(new Uri("../images/" +type+ ".png", UriKind.Relative));

                RoutedEventArgs newEventArgs = new RoutedEventArgs(SendNotificationEvent);
                Notification.RaiseEvent(newEventArgs);
            }
        }

        public event RoutedEventHandler SendNotification
        {
            add { AddHandler(SendNotificationEvent, value); }
            remove { RemoveHandler(SendNotificationEvent, value); }
        }

        private void NotificationAnimCompleted(object sender, EventArgs e)
        {
            animCompleted = true;
        }
    }
}
