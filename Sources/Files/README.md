# File System Operations

[//]: # (__________________________________________________________)
## 1. Directory Analyzer
Simple utility for **analyzing the contents of a directory**. 
The program provides information about files in a specified directory, including their 
**extensions**, **sizes**, and **disk space distribution**.

### Features:
1. **View all unique file extensions in a directory** </br> 
Displays a list of all unique file extensions found in the specified folder.
2. **Search for files by specific extension** </br> 
Allows you to find and list all files with a given extension.
3. **Disk usage report** </br>
Generates a text-based report of disk space usage, showing the total number of files and their cumulative size for each extension.
4. **User-friendly interface** </br>
The program uses a console-based menu, making it easy to interact and choose actions.

### Usage:
1. Run the program and specify the directory you want to analyze.
2. Select the desired action from the menu:
   1. _Show all file extensions in the directory._
   2. _Show files for a specific extension._
   3. _Show a disk usage report._

### Example:
Starting the Program:
```mathematica
Input your directory: C:\MyFolder

Choose an action:
1. Show all file extensions
2. Show files for a specific extension
3. Show disk usage report
4. Change directory
5. Exit
Enter your choice:
```

**Disk Usage Report** example:
```mathematica
File Distribution Report:
-----------------------------------------------
        Ext        |   Count   |  Total Size  |
-----------------------------------------------
.txt              |       12  |      3.25 MB  |
.jpg              |        7  |     14.67 MB  |
.png              |       10  |      8.91 MB  |
-----------------------------------------------
Total: 26.83 MB across all extensions.
```

### Benefits:
- **Performance**: Multithreading accelerates the analysis of large directories.
- **Convenient interface**: The program is designed to be user-friendly and easy to use via the command line.
- **Flexibility**: Supports both shallow and recursive analysis of directories.

### Possible Improvements
- Add support for exporting reports to files (e.g., JSON or CSV format).
- Extend functionality to filter files by size or last modification date.
- Enhance the visualization of reports by adding colored text.
<br><br>



[//]: # (__________________________________________________________)
## 2. Folder and File Renamer
This program renames folders and files in a specified directory with the chosen formatting style, 
supporting recursive renaming if needed. Supported formats include **CamelCase** and **snake_case**.

### Task:
Recursive or single-level renaming of folders and files.<br>
Supported formats:
- **CamelCase** – capitalizes the first letter of each word, removing spaces.
- **snake_case** – uses underscores to separate words and lowercase letters.

Displays the final folder structure using the tree command.

### Usage:
Run the program.
1. Enter the **directory path**.
2. Choose the renaming format:
   - **CamelCase**
   - **snake_case**
3. Specify whether renaming should be **recursive** (for nested directories).
4. The program outputs the final folder and file structure.

### Example:
```console
Enter folder path:
C:\TestFolder

Select formatting type (CamelCase or SnakeCase):
CamelCase

Rename recursively? (yes/no):
yes

File and folder structure after renaming:
C:\TestFolder
│   ExampleFile.txt
│   AnotherFile.doc
│
└───SubFolder
        NestedFile.png
```

### Technology:
- System.IO
- Strategy design pattern

### Notes for Extending:
To add new formats, create a new class implementing the `IFormatStrategy` interface and specify the format logic.

___


# 🌱 Future Projects

## 3. Simple Name Generator
Write a program that loads two text files (e.g. Firstname.txt, Lastname.txt)
line by line into an array. Then output a random combination of first name and
last name.

## 4. Duplicate File Finder
An application to find duplicate files in a specified directory based on name, size or hash.

## 5. File Metadata Editor
An application for reading and editing file metadata, such as EXIF for images.

## 6. Webp to Gif Converter
An application that converts animated Webp files to Gif format.

## 7. File En-Decryption
A program that can encrypt a file and can also decrypt it. 