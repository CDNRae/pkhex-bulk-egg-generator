using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using PKHeX.Core;

namespace BulkImporter
{
    public enum Move
    {
        None,
        Pound,
        KarateChop,
        DoubleSlap,
        CometPunch,
        MegaPunch,
        PayDay,
        FirePunch,
        IcePunch,
        ThunderPunch,
        Scratch,
        ViseGrip,
        Guillotine,
        RazorWind,
        SwordsDance,
        Cut,
        Gust,
        WingAttack,
        Whirlwind,
        Fly,
        Bind,
        Slam,
        VineWhip,
        Stomp,
        DoubleKick,
        MegaKick,
        JumpKick,
        RollingKick,
        SandAttack,
        Headbutt,
        HornAttack,
        FuryAttack,
        HornDrill,
        Tackle,
        BodySlam,
        Wrap,
        TakeDown,
        Thrash,
        DoubleEdge,
        TailWhip,
        PoisonSting,
        Twineedle,
        PinMissile,
        Leer,
        Bite,
        Growl,
        Roar,
        Sing,
        Supersonic,
        SonicBoom,
        Disable,
        Acid,
        Ember,
        Flamethrower,
        Mist,
        WaterGun,
        HydroPump,
        Surf,
        IceBeam,
        Blizzard,
        Psybeam,
        BubbleBeam,
        AuroraBeam,
        HyperBeam,
        Peck,
        DrillPeck,
        Submission,
        LowKick,
        Counter,
        SeismicToss,
        Strength,
        Absorb,
        MegaDrain,
        LeechSeed,
        Growth,
        RazorLeaf,
        SolarBeam,
        PoisonPowder,
        StunSpore,
        SleepPowder,
        PetalDance,
        StringShot,
        DragonRage,
        FireSpin,
        ThunderShock,
        Thunderbolt,
        ThunderWave,
        Thunder,
        RockThrow,
        Earthquake,
        Fissure,
        Dig,
        Toxic,
        Confusion,
        Psychic,
        Hypnosis,
        Meditate,
        Agility,
        QuickAttack,
        Rage,
        Teleport,
        NightShade,
        Mimic,
        Screech,
        DoubleTeam,
        Recover,
        Harden,
        Minimize,
        Smokescreen,
        ConfuseRay,
        Withdraw,
        DefenseCurl,
        Barrier,
        LightScreen,
        Haze,
        Reflect,
        FocusEnergy,
        Bide,
        Metronome,
        MirrorMove,
        SelfDestruct,
        EggBomb,
        Lick,
        Smog,
        Sludge,
        BoneClub,
        FireBlast,
        Waterfall,
        Clamp,
        Swift,
        SkullBash,
        SpikeCannon,
        Constrict,
        Amnesia,
        Kinesis,
        SoftBoiled,
        HighJumpKick,
        Glare,
        DreamEater,
        PoisonGas,
        Barrage,
        LeechLife,
        LovelyKiss,
        SkyAttack,
        Transform,
        Bubble,
        DizzyPunch,
        Spore,
        Flash,
        Psywave,
        Splash,
        AcidArmor,
        Crabhammer,
        Explosion,
        FurySwipes,
        Bonemerang,
        Rest,
        RockSlide,
        HyperFang,
        Sharpen,
        Conversion,
        TriAttack,
        SuperFang,
        Slash,
        Substitute,
        Struggle,
        Sketch,
        TripleKick,
        Thief,
        SpiderWeb,
        MindReader,
        Nightmare,
        FlameWheel,
        Snore,
        Curse,
        Flail,
        Conversion2,
        Aeroblast,
        CottonSpore,
        Reversal,
        Spite,
        PowderSnow,
        Protect,
        MachPunch,
        ScaryFace,
        FeintAttack,
        SweetKiss,
        BellyDrum,
        SludgeBomb,
        MudSlap,
        Octazooka,
        Spikes,
        ZapCannon,
        Foresight,
        DestinyBond,
        PerishSong,
        IcyWind,
        Detect,
        BoneRush,
        LockOn,
        Outrage,
        Sandstorm,
        GigaDrain,
        Endure,
        Charm,
        Rollout,
        FalseSwipe,
        Swagger,
        MilkDrink,
        Spark,
        FuryCutter,
        SteelWing,
        MeanLook,
        Attract,
        SleepTalk,
        HealBell,
        Return,
        Present,
        Frustration,
        Safeguard,
        PainSplit,
        SacredFire,
        Magnitude,
        DynamicPunch,
        Megahorn,
        DragonBreath,
        BatonPass,
        Encore,
        Pursuit,
        RapidSpin,
        SweetScent,
        IronTail,
        MetalClaw,
        VitalThrow,
        MorningSun,
        Synthesis,
        Moonlight,
        HiddenPower,
        CrossChop,
        Twister,
        RainDance,
        SunnyDay,
        Crunch,
        MirrorCoat,
        PsychUp,
        ExtremeSpeed,
        AncientPower,
        ShadowBall,
        FutureSight,
        RockSmash,
        Whirlpool,
        BeatUp,
        FakeOut,
        Uproar,
        Stockpile,
        SpitUp,
        Swallow,
        HeatWave,
        Hail,
        Torment,
        Flatter,
        WillOWisp,
        Memento,
        Facade,
        FocusPunch,
        SmellingSalts,
        FollowMe,
        NaturePower,
        Charge,
        Taunt,
        HelpingHand,
        Trick,
        RolePlay,
        Wish,
        Assist,
        Ingrain,
        Superpower,
        MagicCoat,
        Recycle,
        Revenge,
        BrickBreak,
        Yawn,
        KnockOff,
        Endeavor,
        Eruption,
        SkillSwap,
        Imprison,
        Refresh,
        Grudge,
        Snatch,
        SecretPower,
        Dive,
        ArmThrust,
        Camouflage,
        TailGlow,
        LusterPurge,
        MistBall,
        FeatherDance,
        TeeterDance,
        BlazeKick,
        MudSport,
        IceBall,
        NeedleArm,
        SlackOff,
        HyperVoice,
        PoisonFang,
        CrushClaw,
        BlastBurn,
        HydroCannon,
        MeteorMash,
        Astonish,
        WeatherBall,
        Aromatherapy,
        FakeTears,
        AirCutter,
        Overheat,
        OdorSleuth,
        RockTomb,
        SilverWind,
        MetalSound,
        GrassWhistle,
        Tickle,
        CosmicPower,
        WaterSpout,
        SignalBeam,
        ShadowPunch,
        Extrasensory,
        SkyUppercut,
        SandTomb,
        SheerCold,
        MuddyWater,
        BulletSeed,
        AerialAce,
        IcicleSpear,
        IronDefense,
        Block,
        Howl,
        DragonClaw,
        FrenzyPlant,
        BulkUp,
        Bounce,
        MudShot,
        PoisonTail,
        Covet,
        VoltTackle,
        MagicalLeaf,
        WaterSport,
        CalmMind,
        LeafBlade,
        DragonDance,
        RockBlast,
        ShockWave,
        WaterPulse,
        DoomDesire,
        PsychoBoost,
        Roost,
        Gravity,
        MiracleEye,
        WakeUpSlap,
        HammerArm,
        GyroBall,
        HealingWish,
        Brine,
        NaturalGift,
        Feint,
        Pluck,
        Tailwind,
        Acupressure,
        MetalBurst,
        Uturn,
        CloseCombat,
        Payback,
        Assurance,
        Embargo,
        Fling,
        PsychoShift,
        TrumpCard,
        HealBlock,
        WringOut,
        PowerTrick,
        GastroAcid,
        LuckyChant,
        MeFirst,
        Copycat,
        PowerSwap,
        GuardSwap,
        Punishment,
        LastResort,
        WorrySeed,
        SuckerPunch,
        ToxicSpikes,
        HeartSwap,
        AquaRing,
        MagnetRise,
        FlareBlitz,
        ForcePalm,
        AuraSphere,
        RockPolish,
        PoisonJab,
        DarkPulse,
        NightSlash,
        AquaTail,
        SeedBomb,
        AirSlash,
        XScissor,
        BugBuzz,
        DragonPulse,
        DragonRush,
        PowerGem,
        DrainPunch,
        VacuumWave,
        FocusBlast,
        EnergyBall,
        BraveBird,
        EarthPower,
        Switcheroo,
        GigaImpact,
        NastyPlot,
        BulletPunch,
        Avalanche,
        IceShard,
        ShadowClaw,
        ThunderFang,
        IceFang,
        FireFang,
        ShadowSneak,
        MudBomb,
        PsychoCut,
        ZenHeadbutt,
        MirrorShot,
        FlashCannon,
        RockClimb,
        Defog,
        TrickRoom,
        DracoMeteor,
        Discharge,
        LavaPlume,
        LeafStorm,
        PowerWhip,
        RockWrecker,
        CrossPoison,
        GunkShot,
        IronHead,
        MagnetBomb,
        StoneEdge,
        Captivate,
        StealthRock,
        GrassKnot,
        Chatter,
        Judgment,
        BugBite,
        ChargeBeam,
        WoodHammer,
        AquaJet,
        AttackOrder,
        DefendOrder,
        HealOrder,
        HeadSmash,
        DoubleHit,
        RoarofTime,
        SpacialRend,
        LunarDance,
        CrushGrip,
        MagmaStorm,
        DarkVoid,
        SeedFlare,
        OminousWind,
        ShadowForce,
        HoneClaws,
        WideGuard,
        GuardSplit,
        PowerSplit,
        WonderRoom,
        Psyshock,
        Venoshock,
        Autotomize,
        RagePowder,
        Telekinesis,
        MagicRoom,
        SmackDown,
        StormThrow,
        FlameBurst,
        SludgeWave,
        QuiverDance,
        HeavySlam,
        Synchronoise,
        ElectroBall,
        Soak,
        FlameCharge,
        Coil,
        LowSweep,
        AcidSpray,
        FoulPlay,
        SimpleBeam,
        Entrainment,
        AfterYou,
        Round,
        EchoedVoice,
        ChipAway,
        ClearSmog,
        StoredPower,
        QuickGuard,
        AllySwitch,
        Scald,
        ShellSmash,
        HealPulse,
        Hex,
        SkyDrop,
        ShiftGear,
        CircleThrow,
        Incinerate,
        Quash,
        Acrobatics,
        ReflectType,
        Retaliate,
        FinalGambit,
        Bestow,
        Inferno,
        WaterPledge,
        FirePledge,
        GrassPledge,
        VoltSwitch,
        StruggleBug,
        Bulldoze,
        FrostBreath,
        DragonTail,
        WorkUp,
        Electroweb,
        WildCharge,
        DrillRun,
        DualChop,
        HeartStamp,
        HornLeech,
        SacredSword,
        RazorShell,
        HeatCrash,
        LeafTornado,
        Steamroller,
        CottonGuard,
        NightDaze,
        Psystrike,
        TailSlap,
        Hurricane,
        HeadCharge,
        GearGrind,
        SearingShot,
        TechnoBlast,
        RelicSong,
        SecretSword,
        Glaciate,
        BoltStrike,
        BlueFlare,
        FieryDance,
        FreezeShock,
        IceBurn,
        Snarl,
        IcicleCrash,
        Vcreate,
        FusionFlare,
        FusionBolt,
        FlyingPress,
        MatBlock,
        Belch,
        Rototiller,
        StickyWeb,
        FellStinger,
        PhantomForce,
        TrickorTreat,
        NobleRoar,
        IonDeluge,
        ParabolicCharge,
        ForestsCurse,
        PetalBlizzard,
        FreezeDry,
        DisarmingVoice,
        PartingShot,
        TopsyTurvy,
        DrainingKiss,
        CraftyShield,
        FlowerShield,
        GrassyTerrain,
        MistyTerrain,
        Electrify,
        PlayRough,
        FairyWind,
        Moonblast,
        Boomburst,
        FairyLock,
        KingsShield,
        PlayNice,
        Confide,
        DiamondStorm,
        SteamEruption,
        HyperspaceHole,
        WaterShuriken,
        MysticalFire,
        SpikyShield,
        AromaticMist,
        EerieImpulse,
        VenomDrench,
        Powder,
        Geomancy,
        MagneticFlux,
        HappyHour,
        ElectricTerrain,
        DazzlingGleam,
        Celebrate,
        HoldHands,
        BabyDollEyes,
        Nuzzle,
        HoldBack,
        Infestation,
        PowerUpPunch,
        OblivionWing,
        ThousandArrows,
        ThousandWaves,
        LandsWrath,
        LightofRuin,
        OriginPulse,
        PrecipiceBlades,
        DragonAscent,
        HyperspaceFury,
        BreakneckBlitzP,
        BreakneckBlitzS,
        AllOutPummelingP,
        AllOutPummelingS,
        SupersonicSkystrikeP,
        SupersonicSkystrikeS,
        AcidDownpourP,
        AcidDownpourS,
        TectonicRageP,
        TectonicRageS,
        ContinentalCrushP,
        ContinentalCrushS,
        SavageSpinOutP,
        SavageSpinOutS,
        NeverEndingNightmareP,
        NeverEndingNightmareS,
        CorkscrewCrashP,
        CorkscrewCrashS,
        InfernoOverdriveP,
        InfernoOverdriveS,
        HydroVortexP,
        HydroVortexS,
        BloomDoomP,
        BloomDoomS,
        GigavoltHavocP,
        GigavoltHavocS,
        ShatteredPsycheP,
        ShatteredPsycheS,
        SubzeroSlammerP,
        SubzeroSlammerS,
        DevastatingDrakeP,
        DevastatingDrakeS,
        BlackHoleEclipseP,
        BlackHoleEclipseS,
        TwinkleTackleP,
        TwinkleTackleS,
        Catastropika,
        ShoreUp,
        FirstImpression,
        BanefulBunker,
        SpiritShackle,
        DarkestLariat,
        SparklingAria,
        IceHammer,
        FloralHealing,
        HighHorsepower,
        StrengthSap,
        SolarBlade,
        Leafage,
        Spotlight,
        ToxicThread,
        LaserFocus,
        GearUp,
        ThroatChop,
        PollenPuff,
        AnchorShot,
        PsychicTerrain,
        Lunge,
        FireLash,
        PowerTrip,
        BurnUp,
        SpeedSwap,
        SmartStrike,
        Purify,
        RevelationDance,
        CoreEnforcer,
        TropKick,
        Instruct,
        BeakBlast,
        ClangingScales,
        DragonHammer,
        BrutalSwing,
        AuroraVeil,
        SinisterArrowRaid,
        MaliciousMoonsault,
        OceanicOperetta,
        GuardianofAlola,
        SoulStealing7StarStrike,
        StokedSparksurfer,
        PulverizingPancake,
        ExtremeEvoboost,
        GenesisSupernova,
        ShellTrap,
        FleurCannon,
        PsychicFangs,
        StompingTantrum,
        ShadowBone,
        Accelerock,
        Liquidation,
        PrismaticLaser,
        SpectralThief,
        SunsteelStrike,
        MoongeistBeam,
        TearfulLook,
        ZingZap,
        NaturesMadness,
        MultiAttack,
        TenMVoltThunderbolt,
        MindBlown,
        PlasmaFists,
        PhotonGeyser,
        LightThatBurnstheSky,
        SearingSunrazeSmash,
        MenacingMoonrazeMaelstrom,
        LetsSnuggleForever,
        SplinteredStormshards,
        ClangorousSoulblaze,
        ZippyZap,
        SplishySplash,
        FloatyFall,
        PikaPapow,
        BouncyBubble,
        BuzzyBuzz,
        SizzlySlide,
        GlitzyGlow,
        BaddyBad,
        SappySeed,
        FreezyFrost,
        SparklySwirl,
        VeeveeVolley,
        DoubleIronBash,
        MaxGuard,
        DynamaxCannon,
        SnipeShot,
        JawLock,
        StuffCheeks,
        NoRetreat,
        TarShot,
        MagicPowder,
        DragonDarts,
        Teatime,
        Octolock,
        BoltBeak,
        FishiousRend,
        CourtChange,
        MaxFlare,
        MaxFlutterby,
        MaxLightning,
        MaxStrike,
        MaxKnuckle,
        MaxPhantasm,
        MaxHailstorm,
        MaxOoze,
        MaxGeyser,
        MaxAirstream,
        MaxStarfall,
        MaxWyrmwind,
        MaxMindstorm,
        MaxRockfall,
        MaxQuake,
        MaxDarkness,
        MaxOvergrowth,
        MaxSteelspike,
        ClangorousSoul,
        BodyPress,
        Decorate,
        DrumBeating,
        SnapTrap,
        PyroBall,
        BehemothBlade,
        BehemothBash,
        AuraWheel,
        BreakingSwipe,
        BranchPoke,
        Overdrive,
        AppleAcid,
        GravApple,
        SpiritBreak,
        StrangeSteam,
        LifeDew,
        Obstruct,
        FalseSurrender,
        MeteorAssault,
        Eternabeam,
        SteelBeam,
        ExpandingForce,
        SteelRoller,
        ScaleShot,
        MeteorBeam,
        ShellSideArm,
        MistyExplosion,
        GrassyGlide,
        RisingVoltage,
        TerrainPulse,
        SkitterSmack,
        BurningJealousy,
        LashOut,
        Poltergeist,
        CorrosiveGas,
        Coaching,
        FlipTurn,
        TripleAxel,
        DualWingbeat,
        ScorchingSands,
        JungleHealing,
        WickedBlow,
        SurgingStrikes,
        ThunderCage,
        DragonEnergy,
        FreezingGlare,
        FieryWrath,
        ThunderousKick,
        GlacialLance,
        AstralBarrage,
        EerieSpell,
        MAX_COUNT,
    }

