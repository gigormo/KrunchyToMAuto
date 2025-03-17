import json
import os

def joinDic(filename="dicJoined.json"):
    """
    Joins every two lines from a file and separates them with a '|' character,
    writing each joined line to a new line in the output file.

    Args:
        filename (str): The name of the file to load.

    Returns:
        list: A list of strings, where each string is the joined pair.
    """
    joined_lines = []
    try:
        with open(english_pairs_filename, "r", encoding="utf-8") as f:
            lines = f.readlines()
            for i in range(0, len(lines), 2):
                if i + 1 < len(lines):
                    line1 = lines[i].rstrip('\r\n')
                    line2 = lines[i + 1].rstrip('\r\n')
                    joined_lines.append(f"{line1}|{line2}")
    except FileNotFoundError:
        print(f"File '{english_pairs_filename}' not found.")
    except Exception as e:
        print(f"Error loading and joining lines: {e}")

    try:
        with open(filename, "w", encoding="utf-8") as f:
            for line in joined_lines: #iterate through each line.
                f.write(line + "\n") #write each line and a new line character.
        print(f"File Wrote {filename}")
    except Exception as e:
        print(f"Error writing to file: {e}")

    return joined_lines

# Set the input filename
english_pairs_filename = "keyDic.txt"  # Replace with your file name

# Call the function
joined_data = joinDic("my_joined_data.txt") #change the output filename if wanted.