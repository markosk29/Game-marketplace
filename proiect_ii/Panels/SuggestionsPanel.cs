using proiect_ii.DbClasses;
using System;
using System.Windows;


namespace proiect_ii.Panels
{
    /// <summary>
    /// Panou preferinte jocuri
    /// </summary>
    public partial class SuggestionsPanel : Window
    {
        private RegisterPanel registerPanel;

        public SuggestionsPanel(RegisterPanel registerPanel)
        {
            InitializeComponent();

            this.registerPanel = registerPanel;

            this.Left = registerPanel.Left;
            this.Top = registerPanel.Top;
        }

        private void PreviousButton(Object sender, RoutedEventArgs e)
        {
            registerPanel.Show();

            ResumePanelLocation();

            this.Hide();

        }

        private void NextButton(Object sender, RoutedEventArgs e)
        {
            ////salveaza chestii in DB
        }


        //in cazul apasarii butonului de intoarcere,
        //fereastra anterioara sa fie pe aceeasi pozitie cu cea curenta
        private void ResumePanelLocation()
        {
            registerPanel.Left = this.Left;
            registerPanel.Top = this.Top;
        }
    }
}
