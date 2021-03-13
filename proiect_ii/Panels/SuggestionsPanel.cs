using System;
using System.Windows;
using proiect_ii.Database.Account;


namespace proiect_ii.Panels
{
    /// <summary>
    /// Panou preferinte jocuri
    /// </summary>
    public partial class SuggestionsPanel : Window
    {
        private RegisterPanel registerPanel;

        private Account newAccount;

        private AccountController accountController;
        public SuggestionsPanel(RegisterPanel registerPanel, Account newAccount)
        {
            InitializeComponent();

            this.registerPanel = registerPanel;

            this.Left = registerPanel.Left;
            this.Top = registerPanel.Top;

            this.newAccount = newAccount;
            accountController = new AccountController();
        }

        private void PreviousButton(Object sender, RoutedEventArgs e)
        {
            registerPanel.Show();

            ResumePanelLocation();

            this.Hide();

        }

        private void NextButton(Object sender, RoutedEventArgs e)
        { 
            LinkObjectToDb();
        }


        //in cazul apasarii butonului de intoarcere,
        //fereastra anterioara sa fie pe aceeasi pozitie cu cea curenta
        private void ResumePanelLocation()
        {
            registerPanel.Left = this.Left;
            registerPanel.Top = this.Top;
        }

        private void LinkObjectToDb()
        {
            accountController.AddToDatabase(newAccount);
        }
    }
}
