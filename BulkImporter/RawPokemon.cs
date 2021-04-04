using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkImporter
{
    class RawPokemon
    {
        public string Species { get; set; } = null!;
        public string Ability { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int Level { get; set; }
        public string IsEgg { get; set; }
        public string IsShiny { get; set; }
        public string Nature { get; set; } = null!;
        public int HP { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int SpA { get; set; }
        public int SpD { get; set; }
        public int Spe { get; set; }
        public string MoveOne { get; set; } = null!;
        public string MoveTwo { get; set; } = null!;
        public string MoveThree { get; set; } = null!;
        public string MoveFour { get; set; } = null!;
    }
}
