
public class RawPokemonData
{
    public RawPokemon[] PokemonList { get; set; }
}

public class RawPokemon
{
    public string name { get; set; }
    public string primary_type { get; set; }
    public string secondary_type { get; set; }
    public string[] regular_abilities { get; set; }
    public string hidden_ability { get; set; }
    public string[] forms { get; set; }
    public Regular_Moves regular_moves { get; set; }
    public Egg_Moves egg_moves { get; set; }
}

public class Regular_Moves
{
    public string[] goldsilver { get; set; }
    public string[] crystal { get; set; }
    public string[] rubysapphire { get; set; }
    public string[] emerald { get; set; }
    public string[] fire_redleaf_green { get; set; }
    public string[] diamondpearl { get; set; }
    public string[] platinum { get; set; }
    public string[] heart_goldsoul_silver { get; set; }
    public string[] blackwhite { get; set; }
    public object[] black_2white_2 { get; set; }
    public string[] xy { get; set; }
    public string[] omega_rubyalpha_sapphire { get; set; }
    public string[] sunmoon { get; set; }
    public string[] ultra_sunultra_moon { get; set; }
    public object[] swordshield { get; set; }
    public object[] brilliant_diamondshining_pearl { get; set; }
}

public class Egg_Moves
{
    public string[] goldsilver { get; set; }
    public string[] crystal { get; set; }
    public string[] rubysapphire { get; set; }
    public string[] emerald { get; set; }
    public string[] fire_redleaf_green { get; set; }
    public string[] diamondpearl { get; set; }
    public string[] platinum { get; set; }
    public string[] heart_goldsoul_silver { get; set; }
    public string[] blackwhite { get; set; }
    public object[] black_2white_2 { get; set; }
    public string[] xy { get; set; }
    public string[] omega_rubyalpha_sapphire { get; set; }
    public string[] sunmoon { get; set; }
    public string[] ultra_sunultra_moon { get; set; }
    public object[] swordshield { get; set; }
    public object[] brilliant_diamondshining_pearl { get; set; }
}
