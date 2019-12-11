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
            ContentFrame.Navigate(typeof(HomePage));
        }

        private void BtnHamburger_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void Stores_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(StoresList));
            SplitView.IsPaneOpen = false;
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(AccountPage));
            SplitView.IsPaneOpen = false;
        }

        private void AddStore_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(AddStore));
            SplitView.IsPaneOpen = false;
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(AddStore));
            SplitView.IsPaneOpen = false;
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Events));
            SplitView.IsPaneOpen = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(HomePage));
            SplitView.IsPaneOpen = false;
        }
    }
}
