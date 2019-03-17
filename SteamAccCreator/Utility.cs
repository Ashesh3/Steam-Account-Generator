using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccCreator
{
    public static class Utility
    {
        private static readonly Random _Random = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (_Random) // synchronize
            {
                return _Random.Next(min, max);
            }
        }

        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var result = "";
            for (int i = 0; i < length; i++)
            {
                result += chars.RandomElement();
            }
            return result;
        }

        public static T RandomElement<T>(this IEnumerable<T> collection)
        {
            if ((collection?.Count() ?? 0) < 1)
                return default(T);
            else if (collection.Count() == 1)
                return collection.First();

            return collection.ElementAt(GetRandomNumber(0, collection.Count() - 1));
        }

        public static string ToTitleCase(this string text)
            => new CultureInfo("en-US").TextInfo.ToTitleCase(text);
    }
}
