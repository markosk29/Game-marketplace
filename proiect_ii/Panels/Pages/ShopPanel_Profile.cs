using System.Windows.Controls;
using proiect_ii.Database.Account;

namespace proiect_ii.Panels.Pages
{
    /// <summary>
    /// Interaction logic for ShopPanel_Profile.xaml
    /// </summary>
    public partial class ShopPanel_Profile : Page
    {
        public ShopPanel_Profile(Account user)
        {
            InitializeComponent();

            this.ProfileUsernameLabel.Content = user.username;
        }
    }
}
