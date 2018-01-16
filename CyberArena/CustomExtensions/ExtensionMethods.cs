using AutoMapper;
using CyberArena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberArena.CustomExtensions
{
    public static class ExtensionMethods
    {
        public static PlayerView Map(this Player player) //Player to PlayerView
        {
           return Mapper.Map<PlayerView>(player);
        }

        public static Player Map(this PlayerView playerModel) //PlayerView to Player
        {
            return Mapper.Map<Player>(playerModel);
        }

        public static List<PlayerView> Map(this List<Player> players)
        {
            return Mapper.Map<List<PlayerView>>(players.ToList());
        }
    }
}