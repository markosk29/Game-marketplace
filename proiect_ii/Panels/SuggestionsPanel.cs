using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using proiect_ii.Database.Account;
using proiect_ii.Database.Game;


namespace proiect_ii.Panels
{

    /*
        * 0 - horror
        * 1 - Action
        * 2 - Adventure
        * 3 - RPG
        * 4 - platformer
        * 5 - racing
        * 6 - simulation
        * 7 - indie
        * 8 - mmo
        * 9 - coop
        * 10 - openworld
        * 11 - shooter
        * 12 - strategy
        * 13 - casual
        * 14 - sports
        * 15 - SciFi
        * 16 - VR
        * 17 - PostApocalyptic
        * 18 - Survival  
        */

    /// <summary>
    /// Panou sugestii jocuri
    /// </summary>
    public partial class SuggestionsPanel : Window
    {
        private RegisterPanel registerPanel;

        private Account newAccount;

        private AccountController accountController;

        private GameController gameController;

        private List<int> selectedCategories;
        private List<string> availableGames;
        private List<string> firstCategories;
        private List<string> secondCategories;
        private List<string> thirdCategories;
        private List<Label> labels;

        public SuggestionsPanel(RegisterPanel registerPanel, Account newAccount)
        {
            InitializeComponent();

            this.registerPanel = registerPanel;
            this.newAccount = newAccount;

            this.Left = registerPanel.Left;
            this.Top = registerPanel.Top;

            this.accountController = new AccountController();
            this.gameController = new GameController();

            this.selectedCategories = new List<int>();
            this.availableGames = new List<string>();
            this.firstCategories = new List<string>();
            this.secondCategories = new List<string>();
            this.thirdCategories = new List<string>();
            this.labels = new List<Label>();

        }

        private void ConfirmSelection(Object sender, RoutedEventArgs e)
        {
            AddToList(firstComboBox.SelectedIndex);
            AddToList(secondComboBox.SelectedIndex);
            AddToList(thirdComboBox.SelectedIndex);

            confirmButton.IsEnabled = false;

            firstComboBox.IsEnabled = false;
            secondComboBox.IsEnabled = false;
            thirdComboBox.IsEnabled = false;

            ProcessSuggestions();
        }

        private void AddToList(int index)
        {
            bool found = false;

            foreach (int genre in this.selectedCategories)
            {
                if (genre == index)
                {
                    found = true;
                }

            }

            if (found == false)
            {
                this.selectedCategories.Add(index);
            }
        }

        private void ProcessSuggestions()
        {
            availableGames = gameController.ReadFromDatabase("name");
            firstCategories = gameController.ReadFromDatabase("category1");
            secondCategories = gameController.ReadFromDatabase("category2");
            thirdCategories = gameController.ReadFromDatabase("category3");

            initLabels();

            foreach(Label label in labels)
            {
                if (string.IsNullOrWhiteSpace(label.Content.ToString()))
                {
                    foreach(string category in firstCategories)
                    {
                        
                    }
                }
            }

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

        private void initLabels()
        {
            //temp

            labels.Add(testLabel1);
            labels.Add(testLabel2);
            labels.Add(testLabel3);
            labels.Add(testLabel4);
            labels.Add(testLabel5);
        }
   
    }
}
