# Basics of .NET
This repository is a collection of exercises with solutions aimed at understanding the `.NET platform`.
Tasks increase in complexity, ranging from a basic understanding of language syntax to developing 
windows applications.
The tasks are divided into sections:
1) [OOP](#1-oop)
2) [Files](#2-files)
3) [LINQ](#3-linq)
4) [Asynchronous](#4-asynchronous)
5) [Networking](#5-networking)
6) [Windows forms](#6-windows-forms)
7) [WPF](#7-wpf)

**Targets**: `.NET Framework 4.8` and `.NET 6`.

Projects are logically divided into Solution Folders.



[//]: # (__________________________________________________________)
## 1. OOP
A set of tasks aimed at basic understanding of the `.NET platform`. 
Examples of working with classes, interfaces, exceptions and tests.

**Console applications only.**

### 1.1. [Calculator](Sources/OOP/README.md)
Basic calculator supporting operations with any data types and tests with **NUnit**.

### 1.2. [Gear factory](Sources/OOP/README.md)
State machine for data recording and output.

### 1.3. [Vehicles](Sources/OOP/README.md)
Inheritance hierarchy practice.

### 1.4. [Validation of login forms](Sources/OOP/README.md)
Validation using regular expressions and string exploration.

### 1.5. [Calculation task generator with timing](Sources/OOP/README.md)
Handling timers and user input.



[//]: # (__________________________________________________________)
## 2. Files
Working with the **Windows file system**. Creating, reading and writing files.

### 2.1. [File system information](Sources/Files/README.md)
Output all file extensions inside a folder

### 2.2. [Simple name generator](Sources/Files/README.md)
Load two files to generate a random name.

### 2.3. [Folder and file renamer](Sources/Files/README.md)
Recursively rename files and folders to the same format.



[//]: # (__________________________________________________________)
## 3. LINQ
Working with **LINQ**, understanding concepts like `IQueryable` and `IEnumerable`.

### 3.1. [Filtering by first and last letter](Sources/LINQ/README.md)
Program that filters words from a list by their initial and final letters.

### 3.2. [Words in a certain position](Sources/LINQ/README.md)
Program that outputs objects from the collection based on their position.



[//]: # (__________________________________________________________)
## 4. Asynchronous
Working with **asynchronous programming**, understanding concepts like `async` and `await`.

### 4.1. [Console status bar](Sources/Asynchronous/README.md)
Loading bar for downloading files.

### 4.2. [Grep](Sources/Asynchronous/README.md)
**"grep"** program, which does almost the same thing `grep(1)` does under Linux.



[//]: # (__________________________________________________________)
## 5. Networking
Working with networks and protocols.

### 5.1. [Ping utility](Sources/Networking/README.md)
Emulation of the work of the console command `ping`.

### 5.2. [Port scanner](Sources/Networking/README.md)
Open port scanner for devices on the local network.



[//]: # (__________________________________________________________)
## 6. Windows forms
Creating graphical applications with Windows Forms.

### 6.1. [Picture viewer](Sources/WindowsForms/README.md)
Application for viewing the picture and selecting the background image.

### 6.2. [Timed math quiz](Sources/WindowsForms/README.md)
Solve 4 arithmetic problems in a limited amount of time.

### 6.3. [Matching game](Sources/WindowsForms/README.md)
Memory game - find the pair.

### 6.4. [MP3 metadata editing](Sources/WindowsForms/README.md)
An application where you can select a mp3 file, process its information, and save it.

### 6.5. [Anagram generator](Sources/WindowsForms/README.md)
Program that takes a "base" word and gives a list of all existing anagrams.



[//]: # (__________________________________________________________)
## 7. WPF
Creating graphical applications with WPF.

### 7.1. [Customer app](Sources/WPF/README.md)
Customer Information Management Application. Deleting, adding, editing.

### 7.2 [Snake](Sources/WPF/README.md)
The classic game.

### 7.2. [Simple chat application](Sources/WPF/README.md)
Using a text file for chat. Accessing a file from multiple computers.