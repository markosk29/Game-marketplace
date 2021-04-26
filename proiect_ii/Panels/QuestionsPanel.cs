using System;
using System.Windows;
using System.Windows.Media.Imaging;
using proiect_ii.Database.Account;


namespace proiect_ii.Panels
{
    /// <summary>
    /// Interaction logic for QuestionsPanel.xaml
    /// </summary>
    public partial class QuestionsPanel : Window
    {
        public static readonly RoutedEvent SendNotificationEvent = EventManager.RegisterRoutedEvent(
            "SendNotification", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(QuestionsPanel));

        private bool animCompleted;

        private RegisterPanel _registerPanel;
        private Account _newAccount;

        public QuestionsPanel(RegisterPanel registerPanel, Account newAccount)
        {
            InitializeComponent();

            this._registerPanel = registerPanel;
            this._newAccount = newAccount;

            this.Left = registerPanel.Left;
            this.Top = registerPanel.Top;

            animCompleted = true;

            errorLabel.Content = "";
        }

        public void NextButton(object sender, RoutedEventArgs e)
        {
            if (firstQuestion.SelectedIndex >= 0 &&
                secondQuestion.SelectedIndex >= 0 &&
                thirdQuestion.SelectedIndex >= 0)
            {
                if (!String.IsNullOrEmpty(firstAnswer.Text) &&
                    !String.IsNullOrEmpty(secondAnswer.Text) &&
                    !String.IsNullOrEmpty(thirdAnswer.Text) &&
                    !String.IsNullOrWhiteSpace(firstAnswer.Text) &&
                    !String.IsNullOrWhiteSpace(secondAnswer.Text) &&
                    !String.IsNullOrWhiteSpace(thirdAnswer.Text))
                {
                    if (firstQuestion.SelectedIndex != secondQuestion.SelectedIndex &&
                        firstQuestion.SelectedIndex != thirdQuestion.SelectedIndex &&
                        secondQuestion.SelectedIndex != thirdQuestion.SelectedIndex)
                    {
                        _newAccount.securityQuestion1 = firstQuestion.Text;
                        _newAccount.securityAnswer1 = firstAnswer.Text;
                        _newAccount.securityQuestion2 = secondQuestion.Text;
                        _newAccount.securityAnswer2 = secondAnswer.Text;
                        _newAccount.securityQuestion3 = thirdQuestion.Text;
                        _newAccount.securityAnswer3 = thirdAnswer.Text;

                        SuggestionsPanel suggestionsPanel = new SuggestionsPanel(this, _newAccount);
                        suggestionsPanel.Show();

                        errorLabel.Content = " ";

                        this.Hide();

                    }
                    else
                    {
                        SendError(3);
                    }
                }
                else
                {
                    SendError(2);
                }
            }
            else
            {
                SendError(1);
            }
        }

        public void PreviousButton(object sender, RoutedEventArgs e)
        {
            _registerPanel.Show();

            ResumePanelLocation();

            this.Hide();
        }

        private void SendError(int id)
        {
            switch (id)
            {
                case 1:
                    CreateNotification("Please select 3 different questions!", "warning");
                    break;
                case 2:
                    CreateNotification("Please fill all answer boxes!", "warning");
                    break;
                case 3:
                    CreateNotification("The questions must be different!", "warning");
                    break;
            }
        }

        private void ResumePanelLocation()
        {
            _registerPanel.Left = this.Left;
            _registerPanel.Top = this.Top;
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
