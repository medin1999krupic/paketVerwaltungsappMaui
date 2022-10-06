using DevExpress.Maui.DataForm;
using TabbedApp.Models;

namespace TabbedApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        public const string ViewName = "NewItemPage";


        string titel;
        string typ;
        string annahmeDurch;
        string vonAbsenderAdresse;
        string anEmpfaengerAdresse;
        string lieferUnternehmen;
        string zustand;
        string gewicht;
        string stueckzahl;
        string datumUhrzeit;
        string aktuellerStatus;
        string description;

        public NewItemViewModel()
        {
            //DeleteCommand = new Command(OnDelete, ValidateDelete);
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public string Titel
        {
            get => this.titel;
            set => SetProperty(ref this.titel, value);
        }
        public string Typ
        {
            get => this.typ;
            set => SetProperty(ref this.typ, value);
        }
        public string AnnahmeDurch
        {
            get => this.annahmeDurch;
            set => SetProperty(ref this.annahmeDurch, value);
        }
        public string VonAbsenderAdresse
        {
            get => this.vonAbsenderAdresse;
            set => SetProperty(ref this.vonAbsenderAdresse, value);
        }
        public string AnEmpfaengerAdresse
        {
            get => this.anEmpfaengerAdresse;
            set => SetProperty(ref this.anEmpfaengerAdresse, value);
        }
        public string LieferUnternehmen
        {
            get => this.lieferUnternehmen;
            set => SetProperty(ref this.lieferUnternehmen, value);
        }
        public string Zustand
        {
            get => this.zustand;
            set => SetProperty(ref this.zustand, value);
        }
        public string Gewicht
        {
            get => this.gewicht;
            set => SetProperty(ref this.gewicht, value);
        }
        public string Stueckzahl
        {
            get => this.stueckzahl;
            set => SetProperty(ref this.stueckzahl, value);
        }
        public string DatumUhrzeit
        {
            get => this.datumUhrzeit;
            set => SetProperty(ref this.datumUhrzeit, value);
        }
        public string AktuellerStatus
        {
            get => this.aktuellerStatus;
            set => SetProperty(ref this.aktuellerStatus, value);
        }
        public string Description
        {
            get => this.description;
            set => SetProperty(ref this.description, value);
        }


        [DataFormDisplayOptions(IsVisible = false)]
        public Command SaveCommand { get; }

        [DataFormDisplayOptions(IsVisible = false)]
        public Command CancelCommand { get; }


        bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(this.titel)
                && !String.IsNullOrWhiteSpace(this.typ)
                && !String.IsNullOrWhiteSpace(this.annahmeDurch)
                && !String.IsNullOrWhiteSpace(this.vonAbsenderAdresse)
                && !String.IsNullOrWhiteSpace(this.anEmpfaengerAdresse)
                && !String.IsNullOrWhiteSpace(this.lieferUnternehmen)
                && !String.IsNullOrWhiteSpace(this.zustand)
                && !String.IsNullOrWhiteSpace(this.gewicht)
                && !String.IsNullOrWhiteSpace(this.stueckzahl)
                && !String.IsNullOrWhiteSpace(this.datumUhrzeit)
                && !String.IsNullOrWhiteSpace(this.aktuellerStatus)
                && !String.IsNullOrWhiteSpace(this.description);
            

        }


        async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Navigation.GoBackAsync();
        }

        async void OnDelete()
        {
            // This will pop the current page off the navigation stack
            /*await await DataStore.DeleteItemAsync()*/;
        }

        async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Titel = Titel,
                Typ = Typ,
                AnnahmeDurch = AnnahmeDurch,
                VonAbsenderAdresse = VonAbsenderAdresse,
                AnEmpfaengerAdresse = AnEmpfaengerAdresse,
                LieferUnternehmen = LieferUnternehmen,
                Zustand = Zustand,
                Gewicht = Gewicht,
                Stueckzahl = Stueckzahl,
                DatumUhrzeit = DatumUhrzeit,
                AktuellerStatus = AktuellerStatus,
                Description = Description,
                
            };

            await DataStore.AddItemAsync(newItem);
            

            // This will pop the current page off the navigation stack
            await Navigation.GoBackAsync();
        }
    }
}