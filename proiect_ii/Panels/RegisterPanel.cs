using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using proiect_ii.Database.Account;


namespace proiect_ii.Panels
{
    /// <summary>
    /// Panoul de inregistrare pentru utilizatori noi
    /// </summary>
    public partial class RegisterPanel : Window
    {
        public static readonly RoutedEvent SendNotificationEvent = EventManager.RegisterRoutedEvent(
            "SendNotification", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RegisterPanel));

        private bool animCompleted;

        Account _newAccount;

        public RegisterPanel()
        {
            InitializeComponent();

            animCompleted = true;

            this._newAccount = new Account();
        }

        private void nextButton(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(usernameTextbox.Text)
                || String.IsNullOrEmpty(confirmPassBox.Password)
                || String.IsNullOrEmpty(passwordBox.Password)
                || String.IsNullOrEmpty(emailTextbox.Text))
            {
                CreateNotification("One or more fields are empty!", "warning");
            }
            else
            {
                if (passwordBox.Password.Equals(confirmPassBox.Password))
                {
                    _newAccount.username = usernameTextbox.Text;
                    _newAccount.password = passwordBox.Password;
                    _newAccount.email = emailTextbox.Text;

                    QuestionsPanel questionsPanel = new QuestionsPanel(this, _newAccount);
                    questionsPanel.Show();

                    this.Hide();
                }
                else
                {
                    CreateNotification("Passwords must match!", "warning");
                }
            }
        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainl = new MainWindow();
            mainl.Show();

            this.Close();
        }

        private void CreateNotification(string message, string type)
        {
            if (animCompleted)
            {
                animCompleted = false;

                NotificationLabel.Content = message;
                NotificationImage.Source = new BitmapImage(new Uri("../images/" + type + ".png", UriKind.Relative));

                RoutedEventArgs newEventArgs = new RoutedEventArgs(SendNotificationEvent);
                Notification.RaiseEvent(newEventArgs);
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
