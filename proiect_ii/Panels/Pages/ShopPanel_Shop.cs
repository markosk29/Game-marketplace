using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using proiect_ii.Database.Account;
using proiect_ii.Database.Game;


namespace proiect_ii.Panels.Pages
{
    /// <summary>
    /// Interaction logic for ShopPanel_Shop.xaml
    /// </summary>
    public partial class ShopPanel_Shop : Page
    {
        private List<Game> _availableGames;
        private List<Image> _printedGames;
        private List<int> _favoriteGameIds;

        private GameController _gameController;
        private AccountController _accountController;

        private Account _user;

        private BitmapImage _placeholderImage;

        private Label _balance;

        public ShopPanel_Shop()
        {
            InitializeComponent();

            this._printedGames = new List<Image>();

            this._gameController = new GameController();
            this._availableGames = _gameController.ReadAllGames();

            this._placeholderImage = new BitmapImage(new Uri("/images/default_gamepic.png", UriKind.Relative));

            ListFeaturedGame(true);
            ListAllGames(true);

            suggestGamesBg.Visibility = Visibility.Hidden;
            suggestGamesPromo.Visibility = Visibility.Hidden;
            suggestedGame1.Visibility = Visibility.Hidden;
            suggestedGame2.Visibility = Visibility.Hidden;
            suggestedGame3.Visibility = Visibility.Hidden;
            suggestedGame4.Visibility = Visibility.Hidden;
        }

        public ShopPanel_Shop(Account account, Label balance)
        {
            InitializeComponent();

            this._printedGames = new List<Image>();

            this._gameController = new GameController();
            this._accountController = new AccountController();
            this._availableGames = _gameController.ReadAllGames();

            this._user = _accountController.GetAccountByUsername(account.username);

            this._placeholderImage = new BitmapImage(new Uri("/images/default_gamepic.png", UriKind.Relative));

            this._balance = balance;

            ListSuggestedGames();
            ListFeaturedGame(false);
            ListAllGames(false);
        }

        private void ListSuggestedGames()
        {
            List<Image> suggestedGameImages = this.GetSuggestedGames();
            _favoriteGameIds = _accountController.GetFavoriteGames(_user.id);

            int i = 0;

            foreach (Image suggestedGame in suggestedGameImages)
            {
                try
                {
                    suggestedGame.Source = new BitmapImage(new Uri(_gameController.GetGameById(_favoriteGameIds[i]).main_img_link, UriKind.Absolute));

                    suggestedGame.Name = suggestedGame.Name + "_" + i;
                    suggestedGame.AddHandler(MouseDownEvent, new RoutedEventHandler(GoToFavoriteGamePage));
                }
                catch (Exception e)
                {
                    suggestedGame.Source = _placeholderImage;
                }

                i++;
            }
        }

        private void ListFeaturedGame(bool isGuest)
        {
            featuredGame.Source = new BitmapImage(new Uri(_availableGames[3].main_img_link, UriKind.Absolute));

            featuredGameDescription.Text = _availableGames[3].description;

            if (isGuest)
            {
                Grid.SetRow(featuredGameBg, 0);
                Grid.SetRow(featuredGame, 0);
                Grid.SetRow(featuredGameDescription, 0);
                Grid.SetRow(featuredGamePromo, 0);
                Grid.SetRow(featuredGamePromoText, 0);
                Grid.SetRow(featuredGameSafeguard, 0);

                featuredGameBg.Margin = new Thickness(0, 120, 0, 0);
                featuredGame.Margin = new Thickness(-450, 160, 0, 0);
                featuredGameDescription.Margin = new Thickness(200, 180, 0, 0);
                featuredGamePromo.Margin = new Thickness(600, 75, 0, 0);
                featuredGamePromoText.Margin = new Thickness(600, 100, 0, 0);
                featuredGameSafeguard.Margin = new Thickness(200, 180, 0, 0);
            }

            //featuredGame.AddHandler(MouseEnterEvent, new RoutedEventHandler());
            //featuredGame.AddHandler(MouseLeaveEvent, new RoutedEventHandler());
        }

