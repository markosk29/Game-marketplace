using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
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
        private QuestionsPanel _questionsPanel;

        private Account _newAccount;

        private AccountController accountController;

        private GameController gameController;

        private List<int> selectedCategories;
        private List<Game> firstCategories;
        private List<Game> secondCategories;
        private List<Game> thirdCategories;
        private List<Image> suggestedGames;
        private List<int> favoriteGameIds;

        public SuggestionsPanel(QuestionsPanel questionsPanel, Account newAccount)
        {
            InitializeComponent();

            this._questionsPanel = questionsPanel;
            this._newAccount = newAccount;

            this.Left = _questionsPanel.Left;
            this.Top = _questionsPanel.Top;

            this.accountController = new AccountController();
            this.gameController = new GameController();

            this.selectedCategories = new List<int>();
            this.suggestedGames = new List<Image>();
            this.favoriteGameIds = new List<int>();

            initSuggestedGames();

        }

        private void ConfirmSelection(Object sender, RoutedEventArgs e)
        {
            if (firstComboBox.SelectedIndex > -1 &&
                secondComboBox.SelectedIndex > -1 &&
                thirdComboBox.SelectedIndex > -1)
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
            firstCategories = gameController.ReadFromDatabaseGames("category1", selectedCategories[0]);
            secondCategories = gameController.ReadFromDatabaseGames("category2", selectedCategories[1]);
            thirdCategories = gameController.ReadFromDatabaseGames("category3", selectedCategories[2]);

            var rand = new Random();

            BitmapImage placeholderImage = new BitmapImage(new Uri("/images/default_gamepic.png", UriKind.Relative));

            for (int i = 0; i < suggestedGames.Count; i++)
            {
                if (i < 2)
                {
                    if (!suggestedGames[i].IsEnabled)
                    {
                        suggestedGames[i].IsEnabled = true;

                        try
                        {
                            int index = rand.Next(firstCategories.Count - 1);
                            suggestedGames[i].Source = new BitmapImage(new Uri(firstCategories[index].main_img_link, UriKind.Absolute));

                            favoriteGameIds.Add(firstCategories[index].id);
                            firstCategories.RemoveAt(index);
                        }
                        catch (Exception e)
                        {
                            suggestedGames[i].Source = placeholderImage;
                        }
                    }
                }

                if (i >= 2 && i < 3)
                {
                    if (!suggestedGames[i].IsEnabled)
                    {
                        suggestedGames[i].IsEnabled = true;

                        try
                        {
                            int index = rand.Next(secondCategories.Count - 1);
                            suggestedGames[i].Source = new BitmapImage(new Uri(secondCategories[index].main_img_link, UriKind.Absolute));

                            favoriteGameIds.Add(secondCategories[index].id);
                            secondCategories.RemoveAt(index);
                        }
                        catch (Exception e)
                        {
                            suggestedGames[i].Source = placeholderImage;
                        }
                    }
                }

                if (i == 3)
                {
                    if (!suggestedGames[i].IsEnabled)
                    {
                        suggestedGames[i].IsEnabled = true;

                        try
                        {
                            int index = rand.Next(thirdCategories.Count - 1);
                            suggestedGames[i].Source = new BitmapImage(new Uri(thirdCategories[index].main_img_link, UriKind.Absolute));

                            favoriteGameIds.Add(thirdCategories[index].id);
                            thirdCategories.RemoveAt(index);
                        }
                        catch (Exception e)
                        {
                            suggestedGames[i].Source = placeholderImage;
                        }
                    }
                }
            }

            coverBg.Visibility = Visibility.Visible;
            coverText.Visibility = Visibility.Visible;
        }

        private void PreviousButton(Object sender, RoutedEventArgs e)
        {
            _questionsPanel.Show();

            ResumePanelLocation();

            this.Hide();

        }

        private void NextButton(Object sender, RoutedEventArgs e)
        { 
            LinkObjectToDb();

            AddFavoriteGamesToDb();

            ShopPanel shopPanel = new ShopPanel(_newAccount);
            shopPanel.Show();

            this.Close();
        }

        private void ResumePanelLocation()
        {
            _questionsPanel.Left = this.Left;
            _questionsPanel.Top = this.Top;
        }

        private void LinkObjectToDb()
        {
            accountController.AddToDatabase(_newAccount);

        }

        private void AddFavoriteGamesToDb()
        {
            Account account = accountController.GetAccountByUsername(_newAccount.username);

            foreach (int gameId in favoriteGameIds)
            {
                accountController.AddFavoriteGames(account.id, gameId);
            }
        }

        private void initSuggestedGames()
        {
            //temp

            suggestedGames.Add(suggestedGame1);
            suggestedGames.Add(suggestedGame2);
            suggestedGames.Add(suggestedGame3);
            suggestedGames.Add(suggestedGame4);
        }
   
    }
}