    public class BulkImporterPlugin : IPlugin
    {
        public string Name => nameof(BulkImporter);
        public int Priority => 1; // Loading order, lowest is first.

        // Initialized on plugin load
        public ISaveFileProvider SaveFileEditor { get; private set; } = null!;
        public IPKMView PKMEditor { get; private set; } = null!;

        //Random number generator for form generation
        Random random = new Random();

        // Forms
        private Form form = new Form();
        private TextBox input = new TextBox();

        //Pokemon forms
        public int[] burmyForms = { 412, 905, 906 };
        public int[] shellosForms = { 422, 911 };
        public int[] scatterbugForms = { 666, 963, 964, 965, 966, 967, 968, 969, 970, 971, 972, 973, 974, 975, 976, 977, 978, 979, 980, 981 };
        public int[] flabebeForms = { 669, 986, 987, 988, 989 };
        public int[] oricorioForms = { 741, 1021, 1022, 1023 };
        public int[] miniorForms = { 774, 1045, 1046, 1047, 1048, 1049, 1050, 1051, 1052, 1053, 1054, 1055, 1056, 1057};

        // Plugin initialization
        public void Initialize(params object[] args)
        {
            Console.WriteLine($"Loading {Name}...");
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider);
            PKMEditor = (IPKMView)Array.Find(args, z => z is IPKMView);
            var menu = (ToolStrip)Array.Find(args, z => z is ToolStrip);
            LoadMenuStrip(menu);
        }

