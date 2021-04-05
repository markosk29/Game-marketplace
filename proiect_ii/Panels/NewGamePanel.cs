using System;
using System.Windows;
using proiect_ii.Database.Game;


namespace proiect_ii.Panels
{
    /// <summary>
    /// Interaction logic for NewGamePanel.xaml
    /// </summary>
    public partial class NewGamePanel : Window
    {
        private GameController gameController;
        private Game game;

        public NewGamePanel()
        {
            InitializeComponent();

            this.gameController = new GameController();
            this.game = new Game();
        }

        public void SubmitGame(Object sender, RoutedEventArgs e)
        {
            game.name = gameNameTextbox.Text;
            game.developer = gameDevTextbox.Text;
            game.publisher = gamePublisherTextbox.Text;
            game.category1 = gameCategory1.Text;
            game.category2 = gameCategory2.Text;
            game.category3 = gameCategory3.Text;
            game.description = gameDescriptionTextbox.Text;

            gameController.AddToDatabase(game);
        }
    }
}
