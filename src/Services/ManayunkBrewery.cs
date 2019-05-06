using System;
using System.Linq;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace mnyk_specials.Services
{
    public class ManayunkBrewery
    {
        public IReadOnlyDictionary<DayOfWeek, string> GetSpecials()
        {
            var url = "https://www.manayunkbrewery.com/weekly-specials/";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode("//main/section[3]/div/div[2]");
            return SplitSpecials(node).ToDictionary(x => x.Item1, x => x.Item2);
        }

        private IEnumerable<Tuple<DayOfWeek, string>> SplitSpecials(HtmlNode root)
        {
            DayOfWeek? currentDay = null;
            var special = "";
            foreach (var node in root.ChildNodes)
            {
                if (node.Name == "h3")
                {
                    if (currentDay != null)
                    {
                        yield return Tuple.Create(currentDay.Value, special);
                    }
                    currentDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), node.InnerText);
                    special = "";
                }
                else
                {
                    special += node.InnerText;
                }
            }
            yield return Tuple.Create(currentDay.Value, special);
        }
    }
}