using System;
using System.Collections.Generic;
using System.Linq;
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
        
        Utilities util;

        public RegisterPanel()
        {
            InitializeComponent();

            animCompleted = true;

            this._newAccount = new Account();

            this.util = new Utilities();
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
            else if (!util.IsValidEmail(emailTextbox.Text))
            {
                CreateNotification("Invalid email format!", "warning");
            }
            else if (!util.StrongPass(passwordBox.Password))
            {
                CreateNotification("Password is too weak!", "warning");
            }
            else
            {
                if (new AccountController().GetAccountByUsername(usernameTextbox.Text).username == null)
                {
                    if (passwordBox.Password.Equals(confirmPassBox.Password))
                    {
                        _newAccount.username = usernameTextbox.Text;
                        _newAccount.password = passwordBox.Password;
                        _newAccount.email = emailTextbox.Text;
                        _newAccount.balance = 0;

                        QuestionsPanel questionsPanel = new QuestionsPanel(this, _newAccount);
                        questionsPanel.Show();

                        this.Hide();
                    }
                    else
                    {
                        CreateNotification("Passwords must match!", "warning");
                    }
                }
                else
                {
                    CreateNotification("Username is already in use!", "warning");
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

        private void NotificationAnimCompleted(object sender, EventArgs e)
        {
            animCompleted = true;
        }

        /* nu am putut decat daca toate clasele din folder-ul DataBase sunt publice
         * Compiler Error CS0050
        public Account GetAccount()
        {
             return _newAccount;
        }
        */
    }
    
}
