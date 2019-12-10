using FieldsApp.View;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FieldsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void BtnHamburger_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void Stores_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(StoresList));
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(AccountPage));
        }

        private void AddStore_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(AddStore));
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(AddStore));
        }
    }
}
