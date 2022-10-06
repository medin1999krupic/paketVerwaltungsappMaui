namespace TabbedAppVorlage.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Titel { get; set; }
        public string Typ { get; set; }
        public string AnnahmeDurch { get; set; }
        public string VonAbsenderAdresse { get; set; }
        public string AnEmpfaengerAdresse { get; set; }
        public string LieferUnternehmen { get; set; }
        public string Zustand { get; set; }
        public string Gewicht { get; set; }
        public string Stueckzahl { get; set; }
        public string DatumUhrzeit { get; set; }
        public string AktuellerStatus { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Value { get; set; }
    }
}