using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberArena.Models
{
    public class PlayerView
    {
        public int PlayerID { get; set; }

        [Required(ErrorMessage = "Lastname is required"), RegularExpression(@"^[a-zA-z]*$", ErrorMessage = "Only alphabetical characters are allowed")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Firstname is required"), RegularExpression(@"^[a-zA-z]*$", ErrorMessage = "Only alphabetical characters are allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nickname is required"), RegularExpression(@"^[a-zA-z0-9]*$", ErrorMessage = "Only alphabetical characters and numbers are allowed")]
        public string Nickname { get; set; }

        public string Discipline { get; set; }

        [Required(ErrorMessage = "MMR is required")]
        public int MMR { get; set; }

        [Display(Name = "Team")]
        public int TeamID { get; set; }

        public string Team { get; set; }
    }
}