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
        private SuggestionsPanel suggestionsPanel { get; set; }

        Account newAccount;

        public RegisterPanel()
        {
            InitializeComponent();

            newAccount = new Account();
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
                    newAccount.username = usernameTextbox.Text;
                    newAccount.password = passwordBox.Password;
                    newAccount.email = emailTextbox.Text;

                    suggestionsPanel = new SuggestionsPanel(this, newAccount);
                    suggestionsPanel.Show();

                    ResumePanelLocation();

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

        //in cazul apasarii butonului next, 
        //panoul de sugestii sa fie pe aceeasi locatie ca si cel de inregistrare
        private void ResumePanelLocation()
        {
            suggestionsPanel.Left = this.Left;
            suggestionsPanel.Top = this.Top;
        }

        private void ExitButton2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
