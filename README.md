# C# Practice


## 1. Basics

### 1.1 Mathematics class
#### Technologies:
- Console application
- [Static class](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members) and methods
- Unittest
- \[Obsolete\] Generics

#### Task:
- Create a class that provides the 4 basic arithmetic operations 
each as a method.
    - Addition, subtraction, multiplication and division




### 1.2 Gear Factory

#### Technologies:
- Console application
  - Input output from the console
- Classes

#### Task:
Create a gear inventory application.

The program will greet the user with 4 functions.
1) Fill in gear weight information
2) Output the completed information
3) Output the average weight of all gears
4) Exit program




### 1.3 Vehicles

#### Technologies:
- Console application
- Classes and Interfaces

#### Task:
Create an inheritance hierarchy for different vehicles.

Each traffic participant has a `MovesBy` method, which outputs a line about 
the characteristics of the movement. 
- This can be both general characteristics and information that only a 
particular traffic participant possesses.

Map the following entities into classes and create a meaningful inheritance 
hierarchy:
1) **Vehicle**
   - number of wheels
   - number of passengers it can carry
2) **Truck**
   - max weight it can carry
3) **Car**
   - manufacturer (create a Enum for this, allowing you to select different manufacturers)
   - number of doors
   - manual or automatic transmission
4) **Bicycle**
   - type - cargo, racing, recumbent, folding... (create another Enum for this)
   - Indicates whether the bike is lit or not.
5) **Pedestrian**
   - has an age and sex.

Create a list of traffic participant in your main method and call the method `MovesBy()` 
for each of them.




### 1.4 Validation of login forms

#### Technologies:
- Console application
  - Input output from the console
- Regular expressions
- Array examining

#### Task:
Make two versions of the validation function for:
- email,
- phone number,
- zip code

One variant should use regular expressions, the other - explore a 
string as an array.




### 1.5 Calculation task generator with timing

#### Technologies:
- Loops
- Random
- DateTime
- TimeSpan

#### Task:
Create a program that presents 10 arithmetic tasks to the user.

Arithmetic task consist of:
- two randomly chosen numbers between 1 and 10 
- randomly chosen operator ( + , - , \/, \*).

User is  prompted to enter a result.
If the result is incorrect, the following text is displayed.
"The result is incorrect!"
This continues until the user solves the task correctly.
After the 10 tasks have been solved, the time required is to be output on the console.




### 1.6 Simple name generator

#### Technologies:
- Console application
- Reading files 
  - `File.ReadAllLines()`
  - `StreamReader ReadLine()`
  
#### Task:
Write a program that loads two text files (e.g. Firstname.txt, Lastname.txt) 
line by line into an array. Then output a random combination of first name and 
last name.




### 1.7 Anagram generator && Lesen und Bearbeiten von MP3- Dateien?
