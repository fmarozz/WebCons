using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebCons.Data;
using WebCons.WebUI.Models;

namespace WebCons.WebUI
{
    public class MovimentiViewModel
    {
        public int Id { get; set;   }
        [UIHint("DDL")]
        public Risorsa Risorsa { get; set; }
        public DateTime DataCompetenza { get; set; }
        [UIHint("DDL")]
        public Progetto Progetto { get; set; }
        [UIHint("DDL")]
        public Fase Fase { get; set; }
        [UIHint("DDL")]
        public Unita Unita { get; set; }
        [UIHint("DDL")]
        public Presidio Presidio { get; set; }
        public String CodiceJira { get; set; }
        public Decimal OreAssenza { get; set; }
        public Decimal OreConsuntivate { get; set; }
        public String Nota { get; set; }
    }
}