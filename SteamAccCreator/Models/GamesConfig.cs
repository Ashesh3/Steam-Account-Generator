using System;
using System.Collections.Generic;

namespace SteamAccCreator.Models
{
    [Serializable]
    public class GamesConfig
    {
        public bool AddGames { get; set; }
        public IEnumerable<GameInfo> GamesToAdd { get; set; } = new GameInfo[0];
    }
}
