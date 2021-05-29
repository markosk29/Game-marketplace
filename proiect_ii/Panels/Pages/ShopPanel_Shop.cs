using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using proiect_ii.Database.Account;
using proiect_ii.Database.Game;
using Rectangle = System.Windows.Shapes.Rectangle;


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
        private List<Game> _foundGames;

        private GameController _gameController;
        private AccountController _accountController;

        private Account _user;

        private BitmapImage _placeholderImage;

        private Label _balance;

        private Game _featuredGame;

        public ShopPanel_Shop(Game featuredGame)
        {
            InitializeComponent();

            this._printedGames = new();

            this._gameController = new();
            this._foundGames = new();
            this._availableGames = _gameController.ReadAllGames();

            this._placeholderImage = new BitmapImage(new Uri("/images/default_gamepic.png", UriKind.Relative));

            this._featuredGame = featuredGame;

            ListFeaturedGame(true);
            ListAllGames(true);

            suggestGamesBg.Visibility = Visibility.Hidden;
            suggestGamesPromo.Visibility = Visibility.Hidden;
            suggestedGame1.Visibility = Visibility.Hidden;
            suggestedGame2.Visibility = Visibility.Hidden;
            suggestedGame3.Visibility = Visibility.Hidden;
            suggestedGame4.Visibility = Visibility.Hidden;
        }

        public ShopPanel_Shop(Account account, Label balance, Game featuredGame)
        {
            InitializeComponent();

            this._printedGames = new();

            this._gameController = new();
            this._accountController = new();
            this._foundGames = new();
            this._availableGames = _gameController.ReadAllGames();

            this._user = _accountController.GetAccountByUsername(account.username);

            this._placeholderImage = new BitmapImage(new Uri("/images/default_gamepic.png", UriKind.Relative));

            this._balance = balance;
            this._featuredGame = featuredGame;

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
            featuredGame.Source = new BitmapImage(new Uri(_featuredGame.main_img_link, UriKind.Absolute));
            featuredGameDescription.Text = _featuredGame.description;

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

        public void SearchBarClear(object sender, RoutedEventArgs e)
        {
            if(searchBar.Text.Equals("SEARCH..."))
            {
                searchBar.Text = "";
            }
        }

        public void SearchBarExit(object sender, RoutedEventArgs e)
        {
            if(searchBar.Text.Equals(""))
            {
                searchBar.Text = "SEARCH...";
            }
        }

        public void SearchForGames(object sender, RoutedEventArgs e)
        {
            if (!searchBar.Text.Equals("SEARCH...") && !searchBar.Text.Equals(""))
            {
                _foundGames = _gameController.SearchGame(searchBar.Text.Split(" ")[0]);

                if(_foundGames.Count != 0)
                {
                    searchBox.Children.Clear();

                    searchBox.Height = 80;
                    searchBox.Height *= _foundGames.Count;

                    searchBox.Visibility = Visibility.Visible;
                    searchGameImg.Source = new BitmapImage(new Uri(_foundGames[0].main_img_link, UriKind.Absolute));
                    searchGameTitle.Content = _foundGames[0].name;

                    searchBox.Children.Add(searchBoxBg);
                    searchBox.Children.Add(searchGame_0);

                    if (_foundGames.Count > 1)
                    {
                        int i = 1;
                        double top = searchGame_0.Margin.Top;

                        while (i < _foundGames.Count)
                        {
                            top += 80;

                            Grid grid = new();
                            grid.Name = "searchGame" + i;
                            grid.HorizontalAlignment = HorizontalAlignment.Center;
                            grid.VerticalAlignment = VerticalAlignment.Top;
                            grid.Height = 70;
                            grid.Width = 500;
                            grid.Margin = new Thickness(0, top, 0, 0);

                            Rectangle rectangle = new();
                            rectangle.Name = "searchGameBg_" + i;
                            rectangle.Width = 500;
                            rectangle.Height = 65;
                            rectangle.Fill = Brushes.Transparent;
                            rectangle.AddHandler(MouseEnterEvent, new RoutedEventHandler(ChangeSearchGameBg));
                            rectangle.AddHandler(MouseLeaveEvent, new RoutedEventHandler(RevertSearchGameBg));
                            rectangle.AddHandler(MouseDownEvent, new RoutedEventHandler(OpenSearchGame));

                            Image image = new();
                            image.Source = new BitmapImage(new Uri(_foundGames[i].main_img_link, UriKind.Absolute));
                            image.IsHitTestVisible = false;
                            image.Stretch = Stretch.Fill;
                            image.Height = 60;
                            image.Width = 60;
                            image.Margin = new Thickness(-420, 0, 0, 0);
                            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.Fant);

                            Label label = new();
                            label.Content = _foundGames[i].name;
                            label.IsHitTestVisible = false;
                            label.FontFamily = Application.Current.Resources["Nanotech"] as FontFamily;
                            label.Foreground = Brushes.White;
                            label.FontSize = 25;
                            label.Height = 50;
                            label.Margin = new Thickness(90, 10, 0, 0);

                            grid.Children.Add(rectangle);
                            grid.Children.Add(image);
                            grid.Children.Add(label);

                            searchBox.Children.Add(grid);

                            i++;
                        }
                    }
                } 
                else
                {
                    searchBox.Visibility = Visibility.Hidden;
                }
            }
        }

        public void ChangeSearchGameBg(object sender, RoutedEventArgs e)
        {
            Rectangle rectangle = (Rectangle) sender;

            rectangle.Fill = Brushes.OrangeRed;
        }

        public void RevertSearchGameBg(object sender, RoutedEventArgs e)
        {
            Rectangle rectangle = (Rectangle) sender;

            rectangle.Fill = Brushes.Transparent;
        }

        public void OpenSearchGame(object sender, RoutedEventArgs e)
        {
            Rectangle rectangle = (Rectangle) sender;

            this.NavigationService.Navigate(new ShopPanel_Game(_foundGames[Convert.ToInt32(rectangle.Name.Split("_")[1])], _user, _balance));
        }

        public void HideSearchBox(object sender, RoutedEventArgs e)
        {
            searchBox.Visibility = Visibility.Hidden;

            searchBar.Text = "SEARCH...";
        }

        public void FeaturedGameEnter(object sender, RoutedEventArgs e)
        {
            featuredGameBg.Fill = Brushes.OrangeRed;
        }

        public void FeaturedGameLeave(object sender, RoutedEventArgs e)
        {
            featuredGameBg.Fill = Brushes.Black;
        }

        public void FeaturedGameClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ShopPanel_Game(_featuredGame, _user, _balance));
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
