using System;
using System.Windows;
using proiect_ii.Database.Account;
using proiect_ii.Panels.Pages;


namespace proiect_ii.Panels
{
    /// <summary>
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class ShopPanel : Window
    {
        public ShopPanel()
        {
            InitializeComponent();

            navigationService.Navigate(new ShopPanel_Shop());
            StoreLibraryButton.IsEnabled = false;
            StoreLibraryButton.Content = " ";

            registerButton.Visibility = Visibility.Visible;

            welcomeLabel.Content =
                "Hello! You are currently viewing the store as a Guest, please register to have full access!";
        }

        public ShopPanel(Account account)
        {
            InitializeComponent();

            navigationService.Navigate(new ShopPanel_Library());

            welcomeLabel.Content = "Welcome, " + account.username + "!";
        }

        public void ShowStorePage(object sender, RoutedEventArgs e)
        {
            this.navigationService.Navigate(new ShopPanel_Shop(), UriKind.Relative);
        }

        public void ShowLibraryPage(object sender, RoutedEventArgs e)
        {
            this.navigationService.Navigate(new ShopPanel_Library(), UriKind.Relative);
        }

        public void RegisterNewUser(object sender, RoutedEventArgs e)
        {
            RegisterPanel registerPanel = new RegisterPanel();
            registerPanel.Show();
            
            this.Close();
        }
    }
}
