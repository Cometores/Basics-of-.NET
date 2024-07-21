# Basics of .NET
This repository is a collection of exercises with solutions aimed at understanding the `.NET platform`.
Tasks increase in complexity, ranging from a basic understanding of language syntax to developing 
windows applications.
The tasks are divided into sections:
1) [OOP](#1-oop)
2) [Files](#2-files)
3) [LINQ](#3-linq)
4) [Asynchronous](#4-asynchronous)
5) [Windows forms](#5-windows-forms)
6) [WPF](#6-wpf)

**Targets**: `.NET Framework 4.8` and `.NET 6`.

Projects are logically divided into Solution Folders.



## 1. OOP
A set of tasks aimed at basic understanding of the `.NET platform`. 
Examples of working with classes, interfaces, exceptions and tests.

**Console applications only.**

### 1.1 [Calculator](Sources/OOP/REAMDE.md)
Basic calculator supporting operations with any data types and tests with **NUnit**.

### 1.2 [Gear Factory](Sources/OOP/REAMDE.md)
State machine for data recording and output.

### 1.3 [Vehicles](Sources/OOP/REAMDE.md)
Inheritance hierarchy practice.

### 1.4 [Validation of login forms](Sources/OOP/REAMDE.md)
Validation using regular expressions and string exploration.

### 1.5 [Calculation task generator with timing](Sources/OOP/REAMDE.md)
Handling timers and user input.



## 2. Files
Working with the Windows file system. Creating, reading and writing files.

### 2.1 [File system information](Sources/Files/README.md)
Output all file extensions inside a folder

### 2.2 [Simple name generator](Sources/Files/README.md)
Load two files to generate a random name.



## 3. LINQ


[//]: # (__________________________________________________________)
### 3.1 Filtering by first and last letter
**NOT IMPLEMENTED**

#### Technologies:
- Console application
- LINQ
    - `.StartsWith()`
    - `.EndsWith()`
- Listen

#### Task:
Write a program that filters words from a list by their initial and final letters.
The list of words can be taken from [here](https://gist.github.com/MarvinJWendt/2f4f4154b8ae218600eb091a5706b5f4#file-wordlist-german-txt/).


[//]: # (__________________________________________________________)
### 3.2 Words in a certain position
**NOT IMPLEMENTED**

#### Technologies:
- Console application
- LINQ
    - `.Take())`
- - Listen

#### Task:
Write a program that outputs objects from the collection based on their position.
Use the dictionary from the previous assignment.

**Example usage:**
- Output all words at positions 10-20, 110-120, 210-220, and 310-320



## 4. Asynchronous


[//]: # (__________________________________________________________)
### 4.1 Parallel file downloads
#### Technologies:
- Console application
- `async` & `await` 
- `WebClient` & `Uri`

#### Task:
Program to track the status of downloads. Several URI paths are passed, which can be used 
to load files over HTTP. The files are installed in individual threads. 
For this, a main thread will track progress and draw status bar in the console:

7 files to be loaded, 3 already loaded: `[+++----]`

#### The implementation is in the next project:
- Application logic - [FileDownload](Sources/Asynchronous/FileDownload)


[//]: # (__________________________________________________________)
### 4.2 Grep
#### Technologies:
- Console application
- `async` & `await`
- `FileInfo` & `DirectoryInfo`

#### Task:
**"grep"** program, which does almost the same thing `grep(1)` does under Linux:

It takes a byte string or normal string, as well as a path to a folder, and searches 
for the same strings in files located in that folder and subfolders. 
- For each folder a "folder" thread is created, and for each file a "file" thread.
- Folder thread waits for the file threads and folder threads it created.
- Program starts with only one thread - with one folder thread for the folders 
passed in parameters.

#### The implementation is in the next project:
- Application logic - [Grep](Sources/Asynchronous/Grep)




## 5. Windows forms


[//]: # (__________________________________________________________)
### 5.1 Picture Viewer
[Microsoft Tutorial](https://learn.microsoft.com/en-gb/visualstudio/get-started/csharp/tutorial-windows-forms-picture-viewer-layout?view=vs-2022)

#### The implementation is in the next project:
- GUI - [PictureViewer](Sources/WindowsForms/PictureViewer)


[//]: # (__________________________________________________________)
### 5.2 Timed math quiz
[Microsoft Tutorial](https://learn.microsoft.com/en-gb/visualstudio/get-started/csharp/tutorial-windows-forms-math-quiz-create-project-add-controls?view=vs-2022)

#### The implementation is in the next project:
- GUI - [MathQuiz](Sources/WindowsForms/MathQuiz)


[//]: # (__________________________________________________________)
### 5.3 Matching game
[Microsoft Tutorial](https://learn.microsoft.com/en-gb/visualstudio/get-started/csharp/tutorial-windows-forms-create-match-game?view=vs-2022)

#### Task:
Matching game, where the player matches pairs of hidden icons.

#### The implementation is in the next project:
- GUI - [MatchingGame](Sources/WindowsForms/MatchingGame)


[//]: # (__________________________________________________________)
### 5.4 Read and edit information from MP3 files

#### Technologies:
- Windows Forms
  - TextBox, Label, ComboBox, Button
- File Streams
- Extension methods
- Exceptions
- NUnit

#### Task:
An application where you can select a mp3 file, process its information, and save it.

This information ("ID3 tags") are located as strings in the **last 128 bytes** of the file.
- Tag (3)
- Piece title (30)
- Artist (30)
- Album / CD title (30)
- Year of release (4)
- Commentary (30)
- Genre (1)

First you need to check if the file is really a valid MP3 file. 
For this, Tag must be equal to "TAG".
When the file is read, the text fields display information, they can be edited and saved with another button.

![MP3GUI](./others/readmePics/MP3GUI.png)

#### The functionality is divided into 3 projects:
- Application logic - [MP3FileStream](Sources/WindowsForms/MP3FileStream)
- Tests - [MP3FileStreamTests](Sources/WindowsForms/MP3FileStreamTests)
- GUI - [MP3Gui](Sources/WindowsForms/MP3Gui)


[//]: # (__________________________________________________________)
### 5.5 Anagram generator

#### Technologies:
- Windows Forms
- Reading a file
- Listing data structures

#### Task:
Write a program that takes a base word and gives a list of anagrams, working on the basis
of German words.

A [list](https://gist.github.com/MarvinJWendt/2f4f4154b8ae218600eb091a5706b5f4#file-wordlist-german-txt) 
of all meaningful German words is needed.
![MP3GUI](./others/readmePics/AnagramGenerator.png)

#### The functionality is divided into 2 projects:
- Application logic - [Anagram](Sources/WindowsForms/Anagram)
- Tests - [AnagramTests](Sources/WindowsForms/AnagramTests)





## 6. WPF


[//]: # (__________________________________________________________)
### 6.1 Customer App



[//]: # (__________________________________________________________)
### 6.2 "Chat application" with the help of writing files

#### Technologies:
- WPF
- Reading and writing files

#### Task:
Write an application that writes a text file to a folder and can read its contents.
Multiple instances of the application can be launched on different computers,
creating a quasi-chat

**Step 1:**
- Create the application based on a console application.

**Step 2:**
- Transfer the application to Windows Forms
    - Using text fields
    - Reacting to button click
    - Ribbon?

**Step 3:**
- Create an encryption of the chat using the encryption method: **One Time Pad**
- Add to the chat application the functionality to generate a file with a freely definable number of keys
    - each of these keys is 250 characters long and can be used to encrypt and decrypt a message up to 250 characters long
    - When clicking the button to create the key file, a .txt file containing the specified number of keys is created in the file system
- Continue to add the functionality to read a key file for your chat or set the path to it
- Every time a message is written, the top unused key is read from the file and used to encrypt the entered message
- When a message is received or read from the file the same key from the file is used for decryption