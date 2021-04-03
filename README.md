# PKHeX Bulk Importer
## About
The Bulk Importer allows you to import a large number of Pokemon into your save files using PKHeX.

## Current Features
* Bulk import Pokemon into any core Pokemon game
* Determine each Pokemon's characteristics -- you have control over their moves, whether they're shiny, their level, IVs, etc.

## Installation
Download the latest version from the <a href="https://github.com/CDNRae/pkhex-bulk-importer/releases">releases</a> page, and extract the contents to /PhHex/plugins.  If you don't have a plugins folder in your PKHeX directory, you'll have to create one.

## Usage
Once the plugin has been installed, you can view it under the "Tools" menu in PKHeX.  Click on the "Import Pokemon" sub-menu item to open another window with a text area and button.  The text area is for inputting your data; when you're finished, click the button to have the plugin generate the Pokemon you've specified.

Each Pokemon you enter into the text area must adhere to the following format:

```
[
  {
    "Species": "Bulbasaur",
    "Ability": "Overgrow",
    "Gender": "M",
    "Level": 1,
    "isEgg": true,
    "isShiny": true,
    "Nature": "Serious",
    "HP": 31,
    "Atk": 1,
    "Def": 10,
    "SpA": 8,
    "SpD": 5,
    "Spe": 6,
    "MoveOne": "Tackle",
    "MoveTwo": "",
    "MoveThree": "",
    "MoveFour": ""
  }
]
```

To add more Pokemon to the list, copy everything between the square brackets ([]), add a comma after the closing curly bracket (}), and then hit "enter".  On the new line, paste what you copied before, and edit it to your liking.

All fields must be filled out _except_ for the moves.  If you leave any of the others blank, the plugin will throw an error.  It will also throw errors if the data isn't formatted correctly.  If you encounter an error, you can press "Continue" to keep PKHeX running, and adjust your input.
