# File System Operations

[//]: # (__________________________________________________________)
## 1. File System Information

#### Task:
Write a program with 2 functions:
1) Output all file extensions inside a folder. The path to the folder must be passed to the function
2) Output information about all storage devices on your computer in the following format: name, size, available space

#### Technologies:
- Console application
- `DriveInfo` & `DirectoryInfo` & `FileInfo`

#### The implementation is in the next project:
- Application logic - [FsInformation](FsInformation)
<br><br>


[//]: # (__________________________________________________________)
## 2. Folder and File Renamer
This program renames folders and files in a specified directory with the chosen formatting style, 
supporting recursive renaming if needed. Supported formats include **CamelCase** and **snake_case**.

#### Task:
Recursive or single-level renaming of folders and files.<br>
Supported formats:
- **CamelCase** – capitalizes the first letter of each word, removing spaces.
- **snake_case** – uses underscores to separate words and lowercase letters.

Displays the final folder structure using the tree command.

#### Usage:
Run the program.
1. Enter the **directory path**.
2. Choose the renaming format:
   - **CamelCase**
   - **snake_case**
3. Specify whether renaming should be **recursive** (for nested directories).
4. The program outputs the final folder and file structure.

#### Example:
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

#### Technology:
- System.IO
- Strategy design pattern

#### Notes for Extending:
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