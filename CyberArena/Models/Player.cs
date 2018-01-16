using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberArena.Models
{
    public class Player
    {
        public int PlayerID { get; set; }        
        public string LastName { get; set; }        
        public string FirstName { get; set; }        
        public string Nickname { get; set; }
        public string Discipline { get; set; }        
        public int MMR { get; set; }        
        public int TeamID { get; set; }
                
    }
}