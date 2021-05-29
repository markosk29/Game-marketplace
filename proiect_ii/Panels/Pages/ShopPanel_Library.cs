using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using proiect_ii.Database.Account;
using proiect_ii.Database.Game;

namespace proiect_ii.Panels.Pages
{
    /// <summary>
    /// Interaction logic for ShopPanel_Library.xaml
    /// </summary>
    public partial class ShopPanel_Library : Page
    {
        private List<Game> _ownedGames;
        private List<Image> _printedGames;

        private Account _user;

        private AccountController _accountController;
        private GameController _gameController;

        private BitmapImage _placeholderImage;

        private int _forwardIndex;
        private int _backwardIndex;

        public ShopPanel_Library(Account account)
        {
            InitializeComponent();

            this._placeholderImage = new BitmapImage(new Uri("/images/default_gamepic.png", UriKind.Relative));
            this._accountController = new();
            this._gameController = new();
            this._printedGames = new();
            this._user = account;
            this._forwardIndex = 0;
            this._backwardIndex = 0;

            _ownedGames = GetOwnedGames();

            ShowAllOwnedGames();
        }

        private void ShowAllOwnedGames()
        {
            if(_ownedGames.Count > 0)
            {
                libraryEmptyMessage.Visibility = Visibility.Hidden;
                libraryEmptyMessage2.Visibility = Visibility.Hidden;
            } else
            {
                libraryTitle.Visibility = Visibility.Hidden;
            }

            double left = -1000;
            double top = 75;

            if (_ownedGames.Count >= 1)
            {
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
                        new BitmapImage(new Uri(_ownedGames[0].main_img_link, UriKind.Absolute));
                }
                catch (Exception e)
                {
                    _printedGames[0].Source = _placeholderImage;
                }

                RenderOptions.SetBitmapScalingMode(_printedGames[0], BitmapScalingMode.Fant);

                libraryPage.Children.Add(_printedGames[0]);
            }

            int k = 1;
            int j = 1;

            int maxColumns;
            int maxRows = 1;

            if (_ownedGames.Count > 1)
            {
                if (_ownedGames.Count < 5)
                {
                    maxColumns = _ownedGames.Count;
                }
                else
                {
                    maxColumns = 5;
                }

                if (_ownedGames.Count > 5)
                {
                    maxRows = 2;
                }


                for (int i = 0; i < maxRows; i++)
                {
                    while (j < maxColumns)
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
                                new BitmapImage(new Uri(_ownedGames[k].main_img_link, UriKind.Absolute));
                        }
                        catch (Exception e)
                        {
                            _printedGames[k].Source = _placeholderImage;
                        }

                        RenderOptions.SetBitmapScalingMode(_printedGames[k], BitmapScalingMode.Fant);

                        libraryPage.Children.Add(_printedGames[k]);

                        k++;
                        j++;
                    }

                    j = 0;

                    left = -1499;

                    top += 300;
                }
            }

            _forwardIndex = k;

            HidePlaceholders();
        }

        private List<Game> GetOwnedGames()
        {
            List<int> ownedGamesIds = _accountController.GetOwnedGames(_user.id);

            List<Game> games = new List<Game>();

            foreach (int id in ownedGamesIds)
            {
                games.Add(_gameController.GetGameById(id));
            }

            return games;
        }

        public void NextButtonClick(object sender, RoutedEventArgs e)
        {
            int i = _forwardIndex;

            if(_ownedGames.Count > 10)
            {
                foreach (var games in _printedGames)
                {
                    if (i < _ownedGames.Count)
                    {
                        games.Source = new BitmapImage(new Uri(_ownedGames[i].main_img_link, UriKind.Absolute));

                        i++;
                    }
                    else
                    {
                        games.Source = _placeholderImage;
                    }
                }
                _backwardIndex = _forwardIndex;

                HidePlaceholders();
            }

            if(_ownedGames.Count > i)
            {
                _forwardIndex = i;
            }
        }

        public void PreviousButtonClick(object sender, RoutedEventArgs e)
        {
            int i = _backwardIndex - 10;

            if (i >= 0)
            {
                foreach (var games in _printedGames)
                {
                    games.Visibility = Visibility.Visible;

                    games.Source = new BitmapImage(new Uri(_ownedGames[i].main_img_link, UriKind.Absolute));

                    i++;

                }
                _forwardIndex = _backwardIndex;

                _backwardIndex = i - 10;
            }
        }

        private void HidePlaceholders()
        {
            foreach(var game in _printedGames) {
                if(game.Source == _placeholderImage)
                {
                    game.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
