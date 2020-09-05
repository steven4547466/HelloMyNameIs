
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace HelloMyNameIs
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("The list of names to be given.")]
        public List<string> Names { get; set; } = new List<string> { "James", "Mary", "John", "Patricia", "Robert", "Jennifer", "Michael", "Linda", "William", "Elizabeth", "David", "Barbara", "Richard", "Susan", "Joseph", "Jessica", "Thomas", "Sarah", "Charles", "Karen", "Christopher", "Nancy", "Daniel", "Margaret", "Matthew", "Lisa", "Anthony", "Betty", "Donald", "Dorothy", "Mark", "Sandra", "Paul", "Ashley", "Steven", "Kimberly", "Andrew", "Donna", "Kenneth", "Emily", "Joshua", "Michelle", "George", "Carol", "Kevin", "Amanda", "Brian", "Melissa", "Edward", "Helen" };

        [Description("SCP Names.")]
        public string Scp173Name { get; set; } = "Peanut";
        public string Scp106Name { get; set; } = "Larry";
        public string Scp049Name { get; set; } = "Doctor";
        [Description("{oldname} is replaced with the nickname they used to have, or a random one if they didn't have one.")]
        public string Scp0492Name { get; set; } = "Zombie {oldname}";
        public string Scp079Name { get; set; } = "Computer";
        public string Scp096Name { get; set; } = "Shyguy";
        public string Scp939_89Name { get; set; } = "Dog 1";
        public string Scp939_53Name { get; set; } = "Dog 2";

        [Description("Should it repeat names even when it doesn't need to?")]
        public bool CanRepeat { get; set; } = true;
    }
}
