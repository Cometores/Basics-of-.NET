# Asynchronous Programming

[//]: # (__________________________________________________________)
## 1. Console status bar

### Task:
Program to track the status of downloads. 

Several URI paths are passed, which can be used
to load files over HTTP. The files are installed in individual threads.
For this, a main thread will track progress and draw status bar in the console:

7 files to be loaded, 3 already loaded: `[+++----]`

![FileDownload](../../others/readmePics/FileDownload.gif)

### Technologies:
- Console application
- `async` & `await`
- `WebClient` & `Uri`

### The implementation is in the next project:
- Application logic - [FileDownload](FileDownload)
<br><br>


[//]: # (__________________________________________________________)
## 2. Grep

### Task:
**"grep"** program, which does almost the same thing `grep(1)` does under Linux:

It takes a byte string or normal string, as well as a path to a folder, and searches
for the same strings in files located in that folder and subfolders.
- For each folder a "folder" thread is created, and for each file a "file" thread.
- Folder thread waits for the file threads and folder threads it created.
- Program starts with only one thread - with one folder thread for the folders
  passed in parameters.

![Grep](../../others/readmePics/Grep.png)

### Technologies:
- Console application
- `async` & `await`
- `FileInfo` & `DirectoryInfo`

### The implementation is in the next project:
- Application logic - [Grep](Grep)
<br><br>


[//]: # (__________________________________________________________)
## 3. Image processor
Console application for batch image processing. The program allows you to apply various filters to images, such as 
grayscale, sepia, color inversion, brightness adjustment, and resizing. 
Users can select filters and their sequence through an interactive interface.

### Features:
- Supports multiple filters:
  - **Grayscale** — converts the image to black and white.
  - **Sepia** — applies a sepia effect to the image.
  - **Invert** — inverts the colors of the image.
  - **Brightness** — adjusts the brightness with a customizable factor.
  - **Resize** — changes the size of the images.
- User-friendly interface for selecting filters and their order.

### Usage:
1. Specify the folder containing the source images.
2. Specify the folder where the processed images should be saved.
3. Select filters and their sequence.

### Example:
```mathematica
Welcome to Image Processor!
Enter the path to the folder containing source images: C:\Images\Input
Enter the path to the folder for saving processed images: C:\Images\Output

Choose filters for image processing:
1 - Grayscale
2 - Sepia
3 - Resize
4 - Invert
5 - Brightness
Enter the filter numbers in the desired order, separated by commas (e.g., 1,3,5): 1,2

Files to be processed:
- image1.jpg
- image2.jpg

Progress: [#####-----] 50% (2/4)
Image saved: C:\Images\Output\image1.jpg
```

### Technology:
- `DataFlow` is used to build an asynchronous image processing pipeline.
- Each filter is represented as a separate `TransformBlock`, enabling parallel processing.

### Notes for Extending:
The code is modular, allowing you to:
- Add new filters by implementing the `IImageFilter` interface.
- Replace the console interface with a graphical one, such as using Windows Forms or WPF.
___

# 🌱 Future Projects

## 4. Task Manager
An application for running, managing and monitoring concurrently running tasks. Create multiple tasks with different 
execution times. Ability to pause, cancel or restart a task. Display the current status of tasks (running, completed, canceled).

## 5. Job Queue Manager
An application for adding, executing and monitoring tasks in a queue. Manage task priorities and limit the number 
of simultaneously running tasks.