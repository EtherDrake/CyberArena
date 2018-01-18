using CyberArena.DAL;
using CyberArena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberArena.Repository
{
    public class TeamRepository:GenericRepository<ArenaContext, Team>
    {
        public TeamRepository(ArenaContext Acontext)
        {
            context = Acontext;
        }
    }
}