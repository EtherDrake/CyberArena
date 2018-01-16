using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberArena.Models
{
    public class PlayerViewModel
    {
        public int PlayerID { get; set; }
        [Required(ErrorMessage = "Surname is required"), RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only alphabetical characters allowed")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Firstname is required"), RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only alphabetical characters allowed")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nickname is required"), RegularExpression("@^[a-zA-Z0-9_]*$", ErrorMessage = "Only alphabetical characters and numbers allowed")]
        public string Nickname { get; set; }
        public string Discipline { get; set; }
        [Required(ErrorMessage = "Discipline is required"), RegularExpression("@^[a-zA-Z0-9_]*$", ErrorMessage = "Only alphabetical characters and numbers allowed")]
        public int MMR { get; set; }
        public int TeamID { get; set; }
        public string Team { get; set; }
    }
}