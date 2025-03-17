import json
import os

def load_english_pairs_from_file(filename, debug_file):
    """
    Loads Chinese-English pairs from a file into a dictionary, replacing \\n with \n, and adds debugging.
    Each Chinese text is on one line, and its English translation is on the next.

    Skips the en check

    Args:
        filename (str): The name of the file to load.
        debug_file: The file object to write debugging information.

    Returns:
        dict: A dictionary of Chinese-English pairs.
    """
    english_pairs = {}
    try:
        with open(filename, "r", encoding="utf-8") as f:
            lines = f.readlines()
            for i in range(0, len(lines), 2):
                if i + 1 < len(lines):
                    chinese = lines[i].rstrip('\n').replace('\\n', '\n')
                    english = lines[i + 1].rstrip('\n').replace('\\n', '\n')
                    english_pairs[chinese] = english
                    debug_file.write(f"Loaded Chinese: {repr(chinese)}\n")
                    debug_file.write(f"Loaded English: {repr(english)}\n")
        debug_file.write(f"Dictionary: {repr(english_pairs)}\n")
    except FileNotFoundError:
        debug_file.write(f"File '{filename}' not found.\n")
        print(f"File '{filename}' not found.")
    except Exception as e:
        debug_file.write(f"Error loading English pairs: {e}\n")
        print(f"Error loading English pairs: {e}")
    return english_pairs

def update_english_from_pairs(json_data, english_pairs, filename="ModExportData.json", debug_file="debugAddEN.txt"):
    if "items" in json_data and "LocalText" in json_data["items"]:
        for item in json_data["items"]["LocalText"]:
            chinese_text = item.get("ch")
            if chinese_text:
                if chinese_text in english_pairs:
                        item["en"] = english_pairs[chinese_text]
                        # Replace \n with \\n only in the "en" value
                        if isinstance(item["en"], str):
                            item["en"] = item["en"].replace('\n', '\\n')
                        if debug_file:
                            debug_file.write(f"Found match: {repr(chinese_text)}\n")
                            debug_file.write(f"Added English: {repr(item['en'])}\n")
                        else:
                            if debug_file:
                             debug_file.write(f"Skipping (has 'en'): {repr(chinese_text)}\n")
                            else:
                                if debug_file:
                                    debug_file.write(f"Not found: {repr(chinese_text)}\n")

    try:
        folder_name = "Updated"
        if not os.path.exists(folder_name):
            os.makedirs(folder_name)
        file_path = os.path.join(folder_name, filename)

        with open(file_path, "w", encoding="utf-8") as f:
            json.dump(json_data, f, ensure_ascii=False, indent=4)
        print(f"Updated JSON written to {file_path}")
    except Exception as e:
        print(f"Error writing to file: {e}")

    return json_data

# Load JSON data from file
json_filename = "ModExportData.json"
try:
    with open(json_filename, "r", encoding="utf-8") as f:
        json_data = json.load(f)
except FileNotFoundError:
    print(f"File '{json_filename}' not found.")
    json_data = {}
except json.JSONDecodeError:
    print(f"Error decoding JSON from '{json_filename}'.")
    json_data = {}

# Open debug file.
debug_file = open("debug_log.txt", "w", encoding="utf-8")

# Load English translations from file
english_pairs_filename = "Local_Text_Keys.txt"
english_translations = load_english_pairs_from_file(english_pairs_filename, debug_file)

# Update JSON data and write to file
update_english_from_pairs(json_data, english_translations, debug_file=debug_file)

# Close debug file
debug_file.close()