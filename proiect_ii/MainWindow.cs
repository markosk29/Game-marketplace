using System;
using proiect_ii.Panels;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using proiect_ii.Database.Account;

namespace proiect_ii
{
    /// <summary>
    /// Panou principal
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly RoutedEvent SendNotificationEvent = EventManager.RegisterRoutedEvent(
            "SendNotification", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MainWindow));

        private AccountController _accountController;

        private bool animCompleted;


        public MainWindow()
        {
            InitializeComponent();

            this._accountController = new AccountController();

            this.animCompleted = true;

        }


        private void NewUserButton(object sender, RoutedEventArgs e)
        {
            RegisterPanel registerPanel = new RegisterPanel();
            registerPanel.Show();

            this.Close();
        }

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            Account user = _accountController.GetAccountByUsername(usernameBox.Text);

            if (user.username == null)
            {
                ThrowError(2);
            }
            else
            {
                if (user.username.Equals(usernameBox.Text))
                {
                    if (user.password.Equals(passwordBox.Password))
                    {
                        Color prevColor = new Color();
                        prevColor.R = 179;
                        prevColor.G = 171;
                        prevColor.B = 171;
                        prevColor.A = 255;

                        passwordBox.BorderBrush = new SolidColorBrush(prevColor);
                        usernameBox.BorderBrush = new SolidColorBrush(prevColor);

                        recoverButton.Visibility = Visibility.Hidden;

                        ShopPanel newShopPanel = new ShopPanel(user);
                        newShopPanel.Show();

                        this.Close();
                    }
                    else
                    {
                        ThrowError(1);
                    }
                }
                else
                {
                    ThrowError(2);
                }
            }
        }

        private void RecoverAccount(object sender, RoutedEventArgs e)
        {
            this.Hide();

            RecoverPanel recoverPanel = new RecoverPanel(this);

            recoverPanel.Show();
        }

        private void ShopButton(object sender, RoutedEventArgs e)
        {
            ShopPanel newShopPanel = new ShopPanel();
            newShopPanel.Show();

            this.Close();
        }
        private void ExitButton(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }

        private void ThrowError(int id)
        {
            if (animCompleted)
            {
                Color prevColor = new Color();
                prevColor.R = 179;
                prevColor.G = 171;
                prevColor.B = 171;
                prevColor.A = 255;

                switch (id)
                {
                    case 1:
                        passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                        usernameBox.BorderBrush = new SolidColorBrush(prevColor);
                        NotificationLabel.Content = "WRONG PASSWORD";
                        break;
                    case 2:
                        usernameBox.BorderBrush = new SolidColorBrush(Colors.Red);
                        passwordBox.BorderBrush = new SolidColorBrush(prevColor);
                        NotificationLabel.Content = "WRONG USERNAME";
                        break;
                }

                recoverButton.Visibility = Visibility.Visible;
                recoverButton.IsEnabled = true;

                NotificationImage.Source = new BitmapImage(new Uri("images/warning.png", UriKind.Relative));

                RoutedEventArgs newEventArgs = new RoutedEventArgs(MainWindow.SendNotificationEvent);
                Notification.RaiseEvent(newEventArgs);

                animCompleted = false;
            }
        }

        public event RoutedEventHandler SendNotification
        {
            add { AddHandler(SendNotificationEvent, value); }
            remove { RemoveHandler(SendNotificationEvent, value); }
        }

        private void NotificationAnimCompleted(object? sender, EventArgs e)
        {
            animCompleted = true;
        }
    }
}
