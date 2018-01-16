using CyberArena.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberArena.Repository
{
    public class UnitOfWork : IDisposable
    {
        private ArenaContext context = new ArenaContext();
        private PlayerRepository PlayerRepo;
        private TeamRepository TeamRepo;

        public PlayerRepository PlayerRepository
        {
            get
            {
                return this.PlayerRepo ?? new  PlayerRepository(context);
            }
        }

        public TeamRepository TeamRepository
        {
            get
            {
                return this.TeamRepo ?? new TeamRepository(context);
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