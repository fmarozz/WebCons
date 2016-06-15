using System;

namespace WebCons.Data
{
    public class Movimenti
    {
        public Movimenti()
        {
            this.Presidio=new Presidio();
            this.Progetto=new Progetto();
            this.Risorsa=new Risorsa();
            this.Unita=new Unita();
            this.Fase=new Fase();
            this.Jira = new Jira();
        }
        public virtual int Id { get; set;   } 
        public virtual Risorsa Risorsa { get; set; }
        public virtual DateTime DataCompetenza { get; set; }
        public virtual Progetto Progetto { get; set; }
        public virtual Fase Fase { get; set; }
        public virtual Unita Unita { get; set; }
        public virtual Presidio Presidio { get; set; }
        public virtual Jira Jira { get; set; }
        public virtual Decimal OreAssenza { get; set; }
        public virtual Decimal OreConsuntivate { get; set; }
        public virtual String Nota { get; set; }
    }
}