using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using proiect_ii.Database.Account;
using proiect_ii.Database.Game;
using proiect_ii.Panels.Pages;


namespace proiect_ii.Panels
{
    /// <summary>
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class ShopPanel : Window
    {
        public static readonly RoutedEvent SendNotificationEvent = EventManager.RegisterRoutedEvent(
            "SendNotification", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel));
        public static readonly RoutedEvent ShowButtonsEvent = EventManager.RegisterRoutedEvent(
            "ShowButtons", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel));
        public static readonly RoutedEvent HideButtonsEvent = EventManager.RegisterRoutedEvent(
            "HideButtons", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel));
        public static readonly RoutedEvent OpenPaymentEvent = EventManager.RegisterRoutedEvent(
            "OpenPayment", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel));
        public static readonly RoutedEvent ClosePaymentEvent = EventManager.RegisterRoutedEvent(
            "ClosePayment", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel));
        public static readonly RoutedEvent MovePaypointEvent = EventManager.RegisterRoutedEvent(
            "MovePaypoint", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel));
        public static readonly RoutedEvent MoveBackPaypointEvent = EventManager.RegisterRoutedEvent(
            "MoveBackPaypoint", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel));
        public static readonly RoutedEvent MoveVisaEvent = EventManager.RegisterRoutedEvent(
            "MoveVisa", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel));
        public static readonly RoutedEvent MoveBackVisaEvent = EventManager.RegisterRoutedEvent(
            "MoveBackVisa", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShopPanel));

        private List<Game> _availableGames;

        private bool animCompleted;

        private Account _user;

        private AccountController _accountController;
        private GameController _gameController;

        private bool _paymentStage2;

        private Game _featuredGame;

        public ShopPanel()
        {
            InitializeComponent();

            this._gameController = new();
            LoadFeaturedGame();

            this.navigationService.Navigate(new ShopPanel_Shop(_featuredGame), UriKind.Relative);
            StoreLibraryButton.IsHitTestVisible = false;
            StoreLibraryButton.Content = " ";
            StoreProfileButton.IsHitTestVisible = false;
            StoreProfileButton.Content = " ";
            LogoutButton.Content = "Register";

            balanceBg.Visibility = Visibility.Hidden;
            balance.Visibility = Visibility.Hidden;
            euroSign.Visibility = Visibility.Hidden;
            addBalance.Visibility = Visibility.Hidden;

        }

        public ShopPanel(Account account)
        {
            InitializeComponent();

            this._gameController = new();
            LoadFeaturedGame();

            this._accountController = new AccountController();
            this._user = _accountController.GetAccountByUsername(account.username);

            this.navigationService.Navigate(new ShopPanel_Library(_user), UriKind.Relative);

            this.animCompleted = true;
            this._paymentStage2 = false;

            CreateNotification( "Welcome, " + account.username + "!");

            balance.Content = _user.balance.ToString("#.##");
        }

        public void ShowStorePage(object sender, RoutedEventArgs e)
        {
            if (_user != null)
            {
                this.navigationService.Navigate(new ShopPanel_Shop(_user, balance, _featuredGame), UriKind.Relative);
            }
            else
            {
                this.navigationService.Navigate(new ShopPanel_Shop(_featuredGame), UriKind.Relative);
            }
        }

        public void ShowLibraryPage(object sender, RoutedEventArgs e)
        {
            this.navigationService.Navigate(new ShopPanel_Library(_user), UriKind.Relative);
        }

        public void ShowProfilePage(object sender, RoutedEventArgs e)
        {
            this.navigationService.Navigate(new ShopPanel_Profile(_user), UriKind.Relative);
        }

        public void LogoutButtonClick(object sender, RoutedEventArgs e)
        {
            if(_user != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();
            } else
            {
                RegisterPanel registerPanel = new RegisterPanel();
                registerPanel.Show();

                this.Close();
            }
        }

        public void MouseEnterButtonsArea(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ShowButtonsEvent);
            buttonsGrid.RaiseEvent(newEventArgs);
        }

        public void MouseLeaveButtonsArea(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(HideButtonsEvent);
            buttonsGrid.RaiseEvent(newEventArgs);
        }

        public void PaymentButtonClick(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(OpenPaymentEvent);
            paymentGrid.RaiseEvent(newEventArgs);
        }

        public void PaymentCloseButtonClick(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ClosePaymentEvent);
            paymentGrid.RaiseEvent(newEventArgs);

            RoutedEventArgs newEventArgs2 = new RoutedEventArgs(MoveBackPaypointEvent);
            paypoint.RaiseEvent(newEventArgs2);

            RoutedEventArgs newEventArgs3 = new RoutedEventArgs(MoveBackVisaEvent);
            visa.RaiseEvent(newEventArgs3);

            visaLogo.Visibility = Visibility.Visible;
            paypointLogo.Visibility = Visibility.Visible;

            paypointLabel.Visibility = Visibility.Hidden;
            paypointBox.Visibility = Visibility.Hidden;
            paypointButton.Visibility = Visibility.Hidden;
            visaBox1.Visibility = Visibility.Hidden;
            visaBox2.Visibility = Visibility.Hidden;
            visaBox3.Visibility = Visibility.Hidden;
            visaBox4.Visibility = Visibility.Hidden;
            visaBox5.Visibility = Visibility.Hidden;
            visaLabel1.Visibility = Visibility.Hidden;
            visaLabel2.Visibility = Visibility.Hidden;
            visaLabel3.Visibility = Visibility.Hidden;
            visaLabel4.Visibility = Visibility.Hidden;
            visaSeparator.Visibility = Visibility.Hidden;
            visaButton.Visibility = Visibility.Hidden;

            paypointBox.Text = "";
            visaBox1.Text = "";
            visaBox2.Text = "";
            visaBox3.Text = "";
            visaBox4.Text = "";
            visaBox5.Text = "";

            _paymentStage2 = false;
        }

        public void PaymentBackButton(object sender, RoutedEventArgs e)
        {
            if (visaLogo.Visibility == Visibility.Hidden)
            {
                RoutedEventArgs newEventArgs = new RoutedEventArgs(MoveBackPaypointEvent);
                paypoint.RaiseEvent(newEventArgs);

                visaLogo.Visibility = Visibility.Visible;
                paypointLogo.Visibility = Visibility.Visible;

                paypointLabel.Visibility = Visibility.Hidden;
                paypointBox.Visibility = Visibility.Hidden;
                paypointButton.Visibility = Visibility.Hidden;

                paypointBox.Text = "";
            }
            else
            {
                RoutedEventArgs newEventArgs = new RoutedEventArgs(MoveBackVisaEvent);
                visa.RaiseEvent(newEventArgs);

                visaLogo.Visibility = Visibility.Visible;
                paypointLogo.Visibility = Visibility.Visible;

                visaBox1.Visibility = Visibility.Hidden;
                visaBox2.Visibility = Visibility.Hidden;
                visaBox3.Visibility = Visibility.Hidden;
                visaBox4.Visibility = Visibility.Hidden;
                visaBox5.Visibility = Visibility.Hidden;
                visaLabel1.Visibility = Visibility.Hidden;
                visaLabel2.Visibility = Visibility.Hidden;
                visaLabel3.Visibility = Visibility.Hidden;
                visaLabel4.Visibility = Visibility.Hidden;
                visaSeparator.Visibility = Visibility.Hidden;
                visaButton.Visibility = Visibility.Hidden;

                visaBox1.Text = "";
                visaBox2.Text = "";
                visaBox3.Text = "";
                visaBox4.Text = "";
                visaBox5.Text = "";
            }

            _paymentStage2 = false;
        }

        public void PaypointButtonClick(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MovePaypointEvent);
            paypoint.RaiseEvent(newEventArgs);

            visaLogo.Visibility = Visibility.Hidden;
            paypointLabel.Visibility = Visibility.Visible;
            paypointBox.Visibility = Visibility.Visible;
            paypointButton.Visibility = Visibility.Visible;

            _paymentStage2 = true;
        }

        public void VisaButtonClick(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MoveVisaEvent);
            visa.RaiseEvent(newEventArgs);

            paypointLogo.Visibility = Visibility.Hidden;
            visaBox1.Visibility = Visibility.Visible;
            visaBox2.Visibility = Visibility.Visible;
            visaBox3.Visibility = Visibility.Visible;
            visaBox4.Visibility = Visibility.Visible;
            visaBox5.Visibility = Visibility.Visible;
            visaLabel1.Visibility = Visibility.Visible;
            visaLabel2.Visibility = Visibility.Visible;
            visaLabel3.Visibility = Visibility.Visible;
            visaLabel4.Visibility = Visibility.Visible;
            visaSeparator.Visibility = Visibility.Visible;
            visaButton.Visibility = Visibility.Visible;

            _paymentStage2 = true;
        }

        public void VisaMouseEnter(object sender, RoutedEventArgs e)
        {
            if (!_paymentStage2)
            {
                paymentUnderline.Margin = new Thickness(-200, 170, 0, 0);
                paymentUnderline.Visibility = Visibility.Visible;
            }
        }

        public void VisaMouseLeave(object sender, RoutedEventArgs e)
        {
            paymentUnderline.Visibility = Visibility.Hidden;
        }

        public void PaypointMouseEnter(object sender, RoutedEventArgs e)
        {
            if (!_paymentStage2)
            {
                paymentUnderline.Margin = new Thickness(200, 170, 0, 0);
                paymentUnderline.Visibility = Visibility.Visible;
            }
        }

        public void PaypointMouseLeave(object sender, RoutedEventArgs e)
        {
            paymentUnderline.Visibility = Visibility.Hidden;
        }

        public void AddMoneyFromPaypoint(object sender, RoutedEventArgs e)
        {
            if (paypointBox.Text.Length == 20)
            {
                double newBalance = Convert.ToDouble(balance.Content) + 50;

                balance.Content = newBalance.ToString("#.##");

                _accountController.UpdateBalance(_user.id, newBalance);

                paypointBox.Text = "";

                CreateNotification("50€ has been added to your account!");
            }
        }

        public void AddMoneyFromVisa(object sender, RoutedEventArgs e)
        {
            Regex numberRegex = new Regex("[^0-9]+");

            if (visaBox1.Text.Length == 16 &&
                visaBox2.Text.Length == 3 &&
                visaBox3.Text.Length == 2 &&
                visaBox4.Text.Length == 2 &&
                visaBox5.Text.Length > 0 &&
                !numberRegex.IsMatch(visaBox1.Text) &&
                !numberRegex.IsMatch(visaBox2.Text) &&
                !numberRegex.IsMatch(visaBox3.Text) &&
                !numberRegex.IsMatch(visaBox4.Text) &&
                !numberRegex.IsMatch(visaBox5.Text))
            {
                double newBalance = Convert.ToDouble(balance.Content) + Convert.ToDouble(visaBox5.Text);

                balance.Content = newBalance.ToString("#.##");

                _accountController.UpdateBalance(_user.id, newBalance);

                CreateNotification(visaBox5.Text+ "€ has been added to your account!");

                visaBox1.Text = "";
                visaBox2.Text = "";
                visaBox3.Text = "";
                visaBox4.Text = "";
                visaBox5.Text = "";
            }
        }

        private void LoadFeaturedGame()
        {
            _availableGames = _gameController.ReadAllGames();

            Random rand = new();

            int index = rand.Next(_availableGames.Count - 1);

            _featuredGame = _availableGames[index];
        }

        private void CreateNotification(string message)
        {
            if (animCompleted)
            {
                animCompleted = false;

                NotificationLabel.Content = message;
                NotificationImage.Source = new BitmapImage(new Uri("../images/success.png", UriKind.Relative));

                RoutedEventArgs newEventArgs = new RoutedEventArgs(SendNotificationEvent);
                Notification.RaiseEvent(newEventArgs);
            }
        }

        public event RoutedEventHandler SendNotification
        {
            add { AddHandler(SendNotificationEvent, value); }
            remove { RemoveHandler(SendNotificationEvent, value); }
        }

        public event RoutedEventHandler ShowButtons
        {
            add { AddHandler(ShowButtonsEvent, value); }
            remove { RemoveHandler(ShowButtonsEvent, value); }
        }

        public event RoutedEventHandler HideButtons
        {
            add { AddHandler(HideButtonsEvent, value); }
            remove { RemoveHandler(HideButtonsEvent, value); }
        }

        public event RoutedEventHandler OpenPayment
        {
            add { AddHandler(OpenPaymentEvent, value); }
            remove { RemoveHandler(OpenPaymentEvent, value); }
        }

        public event RoutedEventHandler ClosePayment
        {
            add { AddHandler(ClosePaymentEvent, value); }
            remove { RemoveHandler(ClosePaymentEvent, value); }
        }

        public event RoutedEventHandler MovePaypoint
        {
            add { AddHandler(MovePaypointEvent, value); }
            remove { RemoveHandler(MovePaypointEvent, value); }
        }

        public event RoutedEventHandler MoveBackPaypoint
        {
            add { AddHandler(MoveBackPaypointEvent, value); }
            remove { RemoveHandler(MoveBackPaypointEvent, value); }
        }

        public event RoutedEventHandler MoveVisa
        {
            add { AddHandler(MoveVisaEvent, value); }
            remove { RemoveHandler(MoveVisaEvent, value); }
        }

        public event RoutedEventHandler MoveBackVisa
        {
            add { AddHandler(MoveBackVisaEvent, value); }
            remove { RemoveHandler(MoveBackVisaEvent, value); }
        }

        private void NotificationAnimCompleted(object sender, EventArgs e)
        {
            animCompleted = true;
        }
    }
}
