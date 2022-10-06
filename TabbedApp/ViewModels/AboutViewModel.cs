using System.Windows.Input;

namespace TabbedApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public const string ViewName = "AboutPage";
        public AboutViewModel()
        {
            Title = "Home";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.rocongruppe.de/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}