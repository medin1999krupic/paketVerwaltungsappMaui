using System.Runtime.CompilerServices;
using TabbedApp.ViewModels;

namespace TabbedApp.Views
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}