using proiect_ii.Panels;
using System;
using System.Collections.Generic;
using System.Windows;
using Npgsql;
using proiect_ii.Database.Account;

namespace proiect_ii
{
    /// am descarcar si eu
    /// <summary>
    /// Panou principal
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void NewUserButton(object sender, RoutedEventArgs e)
        {
            RegisterPanel registerPanel = new RegisterPanel();

            registerPanel.Show();

            this.Close();
            
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
    }
}
