using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebCons.Data;

namespace WebCons.WebUI.Models
{
    /// <summary>
    /// aggrega e rende disponibili i dati alla view Main
    /// </summary>
    public class MainModel
    {
        public MainModel()
        {
            this.UserIsLogged = false;
            this.UserOrPasswordIncorrect = false;
        }

        public String Username { get; set; }
        public String Nominativo { get; set; }
        public Boolean UserIsLogged { get; set; }
        public Boolean UserOrPasswordIncorrect { get; set; }
        public IEnumerable<Fase> Fasi { get; set; }
    }
}