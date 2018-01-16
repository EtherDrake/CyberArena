using CyberArena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberArena.DAL
{
    public interface ITeamRepository:IDisposable
    {
        IEnumerable<Team> GetTeams();
        Team GetTeamByID(int teamID);
        void InsertTeam(Team team);
        void DeleteTeam(int teamID);
        void UpdateTeam(Team team);
        void Save();
    }
}