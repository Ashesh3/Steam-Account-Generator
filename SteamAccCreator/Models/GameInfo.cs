using System;

namespace SteamAccCreator.Models
{
    [Serializable]
    public class GameInfo
    {
        public string Name { get; set; }
        public int SubId { get; set; }

        public override bool Equals(object obj)
        {
            var _obj = obj as GameInfo;
            if (_obj == null)
                return false;

            return _obj.SubId == SubId;
        }

        public override int GetHashCode()
            => SubId.GetHashCode();

        public override string ToString()
            => $"{Name ?? "NULL"} ({SubId})";
    }
}
