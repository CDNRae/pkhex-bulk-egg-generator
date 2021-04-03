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
        stringShot,
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

        // Forms
        private Form form = new Form();
        private TextBox input = new TextBox();

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

            var showdownArray = JsonConvert.DeserializeObject<List<RawPokemon>>(showdownData); //jsonify the data

            foreach (RawPokemon rawPokemon in showdownArray)
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
                int speciesAsNumber = (int)(Species)Enum.Parse(typeof(Species), rawPokemon.Species);
                pokemon.Species = speciesAsNumber;

                // Set the ability
                int abilityAsNumber = (int)(Ability)Enum.Parse(typeof(Ability), rawPokemon.Ability);
                pokemon.Ability = abilityAsNumber;
                
                //Set gender
                switch (rawPokemon.Gender)
                {
                    case "M":
                        pokemon.Gender = 0;
                        break;
                    case "F":
                        pokemon.Gender = 1;
                        break;
                    case "N":
                        pokemon.Gender = 2;
                        break;
                }

                // Set current level, and if it's 1, check to see if it should be an egg
                pokemon.CurrentLevel = rawPokemon.Level;

                if (rawPokemon.Level == 1)
                {
                    pokemon.IsEgg = rawPokemon.IsEgg;
                }
                
                // Set Nature via the Nature enum
                int natureAsNumber = (int)(Nature)Enum.Parse(typeof(Nature), rawPokemon.Nature);
                pokemon.Nature = natureAsNumber;

                // Set the IVs
                pokemon.IV_HP = rawPokemon.HP;
                pokemon.IV_ATK = rawPokemon.Atk;
                pokemon.IV_DEF = rawPokemon.Def;
                pokemon.IV_SPA = rawPokemon.SpA;
                pokemon.IV_SPD = rawPokemon.SpD;
                pokemon.IV_SPE = rawPokemon.Spe;

                // Set moves and make sure they have the proper PP
                if (string.IsNullOrEmpty(rawPokemon.MoveOne) == false)
                {
                    pokemon.Move1 = (int)(Move)Enum.Parse(typeof(Move), rawPokemon.MoveOne);
                }
                if (string.IsNullOrEmpty(rawPokemon.MoveTwo) == false)
                {
                    pokemon.Move2 = (int)(Move)Enum.Parse(typeof(Move), rawPokemon.MoveTwo);
                }
                if (string.IsNullOrEmpty(rawPokemon.MoveThree) == false)
                {
                    pokemon.Move3 = (int)(Move)Enum.Parse(typeof(Move), rawPokemon.MoveThree);
                }
                if (string.IsNullOrEmpty(rawPokemon.MoveFour) == false)
                {
                    pokemon.Move4 = (int)(Move)Enum.Parse(typeof(Move), rawPokemon.MoveFour);
                }

                pokemon.SetMaximumPPCurrent();

                //Finally, if the Pokemon is supposed to be shiny, make it so
                if (rawPokemon.IsShiny == true)
                {
                    CommonEdits.SetShiny(pokemon);
                }
                else
                {
                    CommonEdits.SetUnshiny(pokemon);
                }

                pokemonList.Add(pokemon);
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
