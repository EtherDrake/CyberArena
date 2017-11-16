using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CyberArena.Models;

namespace CyberArena.DAL
{
    public class ArenaInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<ArenaContext>
    {
        protected override void Seed(ArenaContext context)
        {
            var students = new List<Player>
            {
                new Player{FirstName="Danil",LastName="Ishutin", Nickname="Dendi",Discipline="Dota 2", MMR=7526, TeamID=1},
                new Player{FirstName="Victor",LastName="Nigrini", Nickname="GeneRaL",Discipline="Dota 2", MMR=8402, TeamID=1},
                new Player{FirstName="Vladislav",LastName="Krystanek", Nickname="Crystallize",Discipline="Dota 2", MMR=8662, TeamID=1},
                new Player{FirstName="Vladimir",LastName="Nikogosyan ", Nickname="RodjER",Discipline="Dota 2", MMR=8072, TeamID=1},
                new Player{FirstName="Akbar",LastName="Butaev", Nickname="SoNNeikO",Discipline="Dota 2", MMR=9470, TeamID=1},
                new Player{FirstName="Dmytro",LastName="Filipchuk", Nickname="DIMAGA",Discipline="Starcraft 2", MMR=7323, TeamID=2},
                new Player{FirstName="Vitaliy",LastName="Ponomarenko", Nickname="Minato",Discipline="Starcraft 2", MMR=7526, TeamID=2},
            };

            students.ForEach(s => context.Players.Add(s));
            context.SaveChanges();
            var courses = new List<Team>
            {
                new Team{Name="Na'Vi", Rating=3000},
                new Team{Name="Ir0nChain", Rating=2500},
            };
            courses.ForEach(s => context.Teams.Add(s));
            context.SaveChanges();
        }
    }
}