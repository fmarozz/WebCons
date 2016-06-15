namespace WebCons.Data
{
    public class Jira : AnagraficaBase
    {
        public string TipoSegnalazione { get; set; }
        public string Codice { get; set; }
        public string Segnalante { get; set; }
        public string Priorità { get; set; }
        public string Stato { get; set; }
        //public DateTime Creato { get; set; }
        public string Assegnatario { get; set; }
        public string Risoluzione { get; set; }
        public string Aggiornato { get; set; }

    }
}