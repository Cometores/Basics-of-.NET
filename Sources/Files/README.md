# Files

[//]: # (__________________________________________________________)
## 2.1 File system information
*.NETFramework v4.8*

#### Task:
Write a program with 2 functions:
1) Output all file extensions inside a folder. The path to the folder must be passed to the function
2) Output information about all storage devices on your computer in the following format: name, size, available space

#### Technologies:
- Console application
- `DriveInfo` & `DirectoryInfo` & `FileInfo`

#### The implementation is in the next project:
- Application logic - [FsInformation](FsInformation)


[//]: # (__________________________________________________________)
## 2.2 Simple name generator
**NOT IMPLEMENTED**

#### Task:
Write a program that loads two text files (e.g. Firstname.txt, Lastname.txt)
line by line into an array. Then output a random combination of first name and
last name.

#### Technologies:
- Console application
- Reading files
    - `File.ReadAllLines()`
    - `StreamReader ReadLine()`