# ModExportData to JSON Python Scripts

These scripts are used to add English translations to decrypted ModExportData files.

## Prerequisites

* Python 3.x installed (download from [python.org](https://www.python.org/)).

## Usage

1.  **Decryption:**
    * Use a tool like the [Mod decryption tool](https://steamcommunity.com/workshop/filedetails/?id=3225372871) to decrypt `ModExportData.cache`.
    * Rename the decrypted file to `ModExportData.json` and place it in the same folder as the Python scripts.

2.  **Extracting Chinese Keys (Optional):**
    * Run `GrabCHKeys.py` to extract all Chinese keys (`ch` fields) from `ModExportData.json`.
    * This generates a text file with one Chinese key per line.
    * This is useful for identifying missing English translations.

3.  **Translation:**
    * Translate the extracted Chinese keys using an AI translation tool or manually.
    * Format the translations into a text file with each Chinese text on one line and its English translation on the next line.
        ```
        招魂幡
        Soul Summoning Banner
        ...
        ```

4.  **Adding English Translations:**
    * Place the translation file in the same directory as the script.
    * Run `addEN.py` to add the English translations to `ModExportData.json`.
    * The script will create an "Updated folder" and place the updated json file there.

5.  **Encryption:**
    * Rename the updated `ModExportData.json` back to `ModExportData.cache`.
    * Use the mod decryption tool to encrypt the file.

## Script Descriptions

### GrabKeys.py

* Extracts both `ch` and `en` keys from `LocalText.json`.
* Writes them to a text file with Chinese text on the first line and English text on the second.
* Recommended for use with `LocalText.json` from the game's modding directory.

### GrabCHKeys.py

* Extracts only the `ch` keys from `ModExportData.json`.
* Writes each Chinese key to a new line in a text file.
* Useful for checking for missing English translations.

### addEN1.py
* Does not check for an en key in the items field.
* Reads Chinese-English pairs from a text file and adds them to `ModExportData.json`.
* Replaces `\n` with `\\n` in the English translations.
* **Note:** Color tags and extra backslashes might require manual correction.

###addEN2.py

* Check for en key in the items field
* Reads Chinese-English pairs from a text file and adds them to `ModExportData.json`.
* Replaces `\n` with `\\n` in the English translations.
* **Note:** Color tags and extra backslashes might require manual correction.

### joinDic.py

* (Advanced) Joins dictionary lines for alternative processing.
* Requires manual script modification.

## Troubleshooting

* **Color Tags/Extra Backslashes:** Manually edit the JSON file to correct these issues.
* **Translation Mismatches:** Ensure the translation file format matches the expected input.