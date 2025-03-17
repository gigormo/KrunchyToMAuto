import json
import os

def extract_chinese_keys_to_file(json_data, filename="chinese_keys.txt"):
    """
    Extracts all 'ch' keys from JSON data and writes them to a text file with literal \n characters, without quotes.

    Args:
        json_data (list): The JSON data as a list of dictionaries.
        filename (str): The name of the text file to create.
    """
    chinese_keys = []
    if "items" in json_data and "LocalText" in json_data["items"]:
        for item in json_data["items"]["LocalText"]:
            if "ch" in item:
                if "en" not in item:
                    print(f"Adding: {item['ch']}")
                    chinese_keys.append(item["ch"])
                else:
                    print(f"Skipping: {item['ch']} (has 'en')")
    try:
        with open(filename, "w", encoding="utf-8") as f:
            for key in chinese_keys:
                f.write(repr(key)[1:-1] + "\n")  # Write the string without the quotes
        print(f"Chinese keys written to {filename}")
    except Exception as e:
        print(f"Error writing to file: {e}")

# Load JSON data from file
filename = "ModExportData.json"
try:
    with open(filename, 'r', encoding='utf-8') as f:
        json_data = json.load(f)
    extract_chinese_keys_to_file(json_data)
except FileNotFoundError:
    print(f"File '{filename}' not found.")
except json.JSONDecodeError:
    print(f"Error decoding JSON from '{filename}'.")

# Load JSON data from file
filename = "ModExportENAdd.json"
try:
    with open(filename, 'r', encoding='utf-8') as f:
        json_data = json.load(f)
    extract_chinese_keys_to_file(json_data)
except FileNotFoundError:
    print(f"File '{filename}' not found.")
except json.JSONDecodeError:
    print(f"Error decoding JSON from '{filename}'.")