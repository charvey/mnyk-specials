using System;
using System.Collections.Generic;

namespace mnyk_specials.Models
{
    public class SpecialListing
    {
        private readonly IReadOnlyDictionary<DayOfWeek, string> specials;

        public string RestaurantName { get; }
        public string MondaySpecials => GetSpecial(DayOfWeek.Monday);
        public string TuesdaySpecials => GetSpecial(DayOfWeek.Tuesday);
        public string WednesdaySpecials => GetSpecial(DayOfWeek.Wednesday);
        public string ThursdaySpecials => GetSpecial(DayOfWeek.Thursday);
        public string FridaySpecials => GetSpecial(DayOfWeek.Friday);
        public string SaturdaySpecials => GetSpecial(DayOfWeek.Saturday);
        public string SundaySpecials => GetSpecial(DayOfWeek.Sunday);

        public SpecialListing(string restaurantName, IReadOnlyDictionary<DayOfWeek, string> specials)
        {
            RestaurantName = restaurantName;
            this.specials = specials;
        }

        private string GetSpecial(DayOfWeek dayOfWeek){
            if(specials.ContainsKey(dayOfWeek))
                return specials[dayOfWeek];
            else
                return "None";
        }
    }
}