using proiect_ii.Panels;
using System.Windows;
using System.Windows.Media;
using proiect_ii.Database.Account;

namespace proiect_ii
{
    /// <summary>
    /// Panou principal
    /// </summary>
    public partial class MainWindow : Window
    {
        private AccountController _accountController;

        public MainWindow()
        {
            InitializeComponent();

            this._accountController = new AccountController();
        }


        private void NewUserButton(object sender, RoutedEventArgs e)
        {
            RegisterPanel registerPanel = new RegisterPanel();
            registerPanel.Show();

            this.Close();
            
        }

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            Account user = _accountController.GetUser(usernameBox.Text);

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

        private void NewGameButton(object sender, RoutedEventArgs e)
        {
            NewGamePanel newGamePanel = new NewGamePanel();
            newGamePanel.Show();

            this.Close();
        }
        private void ExitButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ThrowError(int id)
        {
            Color prevColor = new Color();
            prevColor.R = 179;
            prevColor.G = 171;
            prevColor.B = 171;
            prevColor.A = 255;

            if (id == 1)
            {
                passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                usernameBox.BorderBrush = new SolidColorBrush(prevColor);
            } else if (id == 2)
            {
                usernameBox.BorderBrush = new SolidColorBrush(Colors.Red);
                passwordBox.BorderBrush = new SolidColorBrush(prevColor);
            }

            recoverButton.Visibility = Visibility.Visible;
            recoverButton.IsEnabled = true;
        }
    }
}
