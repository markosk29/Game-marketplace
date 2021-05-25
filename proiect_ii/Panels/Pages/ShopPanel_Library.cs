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

        public ShopPanel_Library(Account account)
        {
            InitializeComponent();

            this._placeholderImage = new BitmapImage(new Uri("/images/default_gamepic.png", UriKind.Relative));
            this._accountController = new AccountController();
            this._gameController = new GameController();
            this._printedGames = new List<Image>();
            this._user = account;

            _ownedGames = GetOwnedGames();

            ShowAllOwnedGames();
        }

        private void ShowAllOwnedGames()
        {
            double left = -1000;
            double top = 50;

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

            int k = 1;
            int j = 1;

            int maxColumns;

            if (_ownedGames.Count < 5)
            {
                maxColumns = _ownedGames.Count;
            }
            else
            {
                maxColumns = 5;
            }

            int maxRows = 1;

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
                top += 200;
            }
        }

        private List<Game> GetOwnedGames()
        {
            List<int> ownedGamesIds = _accountController.GetOwnedGames(_user.id);

            _ownedGames = new List<Game>();

            foreach (int id in ownedGamesIds)
            {
                _ownedGames.Add(_gameController.GetGameById(id));
            }

            return _ownedGames;
        }
    }
}
