using System.Collections.Generic;
using SwordAndFather.Models;

namespace SwordAndFather.Data
{
    public class AssaassinRepository
    {
        static readonly List<Assassin> Assassins = new List<Assassin>();

        public Assassin AddAssassin(string codeName, string catchPhrase, string preferredWeapon)
        {
            var newAssassin = new Assassin(codeName, catchPhrase, preferredWeapon);
            newAssassin.Id = Assassins.Count + 1;

            Assassins.Add(newAssassin);

            return newAssassin;
        }
    }
}