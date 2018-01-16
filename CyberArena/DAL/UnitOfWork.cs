using CyberArena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberArena.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ArenaContext context=new ArenaContext();
        private GenericRepository<Player> playerRepository;
        private GenericRepository<Team> teamRepository;


        public GenericRepository<Player> PlayerRepository
        {
            get
            {
                return this.playerRepository ?? new GenericRepository<Player>(context);
            }
        }

        public GenericRepository<Team> TeamRepository
        {
            get
            {
                return this.teamRepository ?? new GenericRepository<Team>(context);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}