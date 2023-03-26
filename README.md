# PKHeX Bulk Egg Generator
## About
Previously called the Bulk Pokemon Importer. The Bulk Egg Generator is a PKHeX plugin that allows you to generate eggs in your Pokemon save files. There are additional options that allow the user to control certain aspects of the generated eggs, such as their typing, IVs, nature, and so on.

## Current Features
* Bulk generate up to 100 Pokemon eggs at a time
* Restrict the generated eggs by one or more types, and opt to consider the eggs' future evolutions
* Set the minimum and maxiumum IV values you want the generated eggs to have
* Set the chance of a Pokemon being shiny
* Set the chance of a Pokemon having its Hidden Ability (gen 5+)
* Set the chance of a Pokemon having egg moves

## Installation
Download the latest version from the <a href="https://github.com/CDNRae/pkhex-bulk-importer/releases">releases</a> page, and extract the contents to /PKHex/plugins.  If you don't have a plugins folder in your PKHeX directory, you'll have to create one.

## Usage
Once the plugin has been installed, you can view it under the "Tools" menu in PKHeX.  Click on the "Egg Generator" sub-menu item to open the Egg Generator. Set the options as you please, and when you're ready, hit "Generate Eggs". You should see your PC boxes fill up with Pokemon Eggs shortly after.

## Known Issues & FAQ
### I can't see the Egg Generator in the menu
PKHeX sometimes fails to load plugins. You can keep closing and re-opening it to try (which is admittedly annoying), or change its `PluginLoadMethod`. You can do this by going to `Options > Settings > Startup` and changing `PluginLoadMethod` to `LoadFromFile`. Restart PKHeX after making the changes. You may still have to close and reopen PKHeX once or twice, but not nearly as many times as before.

### Shiny Pokemon In Gold/Silver/Crystal ignore the min/max IV settings!
This is expected behaviour, and it's because of the way shinies work in Gen 2. From Gen 3 onward, shininess is determined by three things: the Pokemon's original trainer's ID and secret ID, and the Pokemon's personality value. In Gen 2, however, shininess is determined by the Pokemon's IVs. For a Pokemon to be shiny in Gen 2, it must have a value of 10 for its Speed, Defense, and Special IVs, and a value of 2, 3, 6, 7, 10, 11, 14 or 15 for its Attack IV.

You can read more about the mechanic <a href="https://bulbapedia.bulbagarden.net/wiki/Shiny_Pok%C3%A9mon#Generation_II">here</a>.

### PKHeX is flagging all Scarlet & Violet Pokemon as illegal
The Pokemon being generated *are* legal; PKHeX just has issues recognizing them as such. You can verify this by selecting any Pokemon, and unchecking and re-checking the `Is Egg` option in the `Main` tab. If you then click the error icon, it will change to the valid icon.

This is a known issue, and is being looked into. 

### PKHeX is flagging the generated Pokemon as illegal, but when I check each Pokemon individually it says they're fine
This is a known issue, and a solution is being looked into. It affects the following games:
* X and Y
* Omega Ruby and Alpha Sapphire
* Ruby, Sapphire, and Emerald
* FireRed and LeafGreen

### One or more of the generated Pokemon is illegal
Please log an issue <a href="https://github.com/CDNRae/pkhex-bulk-egg-generator/issues">in the issues tab</a>, and include the problems PKHeX has with the Pokemon.


