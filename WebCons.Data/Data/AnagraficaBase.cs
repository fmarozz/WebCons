using System;

namespace WebCons.Data
{
    public  class AnagraficaBase
    {
        public virtual int Id { get; set; }
        public virtual string Descrizione { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            var addr = obj as AnagraficaBase;
            if (addr == null)
                return false;

            return addr.Id == this.Id && addr.Descrizione == this.Descrizione; //and so on..
        }
    }
}