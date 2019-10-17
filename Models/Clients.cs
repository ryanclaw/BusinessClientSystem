using System.Collections.Generic;


namespace BusinessClientSystem.Models
{
    public class Clients 
    {
        public int id {get; set;}
        public string salutation {get; set;}
        public string firstname {get; set;}
        public string lastname {get; set;}
        public string gender {get; set;}
        public string contacttype {get; set;}
        public string dateofbirth {get; set;}
        public string address1 {get; set;}
        public string address2 {get; set;}
        public int phone1 {get; set;}
        public int phone2 {get; set;}
        public string email {get; set;}
        public string product {get; set;}
    }
}
