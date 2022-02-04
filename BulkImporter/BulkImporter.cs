using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using PKHeX.Core;

namespace BulkImporter
{
    // Enum of move data, taken from PKHeX
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
        ViceGrip,
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

        // Random number generator for form generation
        Random random = new Random();

        // Forms
        private Form form = new Form();
        private TextBox input = new TextBox();

        private NumericUpDown numberToGenerate = new NumericUpDown();
        private NumericUpDown shinyChance = new NumericUpDown();
        private NumericUpDown eggMoveChance = new NumericUpDown();
        private NumericUpDown hiddenAbilityChance = new NumericUpDown();
        private NumericUpDown maxIVValue = new NumericUpDown();
        private NumericUpDown minIVValue = new NumericUpDown();

        private CheckedListBox typeSelection = new CheckedListBox();
        private RadioButton considerFutureTypesYes = new RadioButton();
        private RadioButton considerFutureTypesNo = new RadioButton();

        // Pokemon forms -- doesn't include battle-only forms (i.e. Megas) or Alolan variants
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
            string[] pokemonTypes = { "Select All", "Normal", "Fire", "Fighting", "Water", "Flying", "Grass", "Poison", "Electric", "Ground", "Psychic", "Rock", "Ice", "Bug", "Dragon", "Ghost", "Dark", "Steel", "Fairy" };
            typeSelection.Items.AddRange(pokemonTypes);
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
            List<Control> formControls = new List<Control>();
            Button createButton = new Button();

            // Set up form
            form.Size = new System.Drawing.Size(390, 450);
            form.Name = "Bulk Importer";

            // Set up Type Selection
            formControls.Add(new Label {
                Location = new System.Drawing.Point(8, 10),
                AutoSize = true,
                Text = "Types",
                Font = new System.Drawing.Font(Control.DefaultFont, System.Drawing.FontStyle.Bold)
            });

            typeSelection.Location = new System.Drawing.Point(10, 25);
            typeSelection.Size = new System.Drawing.Size(150, 300);
            typeSelection.SelectedValueChanged += new EventHandler(SelectOrDeselectAllTypes);

            formControls.Add(new Label
            {
                Location = new System.Drawing.Point(8, 320),
                AutoSize = true,
                Text = "Consider typing of future evolutions?",
                Font = new System.Drawing.Font(Control.DefaultFont, System.Drawing.FontStyle.Bold)
            });

            considerFutureTypesYes.Text = "Yes";
            considerFutureTypesYes.Location = new System.Drawing.Point(10, 335);
            considerFutureTypesYes.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            considerFutureTypesYes.AutoSize = true;

            considerFutureTypesNo.Text = "No";
            considerFutureTypesNo.Location = new System.Drawing.Point(10, 350);
            considerFutureTypesNo.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            considerFutureTypesNo.AutoSize = true;

            formControls.Add(typeSelection);
            formControls.Add(considerFutureTypesYes);
            formControls.Add(considerFutureTypesNo);

            // Set up the input for the number of pokemon to generate
            formControls.Add(new Label
            {
                Location = new System.Drawing.Point(170, 10),
                AutoSize = true,
                Text = "Number of Pokemon to Generate",
                Font = new System.Drawing.Font(Control.DefaultFont, System.Drawing.FontStyle.Bold)
            });

            numberToGenerate.Value = 50;
            numberToGenerate.Maximum = 100;
            numberToGenerate.Minimum = 1;
            numberToGenerate.Location = new System.Drawing.Point(170, 25);

            formControls.Add(numberToGenerate);

            // Set up the input for the min IV value
            formControls.Add(new Label
            {
                Location = new System.Drawing.Point(170, 55),
                AutoSize = true,
                Text = "Min IV Value",
                Font = new System.Drawing.Font(Control.DefaultFont, System.Drawing.FontStyle.Bold)
            });

            minIVValue.Value = 0;
            minIVValue.Maximum = 31;
            minIVValue.Minimum = 0;
            minIVValue.Location = new System.Drawing.Point(170, 70);

            formControls.Add(minIVValue);

