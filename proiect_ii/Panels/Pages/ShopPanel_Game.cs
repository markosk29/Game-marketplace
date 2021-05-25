using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using proiect_ii.Database.Account;
using proiect_ii.Database.Game;

namespace proiect_ii.Panels.Pages
{
    /// <summary>
    /// Interaction logic for ShopPanel_Game.xaml
    /// </summary>
    public partial class ShopPanel_Game : Page
    {
        public static readonly RoutedEvent OpenPromoEvent = EventManager.RegisterRoutedEvent(
            "OpenPromo", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel_Game));
        public static readonly RoutedEvent ClosePromoEvent = EventManager.RegisterRoutedEvent(
            "ClosePromo", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel_Game));
        public static readonly RoutedEvent ConfirmPurchaseEvent = EventManager.RegisterRoutedEvent(
            "ConfirmPurchase", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel_Game));
        public static readonly RoutedEvent FinishConfirmEvent = EventManager.RegisterRoutedEvent(
            "FinishConfirm", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel_Game));
        public static readonly RoutedEvent ResetConfirmEvent = EventManager.RegisterRoutedEvent(
            "ResetConfirm", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel_Game));
        public static readonly RoutedEvent SendNotificationEvent = EventManager.RegisterRoutedEvent(
            "SendNotification", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel_Game));

        private List<BitmapImage> _promoImages;

        private Game _game;
        private Account _user;

        private AccountController _accountController;

        private int _promoIndex;

        private bool _animCompleted;

        private Label _balance;

        public ShopPanel_Game(Game game, Account account, Label balance)
        {
            InitializeComponent();

            this._game = game;
            this._user = account;
            this._accountController = new AccountController();
            this._promoIndex = 0;
            this._animCompleted = true;
            this._balance = balance;

            InitElements();
        }

        private void InitElements()
        {
            gameTitle.Content = _game.name;
            gameCategory1.Content = GetGameCategory(Convert.ToInt32(_game.category1));
            gameCategory2.Content = GetGameCategory(Convert.ToInt32(_game.category2));
            gameCategory3.Content = GetGameCategory(Convert.ToInt32(_game.category3));
            gameDescription.Text = _game.description;
            gamePublisher.Content = _game.publisher;
            gameDeveloper.Content = _game.developer;

            if (_game.price == 0)
            {
                gamePrice.Content = "Free to play";
            }
            else
            {
                gamePrice.Content = _game.price + "€";
            }

            _promoImages = CollectPromoImages();

            AddEventHandlers();

            gamePromo.Source = _promoImages[_promoIndex];

            if (_user != null)
            {
                if (_accountController.GameIsOwned(_user.id, _game.id))
                {
                    buyButton.IsEnabled = false;
                    buyButton.Foreground = Brushes.Black;
                    buyButton.Content = "Owned.";
                }
            }
        }

        private void MovePromoRight(object sender, RoutedEventArgs e)
        {
            string[] promoVideo1 = _game.showoff_video_link_1.Split("/");
            string[] promoVideo2 = _game.showoff_video_link_2.Split("/");

            if (_promoIndex < _promoImages.Count - 1)
            {
                _promoIndex++;

                gamePromo.Source = _promoImages[_promoIndex];
            } 
            else if (_promoIndex == _promoImages.Count - 1)
            {
                _promoIndex++;

                leftPromoButton.Height = 200;
                rightPromoButton.Height = 200;

                promoFullscreenButton.Visibility = Visibility.Hidden;
                gamePromo.Visibility = Visibility.Hidden;

                promoVideo.Visibility = Visibility.Visible;
                promoVideo.Address = promoVideo1[0] + "//" + promoVideo1[2] + "/embed/" + promoVideo1[3].Remove(0, 8) + "?fs=0";
            } 
            else if (_promoIndex == _promoImages.Count)
            {
                _promoIndex++;

                promoVideo.Address = promoVideo2[0] + "//" + promoVideo2[2] + "/embed/" + promoVideo2[3].Remove(0, 8) + "?fs=0";
            }
        }

        private void MovePromoLeft(object sender, RoutedEventArgs e)
        {
            string[] promoVideo1 = _game.showoff_video_link_1.Split("/");

            if (_promoIndex > 0 && _promoIndex <= _promoImages.Count)
            {
                _promoIndex--;

                promoVideo.Address = promoVideo1[0] + "//" + promoVideo1[2] + "/embed/" + promoVideo1[3].Remove(0, 8);

                leftPromoButton.Height = 250;
                rightPromoButton.Height = 250;

                promoFullscreenButton.Visibility = Visibility.Visible;
                gamePromo.Visibility = Visibility.Visible;
                promoVideo.Visibility = Visibility.Hidden;

                gamePromo.Source = _promoImages[_promoIndex];
            } 
            else if (_promoIndex == _promoImages.Count + 1)
            {
                _promoIndex--;

                promoVideo.Address = promoVideo1[0] + "//" + promoVideo1[2] + "/embed/" + promoVideo1[3].Remove(0, 8) +"?fs=0";
            }
        }

        private void ShowPromoButtons(object sender, RoutedEventArgs e)
        {
            leftPromoButton.Visibility = Visibility.Visible;
            rightPromoButton.Visibility = Visibility.Visible;

            if (_promoIndex < _promoImages.Count)
            {
                promoFullscreenButton.Visibility = Visibility.Visible;
            }
        }

        private void HidePromoButtons(object sender, RoutedEventArgs e)
        {
            leftPromoButton.Visibility = Visibility.Hidden;
            rightPromoButton.Visibility = Visibility.Hidden;
            promoFullscreenButton.Visibility = Visibility.Hidden;
        }

        private void OpenFullscreenPromo(object sender, RoutedEventArgs e)
        {
            promoFullscreen.Visibility = Visibility.Visible;

            gamePromoFullscreen.Source = _promoImages[_promoIndex];

            RoutedEventArgs newEventArgs = new RoutedEventArgs(OpenPromoEvent);
            promoFullscreen.RaiseEvent(newEventArgs);
        }

        private void CloseFullscreenPromo(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ClosePromoEvent);
            promoFullscreen.RaiseEvent(newEventArgs);
        }

        private void HideFullscreenPromo(object sender, EventArgs e)
        {
            promoFullscreen.Visibility = Visibility.Hidden;
            closeFullscreenButton.Visibility = Visibility.Hidden;
        }

        private void ShowCloseButton(object sender, EventArgs e)
        {
            closeFullscreenButton.Visibility = Visibility.Visible;
        }

        private void FirstPurchaseButton(object sender, RoutedEventArgs e)
        {
            if (_user != null)
            {
                if (_user.balance >= _game.price)
                {
                    buyButton.Visibility = Visibility.Hidden;
                    confirmPurchaseGrid.Visibility = Visibility.Visible;

                    confirmPrice.Content = "€" + _game.price;

                    RoutedEventArgs newEventArgs = new RoutedEventArgs(ConfirmPurchaseEvent);
                    confirmPurchaseGrid.RaiseEvent(newEventArgs);
                }
                else
                {
                    CreateNotification("Insufficient funds!", "warning");
                }
            }
            else
            {
                CreateNotification("Create an account to purchase a game!", "warning");
            }
        }

        private void CancelPurchase(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(FinishConfirmEvent);
            confirmPurchaseGrid.RaiseEvent(newEventArgs);
        }

        private void ApprovePurchase(object sender, RoutedEventArgs e)
        {
            buyButton.Content = "Owned.";
            buyButton.Foreground = Brushes.Black;
            buyButton.IsEnabled = false;

            RoutedEventArgs newEventArgs = new RoutedEventArgs(FinishConfirmEvent);
            confirmPurchaseGrid.RaiseEvent(newEventArgs);
            
            _user.balance -= _game.price;
            _balance.Content = _user.balance.ToString();

            _accountController.UpdateBalance(_user.id, _user.balance);
            _accountController.AddOwnedGame(_user.id, _game.id);
        }

        private void HideConfirmGrid(object sender, EventArgs e)
        {
            confirmPurchaseGrid.Visibility = Visibility.Hidden;

            RoutedEventArgs newEventArgs = new RoutedEventArgs(ResetConfirmEvent);
            confirmPurchaseGrid.RaiseEvent(newEventArgs);

            buyButton.Visibility = Visibility.Visible;
        }

        private void CreateNotification(string message, string type)
        {
            if (_animCompleted)
            {
                _animCompleted = false;

                NotificationLabel.Content = message;
                NotificationImage.Source = new BitmapImage(new Uri("../../images/" + type + ".png", UriKind.Relative));

                RoutedEventArgs newEventArgs = new RoutedEventArgs(SendNotificationEvent);
                Notification.RaiseEvent(newEventArgs);
            }
        }

        private string GetGameCategory(int category)
        {
            switch (category)
            {
                case 0:
                    return "Horror";
                case 1:
                    return "Action";
                case 2:
                    return "Adventure";
                case 3:
                    return "RPG";
                case 4:
                    return "Platformer";
                case 5:
                    return "Racing";
                case 6:
                    return "Simulation";
                case 7:
                    return "Indie";
                case 8:
                    return "MMO";
                case 9:
                    return "CO-OP";
                case 10:
                    return "Open World";
                case 11:
                    return "Shooter";
                case 12:
                    return "Strategy";
                case 13:
                    return "Casual";
                case 14:
                    return "Sports";
                case 15:
                    return "Sci-Fi";
                case 16:
                    return "VR";
                case 17:
                    return "Post Apocalyptic";
                case 18:
                    return "Survival";
            }

            return "N/A";
        }

        private List<BitmapImage> CollectPromoImages()
        {
            _promoImages = new List<BitmapImage>();

            _promoImages.Add(new BitmapImage(new Uri(_game.showoff_img_link_1, UriKind.Absolute)));
            _promoImages.Add(new BitmapImage(new Uri(_game.showoff_img_link_2, UriKind.Absolute)));
            _promoImages.Add(new BitmapImage(new Uri(_game.showoff_img_link_3, UriKind.Absolute)));
            _promoImages.Add(new BitmapImage(new Uri(_game.showoff_img_link_4, UriKind.Absolute)));
            _promoImages.Add(new BitmapImage(new Uri(_game.showoff_img_link_5, UriKind.Absolute)));

            return _promoImages;
        }

        private void AddEventHandlers()
        {
            gamePromoGrid.AddHandler(MouseEnterEvent, new RoutedEventHandler(ShowPromoButtons));
            gamePromoGrid.AddHandler(MouseLeaveEvent, new RoutedEventHandler(HidePromoButtons));

            rightPromoButton.AddHandler(MouseDownEvent, new RoutedEventHandler(MovePromoRight));
            leftPromoButton.AddHandler(MouseDownEvent, new RoutedEventHandler(MovePromoLeft));

            promoFullscreenButton.AddHandler(MouseDownEvent, new RoutedEventHandler(OpenFullscreenPromo));
            closeFullscreenButton.AddHandler(MouseDownEvent, new RoutedEventHandler(CloseFullscreenPromo));
        }

        public event RoutedEventHandler OpenPromo
        {
            add { AddHandler(OpenPromoEvent, value); }
            remove { RemoveHandler(OpenPromoEvent, value); }
        }

        public event RoutedEventHandler ClosePromo
        {
            add { AddHandler(ClosePromoEvent, value); }
            remove { RemoveHandler(ClosePromoEvent, value); }
        }

        public event RoutedEventHandler ConfirmPurchase
        {
            add { AddHandler(ConfirmPurchaseEvent, value); }
            remove { RemoveHandler(ConfirmPurchaseEvent, value); }
        }

        public event RoutedEventHandler FinishConfirm
        {
            add { AddHandler(FinishConfirmEvent, value); }
            remove { RemoveHandler(FinishConfirmEvent, value); }
        }

        public event RoutedEventHandler ResetConfirm
        {
            add { AddHandler(ResetConfirmEvent, value); }
            remove { RemoveHandler(ResetConfirmEvent, value); }
        }


        public event RoutedEventHandler SendNotification
        {
            add { AddHandler(SendNotificationEvent, value); }
            remove { RemoveHandler(SendNotificationEvent, value); }
        }

        private void NotificationAnimCompleted(object sender, EventArgs e)
        {
            _animCompleted = true;
        }
    }
}
