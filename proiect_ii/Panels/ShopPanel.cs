using System;
using System.Windows;
using System.Windows.Media.Imaging;
using proiect_ii.Database.Account;
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

        private bool animCompleted;

        private Account _user;

        public ShopPanel()
        {
            InitializeComponent();

            navigationService.Navigate(new ShopPanel_Shop());
            StoreLibraryButton.IsEnabled = false;
            StoreLibraryButton.Content = " ";
            StoreProfileButton.IsEnabled = false;
            StoreProfileButton.Content = " ";

            registerButton.Visibility = Visibility.Visible;
            balanceBg.Visibility = Visibility.Hidden;
            balance.Visibility = Visibility.Hidden;
            euroSign.Visibility = Visibility.Hidden;
            addBalance.Visibility = Visibility.Hidden;

        }

        public ShopPanel(Account account)
        {
            InitializeComponent();

            this._user = account;

            navigationService.Navigate(new ShopPanel_Library(_user));

            animCompleted = true;

            CreateNotification( "Welcome, " + account.username + "!");

            balance.Content = _user.balance.ToString("#.##");
        }

        public void ShowStorePage(object sender, RoutedEventArgs e)
        {
            if (_user != null)
            {
                this.navigationService.Navigate(new ShopPanel_Shop(_user, balance), UriKind.Relative);
            }
            else
            {
                this.navigationService.Navigate(new ShopPanel_Shop(), UriKind.Relative);
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

        public void RegisterNewUser(object sender, RoutedEventArgs e)
        {
            RegisterPanel registerPanel = new RegisterPanel();
            registerPanel.Show();
            
            this.Close();
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

        private void NotificationAnimCompleted(object sender, EventArgs e)
        {
            animCompleted = true;
        }
    }
}