            //Set up the input for the max IV value
            formControls.Add(new Label
            {
                Location = new System.Drawing.Point(170, 100),
                AutoSize = true,
                Text = "Max IV Value",
                Font = new System.Drawing.Font(Control.DefaultFont, System.Drawing.FontStyle.Bold)
            });

            maxIVValue.Value = 31;
            maxIVValue.Maximum = 31;
            maxIVValue.Minimum = 0;
            maxIVValue.Location = new System.Drawing.Point(170, 115);

            formControls.Add(maxIVValue);

            // Set up the input for shiny chance
            formControls.Add(new Label
            {
                Location = new System.Drawing.Point(170, 145),
                AutoSize = true,
                Text = "Shiny Chance",
                Font = new System.Drawing.Font(Control.DefaultFont, System.Drawing.FontStyle.Bold)
            });

            shinyChance.Value = 1;
            shinyChance.Maximum = 100;
            shinyChance.Minimum = 1;
            shinyChance.Location = new System.Drawing.Point(170, 160);

            formControls.Add(shinyChance);

            // Set up the input for Egg Move Chance
            formControls.Add(new Label
            {
                Location = new System.Drawing.Point(170, 190),
                AutoSize = true,
                Text = "Egg Move Chance",
                Font = new System.Drawing.Font(Control.DefaultFont, System.Drawing.FontStyle.Bold)
            });

            eggMoveChance.Value = 25;
            eggMoveChance.Maximum = 100;
            eggMoveChance.Minimum = 1;
            eggMoveChance.Location = new System.Drawing.Point(170, 205);

            formControls.Add(eggMoveChance);

            // Set up the input for Hidden Ability Chance
            formControls.Add(new Label
            {
                Location = new System.Drawing.Point(170, 235),
                AutoSize = true,
                Text = "Hidden Ability Chance",
                Font = new System.Drawing.Font(Control.DefaultFont, System.Drawing.FontStyle.Bold)
            });

            hiddenAbilityChance.Value = 25;
            hiddenAbilityChance.Maximum = 100;
            hiddenAbilityChance.Minimum = 1;
            hiddenAbilityChance.Location = new System.Drawing.Point(170, 250);

            formControls.Add(hiddenAbilityChance);

            // Set up "Add to Boxes" button
            createButton.Text = "Generate Pokemon";
            createButton.Size = new System.Drawing.Size(185, 20);
            createButton.Location = new System.Drawing.Point(100, 380);
            createButton.Click += new EventHandler(AddToBoxesButtonClick);

            formControls.Add(createButton);

            // Add everything to the form, and show it
            form.Controls.AddRange(formControls.ToArray());
            form.ShowDialog();
        }

        public void SelectOrDeselectAllTypes(Object sender, EventArgs eventArgs)
        {
            if (typeSelection.SelectedIndex == 0)
            {
                bool checkItems = false;

                if (typeSelection.GetItemCheckState(0) == CheckState.Checked)
                {
                    checkItems = true;
                }

                for (int i = 0; i < typeSelection.Items.Count; i++)
                {
                    typeSelection.SetItemChecked(i, checkItems);
                }
            }
        }

        public void AddToBoxesButtonClick(Object sender, EventArgs events)
        {
            var sav = SaveFileEditor.SAV;
            List<PKM> pokemonList = new List<PKM>();
            // MessageBox.Show(sav.Generation.ToString());
            // MessageBox.Show(numberToGenerate.Value.ToString());

            // Loop until the number of Pokemon generated equals numberToGenerate
            for (int i = 0; i < numberToGenerate.Value; i++)
            {

                /*int pokeDexNum = random.Next(1, sav.MaxSpeciesID);

                EncounterEgg encounterEgg = new EncounterEgg(pokeDexNum, 0, 1, sav.Generation, (GameVersion)sav.Version);
                PKM pkmn = encounterEgg.ConvertToPKM(sav);

                IEnumerable<EncounterEgg> generatedEgg = EncounterEggGenerator.GenerateEggs(pkmn, sav.Generation);

                foreach (var e in generatedEgg)
                {
                    PKM pokemon = e.ConvertToPKM(sav);


                }*/
            }
                                    
            sav.ImportPKMs(pokemonList);
            SaveFileEditor.ReloadSlots();
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