        // Adding Plugin to PKHeX menu
        private void LoadMenuStrip(ToolStrip menuStrip)
        {
            var items = menuStrip.Items;
            if (!(items.Find("Menu_Tools", false)[0] is ToolStripDropDownItem tools))
                throw new ArgumentException(nameof(menuStrip));
            AddPluginControl(tools);
        }

        // Creating additional controls for the menu
        private void AddPluginControl(ToolStripDropDownItem tools)
        {
            var ctrl = new ToolStripMenuItem(Name);
            tools.DropDownItems.Add(ctrl);

            var c2 = new ToolStripMenuItem($"Import Pokemon");
            c2.Click += (sender, eventArgs) => generateForm();
            ctrl.DropDownItems.Add(c2);
            Console.WriteLine($"{Name} added menu items.");
        }

        public void generateForm()
        {
            Button createButton = new Button();

            //Set up form
            this.form.Size = new System.Drawing.Size(500, 500);
            this.form.Name = "Bulk Showdown Importer";

            //Set up TextBox
            this.input.AcceptsReturn = true;
            this.input.AcceptsTab = true;
            this.input.Multiline = true;
            this.input.ScrollBars = ScrollBars.Vertical;
            this.input.Size = new System.Drawing.Size(463, 400);
            this.input.Location = new System.Drawing.Point(10, 10);

            //Set up "Add to Boxes" button
            createButton.Text = "Add to Boxes";
            createButton.Size = new System.Drawing.Size(185, 20);
            createButton.Location = new System.Drawing.Point(150, 420);
            createButton.Click += new EventHandler(AddToBoxesButtonClick);

            //Add everything to the form, and show it
            this.form.Controls.Add(this.input);
            this.form.Controls.Add(createButton);
            this.form.ShowDialog();
        }

