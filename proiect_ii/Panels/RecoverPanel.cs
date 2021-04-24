using System;
using System.Windows;
using proiect_ii.Database.Account;

namespace proiect_ii.Panels
{
    /// <summary>
    /// Interaction logic for RecoverPanel.xaml
    /// </summary>
    public partial class RecoverPanel : Window
    {

        private MainWindow _mainWindow;
        private AccountController _accountController;
        private Account _userAccount;

        public RecoverPanel(MainWindow mainWindow)
        {
            InitializeComponent();

            this._mainWindow = mainWindow;

            this._accountController = new AccountController();

            errorLabel.Content = "";
        }

        public void Return(object sender, RoutedEventArgs e)
        {
            this.Hide();

            _mainWindow.Show();
        }

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
                !String.IsNullOrWhiteSpace(passwordBox.Password))
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
            welcomeLabel.Content = "Welcome, " + _userAccount.username + "!";

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

            succesMessageLabel.Visibility = Visibility.Visible;
            
        }

        private void ThrowError(int id)
        {
            switch (id)
            {
                case 1:
                    errorLabel.Content = "There is no account with this e-mail adress!";
                    break;
                case 2:
                    errorLabel.Content = "One or more answers are incorrect!";
                    break;
                case 3:
                    errorLabel.Content = "Please enter a valid password!";
                    break;
            }
        }
    }
}
