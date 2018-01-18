using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberArena.Models
{
    public class Team : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}