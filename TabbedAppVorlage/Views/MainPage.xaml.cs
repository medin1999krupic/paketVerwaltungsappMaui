using System.Runtime.CompilerServices;
using TabbedAppVorlage.ViewModels;

namespace TabbedAppVorlage.Views
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