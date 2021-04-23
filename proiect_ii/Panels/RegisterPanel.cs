using System;
using System.Windows;
using System.Windows.Controls;
using proiect_ii.Database.Account;


namespace proiect_ii.Panels
{
    /// <summary>
    /// Panoul de inregistrare pentru utilizatori noi
    /// </summary>
    public partial class RegisterPanel : Window
    {
        Account _newAccount;

        public RegisterPanel()
        {
            InitializeComponent();

            this._newAccount = new Account();
        }

        private void nextButton(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(usernameTextbox.Text)
                || String.IsNullOrEmpty(confirmPassBox.Password)
                || String.IsNullOrEmpty(passwordBox.Password)
                || String.IsNullOrEmpty(emailTextbox.Text))
            {
                SendError("One or more fields are empty!");
            }
            else
            {
                if (passwordBox.Password.Equals(confirmPassBox.Password))
                {
                    _newAccount.username = usernameTextbox.Text;
                    _newAccount.password = passwordBox.Password;
                    _newAccount.email = emailTextbox.Text;

                    QuestionsPanel questionsPanel = new QuestionsPanel(this, _newAccount);
                    questionsPanel.Show();

                    this.Hide();
                }
                else
                {
                    SendError("Passwords must match!");
                }
            }
        }

        private void SendError(String errorMessage)
        {
            Label label = this.FindName("errorLabel") as Label;
            label.Content = errorMessage;
        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainl = new MainWindow();
            mainl.Show();

            this.Close();
        }

    }
}
