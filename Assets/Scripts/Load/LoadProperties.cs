using Assets.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Load
{
    public static class LoadProperties
    {
        public static bool GameLoading;
        public static List<HexagonModel> HexagonModels;
        public static int ActivePlayers;
        public static int ActiveAis;
        public static List<string> Names;
        public static int AiLevel;
        public static int ActivePlayer;
        public static int Turn;
    }
}
