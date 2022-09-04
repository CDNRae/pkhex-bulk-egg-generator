using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BulkImporter
{
    public class BulkImporterPlugin : IPlugin
    {
        public string Name => nameof(BulkImporter);
        public int Priority => -1; // Loading order, lowest is first.

        // Initialized on plugin load
        public ISaveFileProvider SaveFileEditor { get; private set; } = null!;
        public IPKMView PKMEditor { get; private set; } = null!;

        // Random number generator for form generation
        Random random = new Random();

        // UI Forms
        private Form form = new Form();
        private TextBox input = new TextBox();

        private NumericUpDown numberToGenerate = new NumericUpDown();
        private NumericUpDown shinyChance = new NumericUpDown();
        private NumericUpDown eggMoveChance = new NumericUpDown();
        private NumericUpDown hiddenAbilityChance = new NumericUpDown();
        private NumericUpDown maxIVValue = new NumericUpDown();
        private NumericUpDown minIVValue = new NumericUpDown();

        private CheckedListBox typeSelection = new CheckedListBox();
        private CheckBox considerFutureTypesYes = new CheckBox();
        private CheckBox avoidDuplicates = new CheckBox();

        // Pokemon forms -- doesn't include battle-only forms (i.e. Megas) or Alolan variants
        public int[] burmyForms = { 412, 905, 906 };
        public int[] shellosForms = { 422, 911 };
        public int[] scatterbugForms = { 666, 963, 964, 965, 966, 967, 968, 969, 970, 971, 972, 973, 974, 975, 976, 977, 978, 979, 980, 981 };
        public int[] flabebeForms = { 669, 986, 987, 988, 989 };
        public int[] oricorioForms = { 741, 1021, 1022, 1023 };
        public int[] miniorForms = { 774, 1045, 1046, 1047, 1048, 1049, 1050, 1051, 1052, 1053, 1054, 1055, 1056, 1057 };

        public bool ValidatePokemonType(PKM pkmn, EvolutionTree evoTree, int generation, GameVersion gameVersion)
        {
            bool returnValue = false;
            var selectedTypes = typeSelection.CheckedItems;

            // Type validation. The first check looks for all types being selected, no types being selected, or Select All being checked; any of these
            // means that any Pokemon type goes.
            if (selectedTypes.Contains("Select All") || !selectedTypes.Contains("Select All") && selectedTypes.Count == 18 || selectedTypes.Count == 0)
            {
                returnValue = true;
            }
            else
            {
                // Loop through each type in the types selected by the user. First check the Pokemon's primary type. If it doesn't match, check the secondary type
                // (provided the Pokemon has one). Finally, if the user wants to consu
                foreach (string type in selectedTypes)
                {
                    if (pkmn.PersonalInfo.Type1 != -1 && (int)(MoveType)Enum.Parse(typeof(MoveType), type) == pkmn.PersonalInfo.Type1)
                    {
                        returnValue = true;
                    }
                    else if (pkmn.PersonalInfo.Type2 != -1 && (int)(MoveType)Enum.Parse(typeof(MoveType), type) == pkmn.PersonalInfo.Type2)
                    {
                        returnValue = true;
                    }
                }
            }

            // If the user wants to, look through the possible future evolutions to see if any of them fulfill the type requirements
            if (!returnValue && considerFutureTypesYes.Checked)
            {
                var evoSpecies = evoTree.GetEvolutionsAndPreEvolutions(pkmn.Species, pkmn.Form);

                foreach (var species in evoSpecies)
                {
                    PKM evolvedPkmn = EntityBlank.GetBlank(generation, gameVersion);
                    evolvedPkmn.Species = species.Species;
                    evolvedPkmn.Form = species.Form;

                    foreach (string type in selectedTypes)
                    {
                        if (evolvedPkmn.PersonalInfo.Type1 != -1 && (int)(MoveType)Enum.Parse(typeof(MoveType), type) == evolvedPkmn.PersonalInfo.Type1)
                        {
                            returnValue = true;
                        }
                        else if (evolvedPkmn.PersonalInfo.Type2 != -1 && (int)(MoveType)Enum.Parse(typeof(MoveType), type) == evolvedPkmn.PersonalInfo.Type2)
                        {
                            returnValue = true;
                        }
                    }
                }
            }

            return returnValue;
        }

        public ushort GenerateMove(ReadOnlySpan<ushort> baseMoves, ushort[] eggMoves, int moveSlot)
        {
            ushort returnValue = 0;

            int eggMoveRand = (int)((random.Next(1, 100)) / (eggMoveChance.Value / 100));

            if (eggMoveRand < eggMoveChance.Value)
            {
                ushort moveIndex = (ushort)(random.Next(0, eggMoves.Length));
                returnValue = eggMoves[moveIndex];
            }
            else if (moveSlot < baseMoves.Length)
            {
                returnValue = baseMoves[moveSlot];
            }

            return returnValue;
        }

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
            var ctrl = new ToolStripMenuItem("Egg Generator");
            tools.DropDownItems.Add(ctrl);
            ctrl.Click += (sender, eventArgs) => generateForm();
            Console.WriteLine($"{Name} added menu items.");
        }

        // Create the UI for the importer
        public void generateForm()
        {
            SaveFile sav = SaveFileEditor.SAV; // current savefile

            List<Control> formControls = new List<Control>();
            Button createButton = new Button();

            // Set up form
            form.Size = new System.Drawing.Size(390, 500);
            form.Name = "Egg Generator";

            // Set up Type Selection
            formControls.Add(new Label
            {
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
            considerFutureTypesYes.Checked = false;
            considerFutureTypesYes.Name = "considerFutureTypes";

            formControls.Add(typeSelection);
            formControls.Add(considerFutureTypesYes);

            formControls.Add(new Label
            {
                Location = new System.Drawing.Point(8, 370),
                AutoSize = true,
                Text = "Avoid duplicates if possible?",
                Font = new System.Drawing.Font(Control.DefaultFont, System.Drawing.FontStyle.Bold)
            });

            avoidDuplicates.Text = "Yes";
            avoidDuplicates.Location = new System.Drawing.Point(10, 385);
            avoidDuplicates.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            avoidDuplicates.AutoSize = true;
            avoidDuplicates.Checked = false;
            avoidDuplicates.Name = "noDuplicates";

            formControls.Add(typeSelection);
            formControls.Add(avoidDuplicates);

            // Set up the input for the number of pokemon to generate
            formControls.Add(new Label
            {
                Location = new System.Drawing.Point(170, 10),
                AutoSize = true,
                Text = "Number of Pokemon to Generate",
                Font = new System.Drawing.Font(Control.DefaultFont, System.Drawing.FontStyle.Bold)
            });

            numberToGenerate.Value = 10;
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

            ToolTip shinyChanceToolTip = new ToolTip();
            shinyChanceToolTip.SetToolTip(shinyChance, "In Gen 2, this will overwrite IV settings.");

            shinyChance.Value = 1;
            shinyChance.Maximum = 100;
            shinyChance.Minimum = 0;
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
            eggMoveChance.Minimum = 0;
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
            hiddenAbilityChance.Minimum = 0;
            hiddenAbilityChance.Location = new System.Drawing.Point(170, 250);

            if (sav.Generation < 5)
            {
                hiddenAbilityChance.Enabled = false;
            }

            formControls.Add(hiddenAbilityChance);

            // Set up "Add to Boxes" button
            createButton.Text = "Generate Pokemon";
            createButton.Size = new System.Drawing.Size(185, 20);
            createButton.Location = new System.Drawing.Point(100, 420);
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
            SaveFile sav = SaveFileEditor.SAV; // current savefile
            int duplicateSkipCounter = 0; // used for skipping duplicate Pokemon when generating 'em 

            List<PKM> generatedPokemon = new List<PKM>(); // the pokemon to add to the boxes at the end of all this
            List<int> speciesAlreadyAdded = new List<int>(); // a list of the ints of species already added to generatedPokemon. Helps reduce -- but not eliminate -- duplicates.

            // Start by making sure the game can generate eggs; if it cannot, the generator will not work and inform the user as such
            if (!Breeding.CanGameGenerateEggs(sav.Context.GetSingleGameVersion()))
            {
                MessageBox.Show("Error! This game doesn't support egg generation. Please try another game. Game version " + sav.Context.GetSingleGameVersion().ToString());
                return;
            }
            // loop for generating pokemon
            for (int i = 0; i < numberToGenerate.Value; i++)
            {
                // Determine the species. Make sure it can come from an egg, and if needed, drop it to the lowest pre-evolution possible.
                GameVersion version = sav.Version;

                if (version == GameVersion.RS)
                {
                    version = GameVersion.R;
                }

                PKM pkmn = EntityBlank.GetBlank(sav.Generation, version);
                pkmn.Species = (ushort)random.Next(0, sav.MaxSpeciesID);
                pkmn.SetSuggestedFormArgument(pkmn.Species);

                EvolutionTree evoTree = EvolutionTree.GetEvolutionTree(pkmn.Context);
                var baseForm = evoTree.GetBaseSpeciesForm(pkmn.Species, pkmn.Form);

                // Make sure the Pokemon actually exists in the game, and can come from an egg. If it can't, decrease i by one and continue the loop.
                // i gets decreased to keep the # of pokemon generated equal to numberToGenerate.
                if (!sav.Personal.IsSpeciesInGame(baseForm.Species) || !Breeding.CanHatchAsEgg(baseForm.Species) || (Species)baseForm.Species == Species.Shedinja)
                {
                    i--;
                    continue;
                }

                pkmn.Species = baseForm.Species;
                pkmn.SetSuggestedFormArgument(pkmn.Species);

                // Make sure the Pokemon's type is OK
                if (!ValidatePokemonType(pkmn, evoTree, sav.Generation, sav.Version))
                {
                    i--;
                    continue;
                }

                // If the user wants to avoid duplicates, do a little check to see if we should re-start the for loop. To avoid getting stuck in an
                // endless loop while still maintaining the number of Pokemon to generate, the program will skip a max of 10 Pokemon; the 11th will be
                // added even if it's a duplicate species, and then the counter will be reset.
                if (avoidDuplicates.Checked)
                {
                    // The below statement will restart the for loop; the rest just carry on after doing their thing
                    if (speciesAlreadyAdded.Contains(baseForm.Species) && duplicateSkipCounter < 10)
                    {
                        duplicateSkipCounter++;
                        i--;
                        continue;
                    }
                    else if (duplicateSkipCounter >= 10)
                    {
                        duplicateSkipCounter = 0;
                    }
                    else
                    {
                        speciesAlreadyAdded.Add(baseForm.Species);
                    }
                }

                // With all the checks out of the way, various attributes can be set.

                EncounterEgg pkmnAsEgg = new EncounterEgg(pkmn.Species, pkmn.Form, EggStateLegality.GetEggLevel(sav.Generation), sav.Generation, sav.Version, sav.Context);
                LegalityAnalysis legality = new LegalityAnalysis(pkmn);
                pkmn = pkmnAsEgg.ConvertToPKM(sav);

                pkmn.Nickname = SpeciesName.GetSpeciesNameGeneration(0, sav.Language, sav.Generation);
                pkmn.IsNicknamed = true;
                pkmn.OT_Friendship = EggStateLegality.GetMinimumEggHatchCycles(pkmn);
                pkmn.Met_Location = 0;
                pkmn.Gender = pkmn.GetSaneGender();

                // There are a lot of quirks with how eggs are handled between generations, and even game versions; this collection of statements does some
                // fine-tuning to account for that.
                if (sav.Version == GameVersion.BD || sav.Version == GameVersion.SP || sav.Version == GameVersion.BDSP)
                {
                    pkmn.Met_Location = 65535; // Eggs have no met location in BDSP
                }
                else if (sav.Version == GameVersion.Pt)
                {
                    pkmn.Egg_Location = 2000; // Daycare
                    pkmn.IsNicknamed = false;
                    pkmn.Met_Level = 0;
                    pkmn.Version = (int)sav.Version;
                }
                else if (sav.Generation == 4)
                {
                    // HGSS Eggs aren't nicknamed
                    pkmn.IsNicknamed = false;
                    pkmn.Version = (int)sav.Context.GetSingleGameVersion();
                    pkmn.Egg_Location = 2000;
                }
                else if (sav.Version == GameVersion.FRLG || sav.Version == GameVersion.FR || sav.Version == GameVersion.LG)
                {
                    pkmn.Met_Location = Locations.HatchLocationFRLG; // Four Island -- if location isn't set, it defaults to Littleroot Town
                }
                else if (sav.Version == GameVersion.RSE || sav.Version == GameVersion.RS || sav.Version == GameVersion.R || sav.Version == GameVersion.S || sav.Version == GameVersion.E)
                {
                    pkmn.Met_Location = Locations.HatchLocationRSE; // Route 117 -- if location isn't set, it defaults to Littleroot Town
                    pkmn.Version = (int)sav.Context.GetSingleGameVersion();
                }
                else if (sav.Generation == 2)
                {
                    pkmn.SetNickname("EGG");
                }

                // Set the IVs based on min/max values
                pkmn.IV_HP = random.Next((int)minIVValue.Value, (int)maxIVValue.Value);
                pkmn.IV_ATK = random.Next((int)minIVValue.Value, (int)maxIVValue.Value);
                pkmn.IV_DEF = random.Next((int)minIVValue.Value, (int)maxIVValue.Value);
                pkmn.IV_SPA = random.Next((int)minIVValue.Value, (int)maxIVValue.Value);
                pkmn.IV_SPD = random.Next((int)minIVValue.Value, (int)maxIVValue.Value);
                pkmn.IV_SPE = random.Next((int)minIVValue.Value, (int)maxIVValue.Value);

                // Set ability
                pkmn.SetAbilityIndex(random.Next(0, 2));
                if (sav.Generation >= 5)
                {
                    int haValue = (int)((random.Next(1, 100)) / (hiddenAbilityChance.Value / 100));

                    if (haValue <= hiddenAbilityChance.Value)
                    {
                        pkmn.SetAbilityIndex(2); // set hidden ability
                    }
                }

                // Determine if Pokemon should be shiny
                if (shinyChance.Value > 0)
                {
                    int shinyValue = (int)((random.Next(1, 100)) / (shinyChance.Value / 100));

                    if (shinyValue <= shinyChance.Value)
                    {
                        pkmn.SetIsShiny(true);
                    }
                    else
                    {
                        pkmn.SetIsShiny(false);
                    }
                }

                // Determine moves
                try
                {
                    Learnset learnset = GameData.GetLearnset(sav.Version, pkmn.Species, pkmn.Form);
                    var baseMoves = learnset.GetBaseEggMoves(sav.Generation);
                    var eggMoves = MoveEgg.GetEggMoves(sav.Generation, pkmn.Species, pkmn.Form, sav.Version);

                    // PKHeX is smart and will automatically fill in a Pokemon's moves if we don't provide them,
                    // so there's no need to add any logic for handling situations where the user only wants base moves
                    if (eggMoveChance.Value > 0 && eggMoves.Length > 0)
                    {
                        ushort nextMoveIndex = 0;
                        int numTriesToGetMove = 0;
                        do
                        {
                            nextMoveIndex = GenerateMove(baseMoves, eggMoves, pkmn.Moves.Length);
                            pkmn.PushMove(nextMoveIndex);
                            numTriesToGetMove++;

                        } while (pkmn.MoveCount < 5 && nextMoveIndex != 0 && numTriesToGetMove < 20);

                        pkmn.FixMoves();

                        if (sav.Generation > 5)
                        {
                            pkmn.SetRelearnMoves(pkmn.Moves);
                        }

                        Span<ushort> fixedMoves = stackalloc ushort[4];
                        bool movesAreGood = MoveBreed.GetExpectedMoves(pkmn.Moves, pkmnAsEgg, fixedMoves);

                        for (int j = 0; j < 4; j++)
                        {
                            pkmn.SetMove(j, fixedMoves[j]);
                            pkmn.SetSuggestedMovePP(j);
                        }

                        if (sav.Generation > 5)
                        {
                            LegalityAnalysis legalityAnalysis = new LegalityAnalysis(pkmn);
                            var moves = MoveListSuggest.GetSuggestedRelearnMovesFromEncounter(legalityAnalysis, pkmnAsEgg);

                            for (int j = 0; j < 4; j++)
                            {
                                pkmn.SetMove(j, moves[j]);
                                pkmn.SetSuggestedMovePP(j);
                                pkmn.SetRelearnMove(j, moves[j]);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    MessageBox.Show(e.StackTrace);
                }

                pkmn.IsEgg = true;
                legality = new LegalityAnalysis(pkmn);
                string report = legality.Report();

                if (report.Contains("Hidden Ability"))
                {
                    pkmn.SetAbilityIndex(random.Next(0, 2));
                }

                // Add the generated Pokemon
                pkmn.Valid = legality.Valid;
                generatedPokemon.Add(pkmn);
            }

            sav.ImportPKMs(generatedPokemon);
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
