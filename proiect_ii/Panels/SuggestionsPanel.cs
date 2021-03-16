using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using proiect_ii.Database.Account;


namespace proiect_ii.Panels
{

    /*
        * 0 - horror
        * 1 - actiune
        * 2 - aventura
        * 3 - rpg
        * 4 - platformer
        * 5 - curse
        * 6 - simulare
        * 7 - indie
        * 8 - mmo
        * 9 - coop
        */

    /// <summary>
    /// Panou sugestii jocuri
    /// </summary>
    public partial class SuggestionsPanel : Window
    {
        private RegisterPanel registerPanel;

        private Account newAccount;

        private AccountController accountController;

        private List<int> selectedGenres;

        public SuggestionsPanel(RegisterPanel registerPanel, Account newAccount)
        {
            InitializeComponent();

            this.registerPanel = registerPanel;

            this.Left = registerPanel.Left;
            this.Top = registerPanel.Top;

            this.newAccount = newAccount;

            accountController = new AccountController();

            this.selectedGenres = new List<int>();
        }

        private void ProcessFirstSelection(Object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           this.selectedGenres.Add(firstComboBox.SelectedIndex);
        }

        private void ProcessSecondSelection(Object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.selectedGenres.Add(secondComboBox.SelectedIndex);
        }

        private void ProcessThirdSelection(Object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.selectedGenres.Add(secondComboBox.SelectedIndex);
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
