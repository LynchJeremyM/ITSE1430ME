using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
    {
        // Character name
        public string Name { get; set; }   

        // Profession of character : Fighter, Hunter, Priest, Rogue, Wizard
        public string Profession { get; set; }

        // Race of character : Dwarf, Elf, Gnome, Half Elf, Human
        public string Race { get; set; }

        // Character attributes : Strength, Intelligence, Agility, Constitution, Charisma
        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Agility { get; set; }

        public int Constitution { get; set; }

        public int Charisma { get; set; }

        // Character description : optional
        public string Description { get; set; }
    }
}
