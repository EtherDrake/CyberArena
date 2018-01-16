using CyberArena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberArena.DAL
{
    public interface IPlayerRepository : IDisposable
    {
        IEnumerable<Player> GetPlayers();
        Player GetPlayerByID(int playerId);
        void InsertPlayer(Player player);
        void DeletePlayer(int playerID);
        void UpdatePlayer(Player player);
        void Save();
    }
}