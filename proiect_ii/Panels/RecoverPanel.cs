using System.Windows;

namespace proiect_ii.Panels
{
    /// <summary>
    /// Interaction logic for RecoverPanel.xaml
    /// </summary>
    public partial class RecoverPanel : Window
    {

        private MainWindow _mainWindow;

        public RecoverPanel(MainWindow mainWindow)
        {
            InitializeComponent();

            this._mainWindow = mainWindow;
        }

        public void Return(object sender, RoutedEventArgs e)
        {
            this.Hide();

            _mainWindow.Show();
        }
    }
}
