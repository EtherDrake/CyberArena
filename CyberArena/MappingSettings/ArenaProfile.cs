using AutoMapper;
using CyberArena.DAL;
using CyberArena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberArena.MappingSettings
{
    public class ArenaProfile:Profile
    {
        public ArenaProfile()
        {
            ArenaContext context = new ArenaContext();
            List<Team>teams=context.Teams.ToList();

            CreateMap<Player, PlayerView>()
                .ForMember(dest => dest.Team, map => map.MapFrom(source => teams.Find(x => x.ID == source.TeamID).Name));

            CreateMap<PlayerView, Player>();
        }
    }
}