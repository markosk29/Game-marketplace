using proiect_ii.Panels;
using System;
using System.Collections.Generic;
using System.Windows;
using Npgsql;
using proiect_ii.Database.Account;

namespace proiect_ii
{
    /// <summary>
    /// Panou principal
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


    private void newUserButton(object sender, RoutedEventArgs e)
        {
            RegisterPanel registerPanel = new RegisterPanel();

            registerPanel.Show();

            this.Close();
            
        }
    }
}
