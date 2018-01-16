using CyberArena.DAL;
using CyberArena.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CyberArena.Repository
{
    public class PlayerRepository: GenericRepository<ArenaContext, Player>
    {
        public PlayerRepository(ArenaContext Acontext)
        {
            context = Acontext;
        }

        public Player FindByID(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.PlayerID == id);
            return query;
        }
    }
}