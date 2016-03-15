using System;

namespace WebCons.Data
{
    public class UserParametersDTO
    {
        public int Id { get; set; }
        public String User { get; set; }
        public String Pass { get; set; }
        public String Nome { get; set; }
        public String Cognome { get; set; }
        public Boolean IsAdmin { get; set; } 
        public Boolean UserIsLogged { get; set; }  
    }
}
