using System;
using System.Windows;
using System.Windows.Controls;


namespace proiect_ii.Panels
{
    /// <summary>
    /// Panoul de inregistrare pentru utilizatori noi
    /// </summary>
    public partial class RegisterPanel : Window
    {
        private SuggestionsPanel suggestionsPanel { get; }

        public RegisterPanel()
        {
            InitializeComponent();

            suggestionsPanel = new SuggestionsPanel(this);
        }

        private void nextButton(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(usernameTextbox.Text)
                || String.IsNullOrEmpty(confirmPassBox.Password)
                || String.IsNullOrEmpty(passwordBox.Password)
                || String.IsNullOrEmpty(emailTextbox.Text))
            {
                SendError("Camp gol!!!");
            }
            else
            {
                if (passwordBox.Password.Equals(confirmPassBox.Password))
                {
                    suggestionsPanel.Show();

                    ResumePanelLocation();

                    this.Hide();
                }
                else
                {
                    SendError("Parolele nu corespund!!!");
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

    }
}
