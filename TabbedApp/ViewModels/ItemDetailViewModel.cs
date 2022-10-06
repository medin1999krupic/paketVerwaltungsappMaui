using System.Web;

namespace TabbedApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel, IQueryAttributable
    {
        public const string ViewName = "ItemDetailPage";

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
        

        public string Id { get; set; }

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
        

        public async Task LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Titel = item.Titel;
                Typ = item.Typ;
                AnnahmeDurch = item.AnnahmeDurch;
                VonAbsenderAdresse = item.VonAbsenderAdresse;
                AnEmpfaengerAdresse = item.AnEmpfaengerAdresse;
                LieferUnternehmen = item.LieferUnternehmen;
                Zustand = item.Zustand;
                Gewicht = item.Gewicht;
                Stueckzahl = item.Stueckzahl;
                DatumUhrzeit = item.DatumUhrzeit;
                AktuellerStatus = item.AktuellerStatus;
                Description = item.Description;
                
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Failed to Load Item");
            }
        }

        public override async Task InitializeAsync(object parameter)
        {
            await LoadItemId(parameter as string);
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            string id = HttpUtility.UrlDecode(query["id"] as string);
            await LoadItemId(id);
        }
    }
}