        private void ListAllGames(bool isGuest)
        {
            double left = -1000;
            double top = 450;

            gamesBg.Height = 950;

            _availableGames = Shuffle(_availableGames);

            if (isGuest)
            {
                top = 50;
                gamesBg.Margin = new Thickness(0, 25, 0, 0);
                gamesBg.Height = 1350;
            }


            _printedGames.Add(new Image()
            {
                Name = "game_0",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(left, top, 0, 0),
                Width = 250,
                Height = 200,
                Stretch = Stretch.Fill
            });

            try
            {
                _printedGames[0].Source =
                    new BitmapImage(new Uri(_availableGames[0].main_img_link, UriKind.Absolute));
            }
            catch (Exception e)
            {
                _printedGames[0].Source = _placeholderImage;
            }

            _printedGames[0].AddHandler(MouseEnterEvent, new RoutedEventHandler(ShowGameTitle));
            _printedGames[0].AddHandler(MouseLeaveEvent, new RoutedEventHandler(HideGameTitle));
            _printedGames[0].AddHandler(MouseDownEvent, new RoutedEventHandler(GoToGamePage));

            Grid.SetRow(_printedGames[0], 1);
            RenderOptions.SetBitmapScalingMode(_printedGames[0], BitmapScalingMode.Fant);

            shopPage.Children.Add(_printedGames[0]);

            int k = 1;
            int j = 1;

            int maxRows;

            if (isGuest)
            {
                maxRows = 6;
            }
            else
            {
                maxRows = 4;
            }

            for (int i = 0; i < maxRows; i++)
            {
                while (j < 5)
                {
                    left += 499;

                    _printedGames.Add(new Image()
                    {
                        Name = "game_" + k,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(left, top, 0, 0),
                        Width = 250,
                        Height = 200,
                        Stretch = Stretch.Fill
                    });

                    try
                    {
                        _printedGames[k].Source =
                            new BitmapImage(new Uri(_availableGames[k].main_img_link, UriKind.Absolute));
                    }
                    catch (Exception e)
                    {
                        _printedGames[k].Source = _placeholderImage;
                    }

                    _printedGames[k].AddHandler(MouseEnterEvent, new RoutedEventHandler(ShowGameTitle));
                    _printedGames[k].AddHandler(MouseLeaveEvent, new RoutedEventHandler(HideGameTitle));
                    _printedGames[k].AddHandler(MouseDownEvent, new RoutedEventHandler(GoToGamePage));

                    Grid.SetRow(_printedGames[k], 1);
                    RenderOptions.SetBitmapScalingMode(_printedGames[k], BitmapScalingMode.Fant);

                    shopPage.Children.Add(_printedGames[k]);

                    k++;
                    j++;
                }

                j = 0;

                left = -1499;
                top += 200;
            }
        }

        private List<Image> GetSuggestedGames()
        {
            List<Image> suggestedGames = new List<Image>();

            suggestedGames.Add(suggestedGame1);
            suggestedGames.Add(suggestedGame2);
            suggestedGames.Add(suggestedGame3);
            suggestedGames.Add(suggestedGame4);

            return suggestedGames;
        }

        private void ShowGameTitle(object sender, RoutedEventArgs e)
        {
            Image image = (Image)sender;

            gameInfoBg.Margin =
                new Thickness(image.Margin.Left, image.Margin.Top + 150, image.Margin.Right, image.Margin.Bottom);
            gameInfoName.Margin =
                new Thickness(image.Margin.Left, image.Margin.Top + 155, image.Margin.Right, image.Margin.Bottom);

            Panel.SetZIndex(gameInfoBg, 1);
            Panel.SetZIndex(gameInfoName, 1);

            if (image.Source == _placeholderImage)
            {
                gameInfoName.Content = "N/A";
            }
            else
            {
                gameInfoName.Content = _availableGames[Convert.ToInt32(image.Name.Split("_")[1])].name;
            }

            gameInfoBg.Visibility = Visibility.Visible;
            gameInfoName.Visibility = Visibility.Visible;
        }

        private void HideGameTitle(object sender, RoutedEventArgs e)
        {
            gameInfoBg.Visibility = Visibility.Hidden;
            gameInfoName.Visibility = Visibility.Hidden;
        }

        private void GoToGamePage(object sender, RoutedEventArgs e)
        {
            Image game = (Image) sender;

            this.NavigationService.Navigate(new ShopPanel_Game(_availableGames[Convert.ToInt32(game.Name.Split("_")[1])], _user, _balance), UriKind.Relative);
        }

        private void GoToFavoriteGamePage(object sender, RoutedEventArgs e)
        {
            Image game = (Image) sender;

            this.NavigationService.Navigate(
                new ShopPanel_Game(_gameController.GetGameById(_favoriteGameIds[Convert.ToInt32(game.Name.Split("_")[1])]), _user, _balance), UriKind.Relative);
        }

        private List<T> Shuffle<T>(List<T> list)
        {
            Random random = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}
