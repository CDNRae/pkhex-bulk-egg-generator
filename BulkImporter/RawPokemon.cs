using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkImporter
{
    class RawPokemon
    {
        public string Name { get; set; } = null!;
        public string PrimaryType { get; set; } = null!;
        public string SecondaryType { get; set; } = null!;
        public List<string> RegularAbilities { get; set; } = null!;
        public string HiddenAbility { get; set; } = null!;
        public List<string> Forms { get; set; } = null!;
        public List<MovesInGame> RegularMoves { get; set; } = null!;
        public List<MovesInGame> EggMoves { get; set; } = null!;
    }

    class MovesInGame
    {
        public string GameName { get; set; } = null!;
        public List<string> Moves {get;set;} = null!;
    }
}
