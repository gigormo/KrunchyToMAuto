import json
import os

def extract_chinese_english_keys_to_file(json_data, filename="chinese_english_keys.txt"):
    """
    Extracts 'ch' and 'en' keys from JSON data and writes them to a text file,
    with Chinese text on the first line and English text on the second.

    Args:
        json_data (list): The JSON data as a list of dictionaries.
        filename (str): The name of the text file to create.
    """
    chinese_english_pairs = []
    for item in json_data:
            if "ch" in item:
                chinese_text = item["ch"]
                english_text = item.get("en", None) # Get en or None if it does not exist.
                if english_text is not None:
                    chinese_english_pairs.append((chinese_text, english_text))

    try:
        with open(filename, "w", encoding="utf-8") as f:
            for chinese, english in chinese_english_pairs:
                f.write(repr(chinese)[1:-1] + "\n")  # Write Chinese text without quotes
                f.write(repr(english)[1:-1] + "\n") # Write English text without quotes
        print(f"Chinese-English keys written to {filename}")
    except Exception as e:
        print(f"Error writing to file: {e}")

# Load JSON data from file
filename = "LocalText.json"
try:
    with open(filename, 'r', encoding='utf-8') as f:
        json_data = json.load(f)
    extract_chinese_english_keys_to_file(json_data)
except FileNotFoundError:
    print(f"File '{filename}' not found.")
except json.JSONDecodeError:
    print(f"Error decoding JSON from '{filename}'.")