        public void AddToBoxesButtonClick(Object sender, EventArgs events)
        {
            var sav = SaveFileEditor.SAV; // current save
            int generation = sav.Generation; // the generation of the current save -- used to determine the PK save format
            List<PKM> pokemonList = new List<PKM>(); // list of all Pokemon that will be added to the sav
            string showdownData = this.input.Text; // user's input

            var pokemonArray = JsonConvert.DeserializeObject<List<RawPokemon>>(showdownData); //jsonify the data

            foreach (RawPokemon rawPokemon in pokemonArray)
            {
                PKM pokemon = new PK2();

                //Determine save format
                switch (generation)
                {
                    case 1:
                        pokemon = new PK1();
                        break;
                    case 2:
                        pokemon = new PK2();
                        break;
                    case 3:
                        pokemon = new PK3();
                        break;
                    case 4:
                        pokemon = new PK4();
                        break;
                    case 5:
                        pokemon = new PK5();
                        break;
                    case 6:
                        pokemon = new PK6();
                        break;
                    case 7:
                        pokemon = new PK7();
                        break;
                    case 8:
                        pokemon = new PK8();
                        break;
                }

                // Set the species according to the Species enum
                int speciesAsNumber = 0;

                //Check if the Pokemon is Alolan or not; if it is, do some extra logic to set the proper form
                if (rawPokemon.Species.Contains("Alolan"))
                {
                    string[] pokemon_name = rawPokemon.Species.Split('_');
                    speciesAsNumber = (int)(Species)Enum.Parse(typeof(Species), pokemon_name[1]);
                    pokemon.SetForm(810);
                    pokemon.Species = speciesAsNumber;
                }
                else
                {
                    speciesAsNumber = (int)(Species)Enum.Parse(typeof(Species), rawPokemon.Species);
                    pokemon.Species = speciesAsNumber;
                }

                // Check to see if the Pokemon has forms (i.e. Flabebe, Shellos, etc.), and if it does, randomly generate one
                if (rawPokemon.Species.Contains("Burmy"))
                {
                    int form = random.Next(0, burmyForms.Length - 1);
                    pokemon.SetForm(form);
                }
                else if (rawPokemon.Species.Contains("Shellos"))
                {
                    int form = random.Next(0, shellosForms.Length - 1);
                    pokemon.SetForm(form);
                }
                else if (rawPokemon.Species.Contains("Scatterbug"))
                {
                    int form = random.Next(0, scatterbugForms.Length - 1);
                    pokemon.SetForm(form);
                }
                else if (rawPokemon.Species.Contains("Flabébé"))
                {
                    int form = random.Next(0, flabebeForms.Length - 1);
                    pokemon.SetForm(form);
                }
                else if (rawPokemon.Species.Contains("Oricorio"))
                {
                    int form = random.Next(0, oricorioForms.Length - 1);
                    pokemon.SetForm(form);
                }
                else if (rawPokemon.Species.Contains("Minior"))
                {
                    int form = random.Next(0, miniorForms.Length - 1);
                    pokemon.SetForm(form);
                }

                GameVersion game = (GameVersion)sav.Game;
                EncounterEgg encounterEgg = new EncounterEgg(speciesAsNumber, pokemon.Form, 1, sav.Generation, game);
                PKM pokemonAsEgg = encounterEgg.ConvertToPKM(sav);

                // Set the ability
                string ability = rawPokemon.Ability.Replace(" ", "");
                int abilityAsNumber = (int)(Ability)Enum.Parse(typeof(Ability), ability);
                pokemonAsEgg.SetAbility(abilityAsNumber);
                
                //Set gender
                switch (rawPokemon.Gender)
                {
                    case "M":
                        pokemonAsEgg.SetGender(0);
                        break;
                    case "F":
                        pokemonAsEgg.SetGender(1);
                        break;
                    case "N":
                        pokemonAsEgg.SetGender(2);
                        break;
                }
                
                // Set Nature via the Nature enum
                int natureAsNumber = (int)(Nature)Enum.Parse(typeof(Nature), rawPokemon.Nature);
                pokemonAsEgg.Nature = natureAsNumber;

                // Set the IVs
                pokemonAsEgg.IV_HP = rawPokemon.HP;
                pokemonAsEgg.IV_ATK = rawPokemon.Atk;
                pokemonAsEgg.IV_DEF = rawPokemon.Def;
                pokemonAsEgg.IV_SPA = rawPokemon.SpA;
                pokemonAsEgg.IV_SPD = rawPokemon.SpD;
                pokemonAsEgg.IV_SPE = rawPokemon.Spe;

                // Set moves and make sure they have the proper PP
                string move = "";
                if (string.IsNullOrEmpty(rawPokemon.MoveOne) == false)
                {
                    move = rawPokemon.MoveOne.Replace("-", "");
                    move = move.Replace(" ", "");
                    pokemonAsEgg.Move1 = (int)(Move)Enum.Parse(typeof(Move), move);
                    pokemonAsEgg.RelearnMove1 = pokemonAsEgg.Move1;
                }
                if (string.IsNullOrEmpty(rawPokemon.MoveTwo) == false)
                {
                    move = rawPokemon.MoveTwo.Replace("-", "");
                    move = move.Replace(" ", "");
                    pokemonAsEgg.Move2 = (int)(Move)Enum.Parse(typeof(Move), move);
                    pokemonAsEgg.RelearnMove2 = pokemonAsEgg.Move2;
                }
                if (string.IsNullOrEmpty(rawPokemon.MoveThree) == false)
                {
                    move = rawPokemon.MoveThree.Replace("-", "");
                    move = move.Replace(" ", "");
                    pokemonAsEgg.Move3 = (int)(Move)Enum.Parse(typeof(Move), move);
                    pokemonAsEgg.RelearnMove3 = pokemonAsEgg.Move3;
                }
                if (string.IsNullOrEmpty(rawPokemon.MoveFour) == false)
                {
                    move = rawPokemon.MoveFour.Replace("-", "");
                    move = move.Replace(" ", "");
                    pokemonAsEgg.Move4 = (int)(Move)Enum.Parse(typeof(Move), move);
                    pokemonAsEgg.RelearnMove4 = pokemonAsEgg.Move4;
                }

                pokemonAsEgg.SetMaximumPPCurrent();

                //Finally, if the Pokemon is supposed to be shiny, make it so
                if (rawPokemon.IsShiny == "true")
                {
                    CommonEdits.SetShiny(pokemonAsEgg);
                }
                else
                {
                    CommonEdits.SetUnshiny(pokemonAsEgg);
                }
                
                pokemonList.Add(pokemonAsEgg);
            }

            // Import Pokemon, reload the boxes so they can be seen, show a message and close the window
            sav.ImportPKMs(pokemonList);
            SaveFileEditor.ReloadSlots();
            MessageBox.Show("Done!");
            this.input.Clear();
            this.form.Close();
        }

        public void NotifySaveLoaded()
        {
            Console.WriteLine($"{Name} was notified that a Save File was just loaded.");
        }

        public bool TryLoadFile(string filePath)
        {
            Console.WriteLine($"{Name} was provided with the file path, but chose to do nothing with it.");
            return false; // no action taken
        }
    }
}
